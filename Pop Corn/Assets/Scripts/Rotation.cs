using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
    }
}