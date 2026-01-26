using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera)), ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class MotionBlurImageEffect : MonoBehaviour
{
	public Material material;
	private RenderTexture accumBuffer;

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		//MotionBlur
		if (accumBuffer == null)
		{
			accumBuffer = new RenderTexture(src.width, src.height, 0);
			Graphics.Blit(src, accumBuffer);
		}
		accumBuffer.MarkRestoreExpected();
		if (material != null)
		{
			Graphics.Blit(src, accumBuffer, material);
		}
		Graphics.Blit(accumBuffer, dest);
	}
}
