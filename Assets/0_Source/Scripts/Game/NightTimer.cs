using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NightTimer : MonoBehaviour
{
   public VictoryChecker victoryChecker;
   public TextMeshProUGUI timerText;
   public int endHour = 6;
   public int secondsPerHour = 30;

   private int currentHour = 0;

   private void Start()
   {
      StartCoroutine(HourTimer());
   }

   private IEnumerator HourTimer()
   {
      while (currentHour < endHour)
      {
         yield return new WaitForSeconds(secondsPerHour);
         currentHour++;
         RefreshUI();
      }
      victoryChecker.Win();
   }
   
   private void RefreshUI()
   {
      timerText.text = $"{currentHour:00}:00 Am";
   }
}
