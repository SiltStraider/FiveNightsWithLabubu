using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
  public AudioClip winAudio;
  public AudioClip endTimeAudio;
  
  public PlaySoundEffects playSoundEffects;
  public PanelsController panelsController;

  public void Win()
  {
    panelsController.SetActivePanelWin(true);
    playSoundEffects.PlayEffect(winAudio);
    playSoundEffects.PlayEffect(endTimeAudio);
  }
}
