using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LoadScenesManager : MonoBehaviour
{
    public static LoadScenesManager Instance;

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

    public void QuitGame() => Application.Quit();
    
}
