using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    int rate;
    public GameObject ratingwindow;
    private void Start()
    {
        rate = PlayerPrefs.GetInt("rating");
        if (rate % 5 == 0 && rate < 100)
            ratingwindow.SetActive(true);
    }
    public void ratenow()
    {
        PlayerPrefs.SetInt("rating", 101);
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.arhpez.taptapgo");
    }
    public void ratelater()
    {
        ratingwindow.SetActive(false);
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        PlayerPrefs.GetInt("rating", 1);
        
    }
}
