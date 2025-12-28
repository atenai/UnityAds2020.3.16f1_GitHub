using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// スクリーン用のシェーダーを扱うため、Unity のカメラにはスクリプトとシェーダーを追加します。
/// 以下のスクリプトとシェーダーは、ステンシルバッファが 0 でないピクセルを暗くします。
///  RequireComponent 属性は、スクリプトがアタッチされているゲームオブジェクトに Camera コンポーネントが必要であることを示します。
///  ExecuteInEditMode 属性は、スクリプトがエディターモードでも実行されることを示します。
///  ImageEffectAllowedInSceneView 属性は、シーンビューでイメージエフェクトを許可します。
/// </summary>
[RequireComponent(typeof(Camera)), ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class ShadowVolumeStencil : MonoBehaviour
{
	public Material material;

	void Start()
	{
		//Shadow Volume
		var cmdBuffer = new CommandBuffer();
		cmdBuffer.Blit(null, BuiltinRenderTextureType.CameraTarget, material);
		GetComponent<Camera>().AddCommandBuffer(CameraEvent.BeforeImageEffects, cmdBuffer);
	}

	void Update()
	{

	}
}
