using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera)), ExecuteInEditMode]
public class LightCamera : MonoBehaviour
{
	void Update()
	{
		//_LightVPMatrix
		var camera = GetComponent<Camera>();
		var _LightVPMatrix = camera.projectionMatrix * camera.worldToCameraMatrix;
		Shader.SetGlobalMatrix("_LightVPMatrix", _LightVPMatrix);
	}
}
