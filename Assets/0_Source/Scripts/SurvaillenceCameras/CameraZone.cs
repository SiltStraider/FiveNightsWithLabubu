using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraZone : MonoBehaviour
{
    public Button buttonCameraSwitcher;
    public GameObject cameraObject;

    private void Start()
    {
        buttonCameraSwitcher.onClick.AddListener(SwitchCameraButton
        );
    }

    private void SwitchCameraButton()
    {
        CameraSwitcher.Instance.SwitchCamera(this);
    }
    
    public void SetActiveCamera(bool active)
    {
        cameraObject.SetActive(active);
    }

}
