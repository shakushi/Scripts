using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesGenerator : MonoBehaviour
{
    public GameObject enemies1;
    public GameObject enemies2;

    public static int EnemiesNum;

    public static int time;

    public static bool disease;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesNum = 0;
        time = 0;
        disease = false;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time %120 == 0)
        {
            if (EnemiesNum < 2)
            {
                if (Random.Range(1, 6) % 2 == 0)
                {
                    GameObject go = Instantiate(enemies1) as GameObject;
                    go.transform.position = new Vector3(11.99f, -1.112488f, 0);
                    EnemiesNum++;
                    disease = true;
                }
                else
                {
                    GameObject go = Instantiate(enemies2) as GameObject;
                    go.transform.position = new Vector3(11.99f, -1.112488f, 0);
                    EnemiesNum++;
                    disease = false;
                }
            }
        }
    }
}
