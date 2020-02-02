using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelAction : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    public bool isFinished;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        isFinished = false;
    }

    void Update()
    {
        if (isFinished && alfa < 0.7)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }
    }

    public void setFinish()
    {
        this.isFinished = true;
    }
}