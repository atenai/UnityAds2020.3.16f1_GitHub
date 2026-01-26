using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera)), ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class GaussianBlurImageEffect : MonoBehaviour
{
	public Material material;
	private int _Direction;

	void Awake()
	{
		_Direction = Shader.PropertyToID("_Direction");
	}

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		var rt1 = RenderTexture.GetTemporary(src.width / 2, src.height / 2);
		var rt2 = RenderTexture.GetTemporary(src.width / 2, src.height / 2);
		var h = new Vector2(1.0f, 0.0f);
		var v = new Vector2(0.0f, 1.0f);

		//Scale down
		Graphics.Blit(src, rt1);

		//Gaussian Blur
		for (int i = 0; i < 3; i++)
		{
			material.SetVector(_Direction, h);
			Graphics.Blit(rt1, rt2, material);
			material.SetVector(_Direction, v);
			Graphics.Blit(rt2, rt1, material);
		}

		//Scale up
		Graphics.Blit(rt1, dest);

		RenderTexture.ReleaseTemporary(rt2);
		RenderTexture.ReleaseTemporary(rt1);
	}
}
