using System;
using UnityEngine;

public class PanelsController : MonoBehaviour
{
   public GameObject panelWin;
   public GameObject panelLose;
   public GameObject panelPause;

   private bool isPaused;
   
   public void SetActivePanelWin(bool active)
   {
       panelWin.SetActive(active);
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
