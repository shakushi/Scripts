using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesController : MonoBehaviour
{
    //Rigidbody2D　操作用
    Rigidbody2D rigid2D;
    //Animator操作用
    Animator animator;
    SpriteRenderer spriteRenderer;

    GameObject score;
    ActionResult script;

    //画像透明度変更用
    Color alpha = new Color(0, 0, 0, 1.0f);

    //playerに当たっていいるとき
    bool playerCheckHit;

    //プレイヤーが切った時
    bool decapitate;

    //透明速度
    public float transparentSpeed;

    //最大速度
    float maxWalkSpeed = -3.0f;

    //歩く速さ
    float walkSpeed = -200.0f;

    bool condition;

    bool Slash;

    int time;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        playerCheckHit = false;

        decapitate = false;

        condition = enemiesGenerator.disease;
        score = GameObject.Find("Score");

        script = score.GetComponent< ActionResult>();

        Slash = false;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        //最大速度より遅いとき
        if (this.rigid2D.velocity.x >= maxWalkSpeed)
        {
            //速度を追加する
            this.rigid2D.AddForce(transform.right * walkSpeed);
        }

        //プレイヤーに当たった時
        if (playerCheckHit)
        {
            //スペースキーを押したとき
                if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!Slash)
                {
                    if (!condition)
                    {
                        script.successAction();
                    }
                    else if (condition)
                    {
                        script.failAction();
                    }
                    Slash = true;
                }

                //透明化開始
                decapitate = true;
            }
        }
        //透明化を開始した時
        if (decapitate)
        {
            //透明化処理
            this.spriteRenderer.material.color -= alpha / transparentSpeed;
        }

        //画像が透明になった時
        if (this.spriteRenderer.material.color.a <= 0)
        {
            //オブジェクトを破棄
            Destroy(this.gameObject);

            enemiesGenerator.EnemiesNum--;
            enemiesGenerator.time = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //this.animator.SetBool("Idle", true);

            playerCheckHit = true;
        }
    }
     /*   if (collision.gameObject.tag == "enemies")
        {
            this.animator.SetBool("Idle", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemies")
        {
            this.animator.SetBool("Idle", false);

        }
    }*/
}
