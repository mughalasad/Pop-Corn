using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float speed;
    public int rotation;
    public string symbol;
    public bool music;
    public int bundlecode;
    public GameData() 
    {
        this.speed = 1;
        this.rotation = 30;
        this.symbol = "+";
        this.music = false;
        this.bundlecode = 1;
    }
}