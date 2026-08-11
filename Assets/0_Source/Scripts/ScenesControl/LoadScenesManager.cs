using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LoadScenesManager : MonoBehaviour
{
    public static LoadScenesManager Instance;

    [SerializeField] private GameObject quitPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadSceneID(int ID) => SceneManager.LoadScene(ID);

    public void LoadActiveScene()
    {
        int activeSceneID = SceneManager.GetActiveScene().buildIndex;
        LoadSceneID(activeSceneID);
    }

    public void LoadNextScene()
    {
        int activeSceneID = SceneManager.GetActiveScene().buildIndex;
        activeSceneID++;
        LoadSceneID(activeSceneID);
    }

    public void ShowAdAndLoadActiveScene()
    {
        if (ADManager.Instance.ShowAd())
            YG2.onCloseInterAdv += CloseAd;
        else
            LoadActiveScene();
    }

    private void CloseAd()
    {
        YG2.onCloseInterAdv -= CloseAd;
        LoadActiveScene();
    }
    
    public void ShowAdAndExitToMenu()
    {
        if (ADManager.Instance.ShowAd())
            YG2.onCloseInterAdv += CloseAdAndExitToMenu;
        else
            SceneManager.LoadScene("Menu");
    }

    private void CloseAdAndExitToMenu()
    {
        YG2.onCloseInterAdv -= CloseAdAndExitToMenu;
        SceneManager.LoadScene("Menu");
    }

    // // Вызывается при нажатии на кнопку "Quit"
    // public void OnQuitButtonClick()
    // {
    //     quitPanel.SetActive(true); // Показываем панель
    // }
    //
    // // Вызывается при нажатии на кнопку "NO"
    // public void OnNoButtonClick()
    // {
    //     quitPanel.SetActive(false); // Скрываем панель, выход отменён
    // }
    //
    // // Вызывается при нажатии на кнопку "YES"
    // public void OnYesButtonClick()
    // {
    //     // В редакторе Unity — останавливаем режим игры,
    //     // в собранном приложении — закрываем приложение.
    //     #if UNITY_EDITOR
    //     UnityEditor.EditorApplication.isPlaying = false;
    //     #else
    //     Application.Quit();
    //     #endif
    // }
    
}