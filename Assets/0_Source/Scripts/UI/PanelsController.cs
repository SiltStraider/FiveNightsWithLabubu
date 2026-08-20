using System;
using System.Collections;
using UnityEngine;

public class PanelsController : MonoBehaviour
{
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelGameOver; 
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject mobilePanel;
    
    [SerializeField] private float delayActivePanelGameOver = 4;

   private bool isPaused;
   private bool isMobile;

   private void Awake()
   {
       isMobile = DetectMobileDevice();

       if (mobilePanel == null)
       {
           Debug.LogError("MobilePanel не назначен в PanelsController.");
           return;
       }

       // Включаем панель только на мобильном устройстве.
       // На десктопе она сразу отключается.
       mobilePanel.SetActive(isMobile);
   }

   private bool DetectMobileDevice()
   {
#if UNITY_ANDROID || UNITY_IOS
        return true;
#elif UNITY_WEBGL && !UNITY_EDITOR
        return Application.isMobilePlatform;
#else
       return false;
#endif
   }

   private void OnEnable()
   {
       ScreamerManager.ScreamEvent += StartActivePanelGameOver;
   }

   private void OnDisable()
   {
       ScreamerManager.ScreamEvent -= StartActivePanelGameOver;
   }

   private void StartActivePanelGameOver()
   {
       StartCoroutine(ActivePanelGameOverTimer());
   }

   private IEnumerator ActivePanelGameOverTimer()
   {
       yield return new WaitForSeconds(delayActivePanelGameOver);
       panelGameOver.SetActive(true);
   }
   
   public void SetActivePanelWin(bool active)
   {
       panelWin.SetActive(active);
   }
   
   public void ToggleMobilePanel()
   {
       // На десктопе метод ничего не делает
       if (!isMobile)
           return;

       mobilePanel.SetActive(!mobilePanel.activeSelf);
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           isPaused = !isPaused;
           panelPause.SetActive(isPaused);
           
           Time.timeScale = isPaused ? 0 : 1;
       }
   }
}
