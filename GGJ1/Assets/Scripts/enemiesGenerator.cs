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

    public int appearTime;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesNum = 1;
        time = 0;
        disease = false;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if (time % appearTime == 0)
        {
            if (EnemiesNum < 3)
            {
                if (Random.Range(1, 6) % 2 == 0)
                {
                    GameObject go = Instantiate(enemies1) as GameObject;
                    go.transform.position = new Vector3(20.68f, -1.0f, 0);
                    disease = true;
                }
                else
                {
                    GameObject go = Instantiate(enemies2) as GameObject;
                    go.transform.position = new Vector3(20.68f, -1.0f, 0);
                    disease = false;
                }
            }
        }
    }
}
