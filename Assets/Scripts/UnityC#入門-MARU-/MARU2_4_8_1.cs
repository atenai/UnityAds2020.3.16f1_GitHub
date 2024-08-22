using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_4_8_1 : MonoBehaviour
{
    //GameObject型の変数zを宣言
    private GameObject z;

    //Button型の変数bを宣言
    private Button b;

    void Start()
    {
        //Debug.Log("Start");

        //Button(Legacy)という名前のGameObject型を取得
        //変数zへ取得したGameObject型を割り当て
        z = GameObject.Find("Button (Legacy) (2)");

        //変数zに割りついているButton型を取得し変数bへ割り当て
        b = z.GetComponent<Button>();

        //Button型の変数onClick(ButtonClickedEvent型)の
        //ボタンが離されたときに発生するイベントに関数A()を登録
        b.onClick.AddListener(A);

        //ボタンに登録されている処理を実行
        b.onClick.Invoke();
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    public void A()
    {
        Debug.Log("ボタンが押されました2");
    }
}
