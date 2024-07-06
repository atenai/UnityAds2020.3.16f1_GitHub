#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;
using System.Linq;
using UnityEditor.SearchService;

public class NewBehaviourScript17
{
    [InitializeOnLoadMethod]
    static void CheckPlaymodeState()
    {
        EditorApplication.playmodeStateChanged += () =>
        {
            if (EditorApplication.isPaused == true)
            {
                //一時停止中
            }

            if (EditorApplication.isPlaying == true)
            {
                //再生中
            }

            if (EditorApplication.isPlayingOrWillChangePlaymode == true)
            {
                //再生中または再生ボタンを押した直後
                //コンパイルやさまざまな処理が走っている状態
                //また、再生をやめるときにも呼び出される
            }
        };
    }
}
#endif