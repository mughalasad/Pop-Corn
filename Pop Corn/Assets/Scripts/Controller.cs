using UnityEditor;
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
        else
            ratingwindow.SetActive(false);
    }
    public void ratenow()
    {
        PlayerPrefs.SetInt("rating", 101);
        ratingwindow.SetActive(false);
        Debug.Log(PlayerPrefs.GetInt("rating"));
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.arhpez.taptapgo");
    }
    public void ratelater()
    {
        ratingwindow.SetActive(false);
    }
    public void play()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene(1);
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        PlayerPrefs.GetInt("rating", 1);
        
    }
}
