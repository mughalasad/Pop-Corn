using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour,IDataPersistence
{
    [SerializeField] private GameObject SettingsPage;
    [SerializeField] private Toggle Easy;
    [SerializeField] private Toggle Medium;
    [SerializeField] private Toggle Hard;
    [SerializeField] private Toggle Music;
    public AudioMixer mixer;
    float speed;
    int rotation;
    bool musicchecker;

    public void LoadData(GameData data)
    {
        speed = data.speed;
        rotation = data.rotation;
        musicchecker = data.music;
        if (data.speed == 1)
        {
            Easy.isOn = true;
            Medium.isOn = false;
            Hard.isOn = false;
        }
        else if(data.speed == 1.5)
        {
            Easy.isOn = false;
            Medium.isOn = true;
            Hard.isOn = false;
        }
        else
        {
            Easy.isOn = false;
            Medium.isOn = false;
            Hard.isOn = true;
        }
        if (data.music)
        {
            musicchecker = true;
            Music.isOn = true;
            mixer.SetFloat("Master", Mathf.Log10(0.00001f) * 20);
        }
        else
        {
            musicchecker = false;
            Music.isOn = false;
            mixer.SetFloat("Master", Mathf.Log10(1f) * 20);
        }
    }
    public void SaveData(ref GameData data) 
    {
        data.speed = speed;
        data.rotation = rotation;
        data.music = musicchecker;
        data.symbol = "+";
    }
    // Start is called before the first frame update
    void Start()
    {
        SettingsPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void settings()
    {
        SettingsPage.SetActive(true);
    }
    public void close()
    {
        SettingsPage.SetActive(false);
    }
    public void easy()
    {
        speed = 1;
        rotation = 30;
        Easy.isOn = true;
        Medium.isOn = false;
        Hard.isOn = false;
    }
    public void medium()
    {
        speed = 1.5f;
        rotation = 40;
        Easy.isOn = false;
        Medium.isOn = true;
        Hard.isOn = false;
    }
    public void hard()
    {
        speed = 2;
        rotation = 50;
        Easy.isOn = false;
        Medium.isOn = false;
        Hard.isOn = true;
    }
    public void music(bool val)
    {
        if (val)
        {
            musicchecker = true;
            mixer.SetFloat("Master", Mathf.Log10(0.00001f) * 20);
        }
        else
        {
            musicchecker = false;
            mixer.SetFloat("Master", Mathf.Log10(1f) * 20);
        }
    }
}
