using UnityEngine;
using UnityEngine.UI;//uGUIにアクセス
using System.Collections;

public class goodhand : MonoBehaviour
{
    private Image image;
    private float time;
    public float fadetime;

    //透明度操作用
    SpriteRenderer spriteRenderer;
    Color alpha = new Color(0, 0, 0, 1.0f);

    private bool active = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        time = fadetime;//初期化
        image = GetComponent<Image>();//Imageコンポネントを取得
    }

    void Update()
    {
        time -= Time.deltaTime;//時間更新(徐々に減らす)
        float f = time / fadetime; //徐々に0に近づける
        float a = 1 - time / fadetime;//徐々に1に近づける
        if (a > 0.9f && active)
        {
            //Debug.Log("destroy");
            Destroy(this.gameObject, 0.2f);
            active = false;
        }
        else if (active)
        {
            Vector2 trans = this.transform.position;
            trans.y += f * 0.08f;
            this.transform.position = trans;

            this.spriteRenderer.material.color = alpha * a;
        }
    }
}