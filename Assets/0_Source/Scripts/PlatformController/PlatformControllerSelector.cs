using UnityEngine;
using YG;

public class PlatformControllerSelector : MonoBehaviour
{
    [SerializeField] private CameraLookController cameraPC;
    [SerializeField] private CameraLookControllerMobile cameraMobile;
    [SerializeField] private GameObject mobileUI;

    private void Start()
    {
        bool isDesktop = YG2.envir.isDesktop;
        cameraPC.enabled = isDesktop;
        cameraMobile.enabled = !isDesktop;
        mobileUI.SetActive(!isDesktop);
    }
    
}
