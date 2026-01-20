#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript1
{
	[MenuItem("Assets/CreateExampleAssetsMaterial1")]
	static void CreateExampleAssets()
	{
		var material = new Material(Shader.Find("Standard"));

		var instanceID = material.GetInstanceID();

		//マテリアルのアイコンを取得
		var icon = AssetPreview.GetMiniThumbnail(material);

		var endNameEditAction = ScriptableObject.CreateInstance<DoCreateMaterialAsset>();

		ProjectWindowUtil.StartNameEditingIfProjectWindowExists(instanceID, endNameEditAction, "New Material.mat", icon, "");
	}
}
#endif