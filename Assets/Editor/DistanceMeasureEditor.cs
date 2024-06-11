using UnityEngine;
using UnityEditor;

/// <summary>
/// 2つのゲームオブジェクトをヒエラルキーから指定して距離の計算を行うエディタウィンドウ
/// スクリプトファイルの作成位置は、Assets/Editorの中に必ず作成する
/// </summary>
public class DistanceMeasureEditor : EditorWindow//エディタウィンドウにする為には、必ずEditorWindowクラスを継承する
{
    GameObject object1;
    GameObject object2;
    float distanceX;
    float distanceY;
    float distanceZ;
    float totalDistance;

    [MenuItem("Kashiwabara/Distance Measure")]//エディタのメニューバーにあるWindowの項目の中にDistance Measureという項目を作成する
    public static void ShowWindow()//必ずstatic型のShowWindow関数を呼ぶ必要がある
    {
        GetWindow<DistanceMeasureEditor>("Distance Measure");//このクラスを型にしてエディタウィンドウを作成する
    }

    void OnGUI()
    {
        GUILayout.Label("2つゲームオブジェクトを指定してその距離を測る", EditorStyles.boldLabel);//ラベル(文字)を追加する

        object1 = (GameObject)EditorGUILayout.ObjectField("Object 1", object1, typeof(GameObject), true);//ゲームオブジェクトを投入できる項目を追加する
        object2 = (GameObject)EditorGUILayout.ObjectField("Object 2", object2, typeof(GameObject), true);//ゲームオブジェクトを投入できる項目を追加する

        if (GUILayout.Button("Calculate Distance") == true)//ボタンを追加し、そのボタンが押されたら中身を実行する
        {
            if (object1 != null && object2 != null)
            {
                Vector3 position1 = object1.transform.localPosition;
                Vector3 position2 = object2.transform.localPosition;

                distanceX = Mathf.Abs(position1.x - position2.x);
                Debug.Log("X座標の長さ : " + distanceX);
                distanceY = Mathf.Abs(position1.y - position2.y);
                Debug.Log("Y座標の長さ : " + distanceY);
                distanceZ = Mathf.Abs(position1.z - position2.z);
                Debug.Log("Z座標の長さ : " + distanceZ);

                totalDistance = Vector3.Distance(position1, position2);
                Debug.Log("2つのゲームオブジェクトの距離 : " + totalDistance);
            }
            else
            {
                Debug.LogWarning("2つのゲームオブジェクトを指定してください。");
            }
        }

        if (object1 != null && object2 != null)
        {
            GUILayout.Label("X座標のローカルの長さ : " + distanceX.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト1のローカル座標X : " + object1.transform.localPosition.x.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト2のローカル座標X : " + object2.transform.localPosition.x.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト1のグローバル座標X : " + object1.transform.position.x.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト2のグローバル座標X : " + object2.transform.position.x.ToString());//ラベル(文字)を追加する
            GUILayout.Label("Y座標のローカルの長さ : " + distanceY.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト1のローカル座標Y : " + object1.transform.localPosition.y.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト2のローカル座標Y : " + object2.transform.localPosition.y.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト1のグローバル座標Y : " + object1.transform.position.y.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト2のグローバル座標Y : " + object2.transform.position.y.ToString());//ラベル(文字)を追加する
            GUILayout.Label("Z座標のローカルの長さ : " + distanceZ.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト1のローカル座標Z : " + object1.transform.localPosition.z.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト2のローカル座標Z : " + object2.transform.localPosition.z.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト1のグローバル座標Z : " + object1.transform.position.z.ToString());//ラベル(文字)を追加する
            GUILayout.Label("ゲームオブジェクト2のグローバル座標Z : " + object2.transform.position.z.ToString());//ラベル(文字)を追加する
            GUILayout.Label("2つのゲームオブジェクトの距離 : " + totalDistance.ToString());//ラベル(文字)を追加する
        }
    }
}
