using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI1_5_5_2 : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        //モバイルプラットフォームでなければ中身を実行する
        if (!Application.isMobilePlatform == true)
        {
            //モバイルプラットフォーム以外の処理
            if (Input.GetMouseButtonUp(0))
            {
                //マウスの左ボタンが押して離された状態なら
                //CubeGeneratorコンポーネントのGenerateメソッドを呼ぶ
                this.GetComponent<UI1_5_5_1>().Generate();
            }
        }
        else
        {
            //モバイルプラットフォームの処理
            if (1 <= Input.touchCount)
            {
                //マルチタッチの最初のタッチを取得
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    //タッチが開始された状態なら、CubeGeneratorコンポーネントのGenerateメソッドを呼ぶ
                    this.GetComponent<UI1_5_5_1>().Generate();
                }
            }
        }
    }
}
