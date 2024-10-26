
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class ExampleWindow47 : Editor//Editorにする
{
    [MenuItem("Kashiwabara/Example47_1")]//エディタのメニューバーにあるKashiwabaraの項目の中にExample47_1という項目が作成される
    static void CreateAnimationClip()//Example47_1ボタンを押したらこの関数が実行される
    {
        //まだアセットとして存在しないオブジェクトを作成
        var clip = new AnimationClip();
        //アセットとして保存
        //AssetDatabaseで扱うパスはUnityプロジェクトから相対パスで指定できる
        AssetDatabase.CreateAsset(clip, "Assets/Animation/New AnimationClip.anim");
    }

    [MenuItem("Kashiwabara/Example47_2")]//エディタのメニューバーにあるKashiwabaraの項目の中にExample47_2という項目が作成される
    static void ChangeFrameRate()//Example47_2ボタンを押したらこの関数が実行される
    {
        //アセットパスからアセットをオブジェクトとしてロード
        var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/Animation/New AnimationClip.anim");
        clip.frameRate++;
        //アセットを最新に更新
        AssetDatabase.SaveAssets();
    }
}
#endif
