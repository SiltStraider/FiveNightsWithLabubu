using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private float delayOpenPanel = 0.3f;
    [SerializeField] private Animator tabletAnimator;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private CameraZone[] cameraZones;
    [SerializeField] private GameObject panelCameras;
    [SerializeField] private Button buttonActivePanel;
    
    [SerializeField] private AudioClip openTabletAudio;
    [SerializeField] private AudioClip closeTabletAudio;
    [SerializeField] private AudioClip switchCameraAudio;
    [SerializeField] private PlaySoundEffects playSoundEffects;
    
   
   public static CameraSwitcher Instance;

   public bool IsActivePanel { get; private set; }
   private string _tabletOpenAnimation = "Open";
   private CameraZone _currentZone;

   private void OnEnable()
   {
       ScreamerManager.ScreamEvent += DeactivateAll;
   } 
   private void OnDisable()
   {
       ScreamerManager.ScreamEvent -= DeactivateAll;
   }

   private void Awake()
   {
       Instance = this;
   }

   private void Start()
   {
       buttonActivePanel.onClick.AddListener(SwitchActivePanel);
   }

   public void SwitchCamera(CameraZone cameraZone)
   {
       for (int i = 0; i < cameraZones.Length; i++)
       {
           if (cameraZone == cameraZones[i])
           {
               _currentZone = cameraZone;
               SetActiveCameraZone(i, true);
               playSoundEffects.PlayEffect(switchCameraAudio);
           }
           else
           {
               SetActiveCameraZone(i, false);
           }
  
       }
   }

   private void SwitchActivePanel()
   {
       IsActivePanel = !IsActivePanel;
       tabletAnimator.SetBool(_tabletOpenAnimation, IsActivePanel);
       
       if (IsActivePanel) playSoundEffects.PlayEffect(openTabletAudio);
       else playSoundEffects.PlayEffect(closeTabletAudio);
       
       StartCoroutine(SwitchActivePanelDelay());
   }

   private void DeactivateAll()
   {
       IsActivePanel = false;
       SetActivePanelCameras(false);
       
       for (int i = 0; i < cameraZones.Length; i++)
           SetActiveCameraZone(i, false);
       
       SetActiveMainCamera(true);
   }

   private IEnumerator SwitchActivePanelDelay()
   {
       yield return new WaitForSeconds(delayOpenPanel);
       
       SetActivePanelCameras(IsActivePanel);
       SetActiveMainCamera(!IsActivePanel);
       
       if (_currentZone == null) 
           _currentZone = cameraZones[0];

       if (IsActivePanel)
       {
           SwitchCamera(_currentZone);
       }
       else
       {
           for (int i = 0; i < cameraZones.Length; i++)
               SetActiveCameraZone(i, false);
       }
   }
   
   private void SetActiveMainCamera(bool active) => mainCamera.SetActive(active);

   private void SetActiveCameraZone(int cameraID, bool active) => cameraZones[cameraID].SetActiveCamera(active);

   private void SetActivePanelCameras(bool active) => panelCameras.SetActive(active);
   
}
