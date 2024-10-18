using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU3_1_6_2 : MonoBehaviour
{
    /// <summary>
    /// スライムクラス
    /// </summary> 
    public class Slime
    {
        private int hp;

        //プロパティ
        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        private int attackPower;
        private int defensePower;

        //読み取り用の関数
        public int GetHp()
        {
            return hp;
        }

        //書き込み用の関数
        public void SetHp(int a)
        {
            //hpが0未満の場合、hpを0にする
            if (a < 0)
            {
                hp = 0;
            }
            else
            {
                hp = a;
            }
        }

        //コンストラクタ
        public Slime(string ZZZ, int a, int b, int c)
        {
            hp = a;
            attackPower = b;
            defensePower = c;

            Debug.Log(ZZZ + "のhp = " + hp);
            Debug.Log(ZZZ + "のattackPower = " + attackPower);
            Debug.Log(ZZZ + "のdefensePower = " + defensePower);
        }

        //コンストラクタ1
        public Slime(string ZZZ, int a)
        {
            hp = a;

            Debug.Log(ZZZ + "のhp = " + hp);
        }

        //コンストラクタ2
        public Slime()
        {
            Debug.Log("2つ目のコンストラクタが実行されました");
        }

        public void A()
        {
            Debug.Log("スライムクラスの関数Aが実行されました");
        }
    }

    void Start()
    {
        //Debug.Log("Start関数呼び出し");

        //ファイアスライム
        Slime fireSlime = new Slime("ファイアスライム", 80, 100, 30);
        //アイススライム
        Slime iceSlime = new Slime("アイススライム", 120, 50, 60);
        //エレキスライム
        Slime electricSlime = new Slime("エレキスライム", 100, 80, 40);

        //1つ目のコンストラクタを使用
        Slime aSlime = new Slime("aスライム", 1000);

        //2つ目のコンストラクタを使用
        Slime cSlime = new Slime();

        Slime aSlime2 = new Slime();

        //スライムクラスのSetHp()を実行
        aSlime2.SetHp(-10);

        //スライムクラスのGetHpを実行
        Debug.Log(aSlime2.GetHp());

        Slime aSlime3 = new Slime();

        //スライムクラスのプロパティZを設定
        aSlime3.Hp = 10;

        //スライムクラスのプロパティZを取得
        Debug.Log(aSlime3.Hp);

        // //ファイアスライムデータ割り当て
        // fireSlime.Hp = 80;
        // fireSlime.AttackPower = 100;
        // fireSlime.DefensePower = 30;

        // //アイススライム
        // Slime iceSlime = new Slime();
        // iceSlime.Hp = 120;
        // iceSlime.AttackPower = 50;
        // iceSlime.DefensePower = 60;

        // //エレキスライム
        // Slime electricSlime = new Slime();
        // electricSlime.Hp = 100;
        // electricSlime.AttackPower = 80;
        // electricSlime.DefensePower = 40;
    }

    void Update()
    {
        //Debug.Log("Update");

        //右矢印キーを押している間trueを返す
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("右矢印キーが押されています");
        }

        //左矢印キーを押している間trueを返す
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("左矢印キーが押されています");
        }

        //上矢印キーを押している間trueを返す
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("上矢印キーが押されています");
        }

        //下矢印キーを押している間trueを返す
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("下矢印キーが押されています");
        }

        //スペースキーを押している間trueを返す
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("スペースキーが押されています");
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("左クリックされました");
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("右クリックされました");
        }

        if (Input.GetMouseButtonDown(2))
        {
            //Debug.Log("中央クリックされました");
        }
    }

    void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name + "との接触開始");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name + "との接触中");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name + "との接触終了");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.gameObject.name + "との接触開始");
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log(collider.gameObject.name + "との接触中");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log(collider.gameObject.name + "との接触終了");
    }

    private void OnMouseEnter()
    {
        //Debug.Log(name + "のコライダー範囲にマウスが入りました");
    }

    private void OnMouseOver()
    {
        //Debug.Log(name + "のコライダー範囲にマウスが入り続けています");
    }

    private void OnMouseExit()
    {
        //Debug.Log(name + "のコライダー範囲にマウスが出ました");
    }

    private void OnMouseDown()
    {
        //Debug.Log(name + "のコライダー範囲にマウス左が押されました");
    }

    private void OnMouseDrag()
    {
        //Debug.Log(name + "のコライダー範囲にマウス左ドラッグを開始しました" + "(コライダーの範囲外でも有効)");
    }

    private void OnMouseUpAsButton()
    {
        //Debug.Log(name + "のコライダー範囲内でマウス左が離されました");
    }

    private void OnMouseUp()
    {
        //Debug.Log(name + "からマウス左が離されました" + "(コライダーの範囲外でも有効)");
    }
}
