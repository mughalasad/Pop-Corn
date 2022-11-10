using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Menurotation : MonoBehaviour
{
    [SerializeField] private GameObject popcornbox;
    [SerializeField] private GameObject textbox;
    bool text=false;
    float posX,posY,angle=0f;
    float radius =0.06f,speed=0.05f,textspeed=0.3f,left=-0.1f,right=0.1f;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (text == false)
        {
            textbox.transform.Translate(Vector3.right * Time.deltaTime * textspeed);
            if (textbox.transform.position.x > right)
                text = true;
        }
        else
        {
            textbox.transform.Translate(Vector3.left * Time.deltaTime* textspeed);
            if (textbox.transform.position.x < left)
                text = false;
        }
        posX = (popcornbox.transform.position.x + Mathf.Cos(angle))* radius;
        posY = (popcornbox.transform.position.y + Mathf.Sin(angle))* radius;
        popcornbox.transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime+speed;
    }

}
