using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesController : MonoBehaviour
{
    //Rigidbody2D　操作用
    Rigidbody2D rigid2D;
    //Animator操作用
    Animator animator;
    //透明度操作用
    SpriteRenderer spriteRenderer;
    //AudioSource操作用
    AudioSource audioSource;
    GameObject score;
    ActionResult script;
    public AudioClip sound;
    //いいねの手
    public GameObject goodhand;

    //画像透明度変更用
    Color alpha = new Color(0, 0, 0, 1.0f);
    //画像最大透明度
    bool Maxalpha;

    //playerに当たっていいるとき
    bool playerCheckHit;

    //プレイヤーが切った時
    bool decapitate;

    //透明速度
    public float transparentSpeed;
    //透明化を遅くする数値（ミス時のみ）
    private float transDelay = 0;

    //登場時間
    public float EmergenceTime;

    //最大速度
    float maxWalkSpeed = -10.0f;

    //歩く速さ
    float walkSpeed = -240.0f;

    bool condition;

    bool Slash;

    int time;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        playerCheckHit = false;

        decapitate = false;

        Maxalpha = true;

        condition = enemiesGenerator.disease;
        score = GameObject.Find("Score");

        script = score.GetComponent< ActionResult>();

        Slash = false;

        time = 0;

        enemiesGenerator.EnemiesNum++;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemiesGenerator.EnemiesNum);
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
                    if (Maxalpha)
                    {
                        if (!condition)
                        {
                            if (time <= (EmergenceTime / 3))
                            {
                                //いいねを表示してスコア３倍
                                Instantiate(goodhand);
                                script.successAction(3);
                            }
                            else
                            {
                                script.successAction();
                            }
                            audioSource.PlayOneShot(sound);
                            this.animator.SetBool("Repair", true);
                        }
                        else if (condition)
                        {
                            script.failAction();
                            audioSource.PlayOneShot(sound);
                            this.animator.SetBool("Dead", true);
                            transDelay += 60;
                        }
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
            Maxalpha = false;
            //透明化処理
            this.spriteRenderer.material.color -= alpha / (transparentSpeed + transDelay);
        }

        //画像が透明になった時
        if (this.spriteRenderer.material.color.a <= 0)
        {
            //オブジェクトを破棄
            Destroy(this.gameObject);

            enemiesGenerator.EnemiesNum--;
            enemiesGenerator.time = 0;
        }

        if(time >= EmergenceTime)
        {
            decapitate = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerCheckHit = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            time++;
        }
    }
}
