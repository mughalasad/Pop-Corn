using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float speed;
    public int rotation;
    public int symbol;
    public bool music;
    public GameData() 
    {
        this.speed = 1;
        this.rotation = 30;
        this.symbol = 0;
        this.music = false;
    }
}