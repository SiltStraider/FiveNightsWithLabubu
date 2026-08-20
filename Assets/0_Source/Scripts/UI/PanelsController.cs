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
       isMobile = Application.isMobilePlatform || Input.touchSupported;
       
       // Показываем мобильные кнопки только на мобильном устройстве
       mobilePanel.SetActive(isMobile);
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
       if (!isMobile)
           return;
       else
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
