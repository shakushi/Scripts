using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionResult : MonoBehaviour
{
    public int pointRate;
    public static int point;

    private Text pointText;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        this.pointText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(point <= 0)
        {
            point = 0;
        }

        // this.successAction(); // テスト用
        this.pointText.text = point.ToString();

        //Debug.Log(point);
    }

    // 治療成功した時に呼ばれる
    public void successAction(int num = 1)
    {
        point += pointRate * num;
    }

    // 治療失敗した時に呼ばれる
    public void failAction(int num = 1)
    {
        point -= pointRate * num;
    }
}
