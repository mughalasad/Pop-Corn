using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Corn1;
    [SerializeField] private TextMeshProUGUI Corn2;
    [SerializeField] private TextMeshProUGUI Corn3;
    [SerializeField] private TextMeshProUGUI Corn4;
    [SerializeField] private GameObject counterwindow;
    [SerializeField] private TextMeshProUGUI countertext;
    [SerializeField] private GameObject closingwindow;
    [SerializeField] private TextMeshProUGUI closingtext;
    [SerializeField] private GameObject wrongwindow;
    [SerializeField] private GameObject wrongicon;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject circlelocation;
    [SerializeField] private GameObject[] position;
    private GameObject spawn;
    Vector3 loc1,loc2, loc3, loc4;
    int letter1;
    int letter2;
    int selector;
    int answer;
    int counter;
    int scorer = 0;
    int scorekeeper = 0;
    public float speed;
    [SerializeField] public TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        closingwindow.SetActive(false);
        counterwindow.SetActive(false);
        wrongwindow.SetActive(false);
        loc1 = button1.transform.position;
        loc2 = button2.transform.position;
        loc3 = button3.transform.position;
        loc4 = button4.transform.position;
        Startup();
        counter = 10;
    }
    private int numbersetter()
    {
        int p = Random.Range(0, 19);
        if (p==answer)
        {
            p = p - 1;
            return p;
        }
        return p;

    }
    private void LateUpdate()
    {
        //Vector3 pos = button1.transform.position;
        //pos.y += -1 * Time.deltaTime * speed;
        //button1.transform.position = pos;
        //pos = button2.transform.position;
        //pos.y += -1 * Time.deltaTime * speed;
        //button2.transform.position = pos;
        //pos = button3.transform.position;
        //pos.y += -1 * Time.deltaTime * speed;
        //button3.transform.position = pos;
        //pos = button4.transform.position;
        //pos.y += -1 * Time.deltaTime * speed;
        //button4.transform.position = pos;
    }
    private void Startup()
    {
        button1.transform.position = loc1;
        button2.transform.position = loc2;
        button3.transform.position = loc3;
        button4.transform.position = loc4;
        letter1 = Random.Range(0, 10);
        letter2 = Random.Range(0, 10);
        answer = letter2 + letter1;
        scoretext.text = letter1 + " + " + letter2 + " = ?";
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
        if (!counterwindow.activeInHierarchy)
        {
            Time.timeScale = 1f;
            check();
        }
        if (counter == 0)
            closingwindow.SetActive(true);

        yield break;
    }
    public void corn1answer()
    {
        counter--;
        if (counter % 5 == 0)
        {
            Time.timeScale = 0f;
            counterwindow.SetActive(true);
        }
        if (Corn1.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            check();
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
        }
        else
        {
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn1.transform.position;
            StartCoroutine(wrong());
        }
    }
    public void corn2answer()
    {
        counter--;
        if(counter%5==0)
        {
            counterwindow.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Corn2.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            check();
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
        }
        else
        {
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn2.transform.position;
            StartCoroutine(wrong());
        }
    }
    public void corn3answer()
    {
        counter--;
        if (counter % 5 == 0)
        {
            counterwindow.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Corn3.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            check();
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
        }
        else
        {
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn3.transform.position;
            StartCoroutine(wrong());
        }
    }
    public void corn4answer()
    {
        counter--;
        if (counter % 5 == 0)
        {
            counterwindow.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Corn4.text == answer.ToString())
        {
            scorer++;
            scorekeeper++;
            check();
            spawn = Instantiate(circle);
            spawn.transform.position = circlelocation.transform.position;
        }
        else
        {
            Time.timeScale = 0f;
            wrongicon.transform.position = Corn4.transform.position;
            StartCoroutine(wrong());
        }
    }
    void Update()
    {
        countertext.text = scorer + " / 5";
        closingtext.text = scorekeeper + " / 10";
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
        closingwindow.SetActive(false);
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
                closingwindow.SetActive(true);
        }
        else
            check();
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
