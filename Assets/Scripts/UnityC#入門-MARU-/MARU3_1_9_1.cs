using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU3_1_9_1 : MonoBehaviour
{
    /// <summary>
    /// スライムクラス
    /// </summary> 
    public class Slime
    {
        public int Hp { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
    }

    void Start()
    {
        //Debug.Log("Start関数呼び出し");

        //ファイアスライム
        Slime fireSlime = new Slime();
        //ファイアスライムデータ割り当て
        fireSlime.Hp = 80;
        fireSlime.AttackPower = 100;
        fireSlime.DefensePower = 30;

        //アイススライム
        Slime iceSlime = new Slime() { Hp = 120, AttackPower = 50, DefensePower = 60 };

        //エレキスライム
        Slime electricSlime = new Slime
        {
            //エレキスライムデータ割り当て
            Hp = 100,
            AttackPower = 80,
            DefensePower = 40,
        };

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
