using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public GameObject pointObject;
    
    private int maxPoint;
    private Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        this.maxPoint = ActionResult.point;
        this.ammoText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ActionResult.point);
        if (this.maxPoint < ActionResult.point)
        {
            this.maxPoint = ActionResult.point;
            this.ammoText.text = this.maxPoint.ToString();
        }
    }
}
