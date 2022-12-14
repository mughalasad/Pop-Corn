using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Feedback : MonoBehaviour
{
    [SerializeField] private GameObject feedbackmenu;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TextMeshProUGUI emailtext;
    [SerializeField] private TMP_InputField feedback;
    [SerializeField] private TextMeshProUGUI feedbacktext;
    // Start is called before the first frame update
    void Start()
    {
        feedbackmenu.SetActive(false);
    }
    public void click()
    {
        feedbackmenu.SetActive(true);
    }
    public void close()
    {
        emailtext.text = "";
        feedbacktext.text = "";
        email.text = "";
        feedback.text = "";
        feedbackmenu.SetActive(false);
    }
    public void send()
    {
        string e = email.text;
        string f = feedback.text;
        string url = "https://docs.google.com/forms/u/2/d/e/1FAIpQLSdJ60jEUCUnE8JbQxn9TmS2FirAvmEyEIwX3zcTEr265lvmRA/formResponse";
        if (e.Length < 1)
        {
            emailtext.text = "Please enter your Email";
            return;
        }
        if (e.Length > 30)
        {
            emailtext.text = "Invalid email";
            return;
        }
        if (e.IndexOf('@')<1 || e.IndexOf('.') < 1)
        {
            emailtext.text = "Invalid email";
            return;
        }
        emailtext.text = "";
        if (f.Length < 1)
        {
            feedbacktext.text = "Please enter some feedback";
            return;
        }
        if (f.Length > 250)
        {
            feedbacktext.text = "Exceeded character limit";
            return;
        }
        feedbacktext.text = "";
        
        WWWForm form = new WWWForm();
        form.AddField("entry.1353741807", e);
        form.AddField("entry.722532012", f);
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(UnityWebRequest www)
    {
        yield return www.SendWebRequest();

         // check for errors
         if (www.error == null)
        {
            email.text = "";
            feedback.text = "";
            Debug.Log("WWW Ok!: " + www.result);// contains all the data sent from the server
            feedbackmenu.SetActive(false);
        }
        else
        {
            feedbacktext.text = "" + www.result;
            Debug.Log("WWW Error: " + www.result);
        }
        yield break; 
    }
}
