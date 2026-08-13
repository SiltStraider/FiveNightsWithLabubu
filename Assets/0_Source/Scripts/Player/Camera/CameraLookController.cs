using UnityEngine;

public class CameraLookController : MonoBehaviour
{
    public float sensitivity = 50f;
    public float maxAngle = 40f;
    public float edgeSize = 500;
    
    private float currentY;
    
    void Update()
    {
        float screenWidth = Screen.width;

        if (Input.mousePosition.x >= screenWidth - edgeSize)
        {
            currentY += sensitivity * Time.deltaTime;
        }
        else if (Input.mousePosition.x <= edgeSize)
        {
            currentY -= sensitivity * Time.deltaTime;
        }
        
        currentY = Mathf.Clamp(currentY, -maxAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(0, currentY, 0);
    }
}