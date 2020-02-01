using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultaction1 : MonoBehaviour
{
    // public GameObject obj;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponentInChildren<Text>();
        this.text.text = "Score: " + ActionResult.point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // nothing
    }
}
