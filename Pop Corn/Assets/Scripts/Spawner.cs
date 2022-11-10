using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Net.Http.Headers;

public class Spawner : MonoBehaviour,IDataPersistence
{
    [SerializeField] private TextMeshProUGUI Corn1;
    [SerializeField] private TextMeshProUGUI Corn2;
    [SerializeField] private TextMeshProUGUI Corn3;
    [SerializeField] private TextMeshProUGUI Corn4;
    [SerializeField] private GameObject counterwindow;
    [SerializeField] private TextMeshProUGUI countertext;
    [SerializeField] private GameObject closingwindow;
    [SerializeField] private TextMeshProUGUI closingtext;
    [SerializeField] private TextMeshProUGUI closingtext1;
    [SerializeField] private GameObject wrongwindow;
    [SerializeField] private GameObject wrongicon;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject circlelocation;
    [SerializeField] private GameObject confetti;
    [SerializeField] private GameObject[] position;
    [SerializeField] private AudioSource trueanswer;
    [SerializeField] private AudioSource wronganswer;
    public AudioMixer mixer;
    private GameObject spawn;
    Vector3 loc1,loc2, loc3, loc4;
    int letter1;
    int letter2;
    int selector;
    int answer;
    int counter;
    int scorer = 0;
    int scorekeeper = 0;
    float speed;
    int rotation;
    string sum;
    [SerializeField] public TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        closingwindow.SetActive(false);
        counterwindow.SetActive(false);
        wrongwindow.SetActive(false);
        confetti.SetActive(false);
        loc1 = button1.transform.position;
        loc2 = button2.transform.position;
        loc3 = button3.transform.position;
        loc4 = button4.transform.position;
        counter = 15;
    }
    public void LoadData(GameData data)
    {
        speed= data.speed;
        rotation = data.rotation;
        if (data.music)
        {
            mixer.SetFloat("Master", Mathf.Log10(0.00001f) * 20);
        }
        else
        {
            mixer.SetFloat("Master", Mathf.Log10(1f) * 20);
        }
        Startup();
    }
    public void SaveData(ref GameData data) {}
    private int numbersetter()
    {
        int p = Random.Range(0, 19);
        if (sum == "x")
            p = Random.Range(0, 81);
        if (p==answer)
        {
            p = p - 1;
            return p;
        }
        return p;

    }
    private void Startup()
    {
        button1.transform.position = loc1;
        button2.transform.position = loc2;
        button3.transform.position = loc3;
        button4.transform.position = loc4;
        if(rotation==30)
        {
            int x = Random.Range(0, 10);
            if (x < 5)
                sum = "+";
            else
                sum = "-";

        }
        else if(rotation==40)
        {
            int x = Random.Range(0, 10);
            if (x < 4)
                sum = "+";
            else if (x < 8)
                sum = "-";
            else
                sum = "x";
        }
        else
        {
            int x = Random.Range(0, 10);
            if (x < 6)
                sum = "x";
            else if (x < 8)
                sum = "-";
            else
                sum = "+";
        }
        switch(sum)
        {
            case "+":
                letter1 = Random.Range(0, 10);
                letter2 = Random.Range(0, 10);
                answer = letter1 + letter2;
                break;
            case "-":
                letter1 = Random.Range(0, 10);
                letter2 = Random.Range(0, letter1 + 1);
                answer = letter1 - letter2;
                break;
            case "x":
                letter1 = Random.Range(0, 10);
                letter2 = Random.Range(0, 10);
                answer = letter1 * letter2;
                break;

        }
        scoretext.text = letter1 + " " + sum + " " + letter2 + " = ?";
        selector = Random.Range(0, 4);
        switch(selector)
        {
            case 0:
                Corn1.text = answer+"";
                Corn2.text = numbersetter() + "";
                Corn3.text = numbersetter() + "";
                Corn4.text = numbersetter() + "";
                break;
            case 1:
                Corn1.text = numbersetter() + "";
                Corn2.text = answer + "";
                Corn3.text = numbersetter() + "";
                Corn4.text = numbersetter() + "";
                break;
            case 2:
                Corn1.text = numbersetter() + "";
                Corn2.text = numbersetter() + "";
                Corn3.text = answer + "";
                Corn4.text = numbersetter() + "";
                break;
            case 3:
                Corn1.text = numbersetter() + "";
                Corn2.text = numbersetter() + "";
                Corn3.text = numbersetter() + "";
                Corn4.text = answer + "";
                break;
        }
    }
    IEnumerator wrong()
    {
        wrongwindow.SetActive(true);
        wrongicon.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        wrongwindow.SetActive(false);
        wrongicon.SetActive(false);
        if (counter % 5 == 0)
        {
            Time.timeScale = 0f;
            counterwindow.SetActive(true);
        }
        if (!counterwindow.activeInHierarchy)
        {
            Time.timeScale = 1f;
            check();
        }
        if (counter == 0)
        { 
            closingwindow.SetActive(true);
            confetti.SetActive(true); 
        }

        yield break;
    }
    //IEnumerator wait()
    //{
    //    yield return new WaitForSecondsRealtime(0.1f);
    //    confetti.SetActive(false);
    //    Time.timeScale = 1f;
    //    check();
    //    yield break;
    //}
    public void corn1answer()
    {
        counter--;
        if (Corn1.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            trueanswer.Play();
            //confetti.transform.position = Corn1.transform.position;
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
            check();
            //Time.timeScale = 0f;
            //StartCoroutine(wait());
            if (counter % 5 == 0)
            {
                Time.timeScale = 0f;
                counterwindow.SetActive(true);
            }
        }
        else
        {
            wronganswer.Play();
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn1.transform.position;
            StartCoroutine(wrong());
        }
    }
    public void corn2answer()
    {
        counter--;
        if (Corn2.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            trueanswer.Play();
            //confetti.transform.position = Corn2.transform.position;
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
            check();
            //Time.timeScale = 0f;
            //StartCoroutine(wait());
            if (counter % 5 == 0)
            {
                counterwindow.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            wronganswer.Play();
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn2.transform.position;
            StartCoroutine(wrong());
        }
    }
    public void corn3answer()
    {
        counter--;
        if (Corn3.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            trueanswer.Play();
            //confetti.transform.position = Corn3.transform.position;
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
            check();
            //Time.timeScale = 0f;
            //StartCoroutine(wait());
            if (counter % 5 == 0)
            {
                counterwindow.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            wronganswer.Play();
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn3.transform.position;
            StartCoroutine(wrong());
        }
    }
    public void corn4answer()
    {
        counter--;
        if (Corn4.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            trueanswer.Play();
            //confetti.transform.position = Corn4.transform.position;
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
            check();
            //Time.timeScale = 0f;
            //StartCoroutine(wait());
            if (counter % 5 == 0)
            {
                counterwindow.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            wronganswer.Play();
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn4.transform.position;
            StartCoroutine(wrong());
        }
    }
    void Update()
    {
        button1.transform.Rotate(Vector3.forward * Time.deltaTime*rotation);
        Corn1.transform.Rotate(Vector3.back * Time.deltaTime * rotation);
        button2.transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        Corn2.transform.Rotate(Vector3.back * Time.deltaTime * rotation);
        button3.transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        Corn3.transform.Rotate(Vector3.back * Time.deltaTime * rotation);
        button4.transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        Corn4.transform.Rotate(Vector3.back * Time.deltaTime * rotation);
        countertext.text = "You Scored " + scorer + " / 5";
        closingtext.text = scorekeeper + "";
        closingtext1.text = scorekeeper + "";
        Vector3 pos = button1.transform.position;
        pos.y += -1 * Time.deltaTime * speed;
        button1.transform.position = pos;
        pos = button2.transform.position;
        pos.y += -1 * Time.deltaTime * speed;
        button2.transform.position = pos;
        pos = button3.transform.position;
        pos.y += -1 * Time.deltaTime * speed;
        button3.transform.position = pos;
        pos = button4.transform.position;
        pos.y += -1 * Time.deltaTime * speed;
        button4.transform.position = pos;
    }
    public void close()
    {
        counterwindow.SetActive(false);
        if (!closingwindow.activeInHierarchy)
        {
            Time.timeScale = 1f;
            positioning();
        }
        scorer =0;
    }
    public void closing()
    {
        SceneManager.LoadScene(0);
        int rate = PlayerPrefs.GetInt("rating");
        rate++;
        PlayerPrefs.SetInt("rating", rate);
    }
    void check()
    {
        if (counter == 0)
        {
            closingwindow.SetActive(true);
            confetti.SetActive(true);
        }
        else if (counter % 5 != 0)
            positioning();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        counter--;
        if (counter % 5 == 0)
        {
            counterwindow.SetActive(true);
            Time.timeScale = 0f;
            if (counter == 0)
            {
                closingwindow.SetActive(true);
                confetti.SetActive(true);
            }
        }
        else
            check();
        transform.GetComponent<AudioSource>().Play();
    }
    void positioning()
    {
        int a, b, c, d;
        a = number();
        loc1 = position[a].transform.position;
        b = number();
        while(b==a)
        {
            b= number();
        }
        loc2 = position[b].transform.position;
        c = number();
        while (c == a || c==b)
        {
            c = number();
        }
        loc3 = position[c].transform.position;
        d = number();
        while (d == a || d == b || d==c)
        {
            d = number();
        }
        loc4 = position[d].transform.position;
        Startup();
    }
    int number()
    {
        return Random.Range(0, 7); ;
    }
}
