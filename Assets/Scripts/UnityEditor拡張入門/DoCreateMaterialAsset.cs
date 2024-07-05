#if UNITY_EDITOR 
using UnityEngine;
using UnityEditor.ProjectWindowCallback;
using UnityEditor;

public class DoCreateMaterialAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var mat = (Material)EditorUtility.InstanceIDToObject(instanceId);

        //強制的にマテリアルを赤色にする
        mat.color = Color.red;

        AssetDatabase.CreateAsset(mat, pathName);
        AssetDatabase.ImportAsset(pathName);
        ProjectWindowUtil.ShowCreatedAsset(mat);
    }
}
#endif