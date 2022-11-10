using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    int click = 0;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            click++;
            StartCoroutine(ClickTime());

            if (click > 1)
            {
                Application.Quit();
            }
        }
    }
    IEnumerator ClickTime()
    {
        yield return new WaitForSeconds(0.5f);
        click = 0;
    }
}