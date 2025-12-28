Shader "BASICxSHADER/Shadow/VolumeStencil"
{
	Properties
	{
		_Intensity ("Intensity", Range(0, 1)) = 0.5
	}

	SubShader
	{
		// 処理の書く流れの例
		// //1
		// Pass
		// {
		// 	//2
		// 	Tags { "LightMode" = "ForwardBase" }

		// 	//3
		// 	CGPROGRAM
		// 	#pragma vertex vert
		// 	#pragma fragment frag

		// 	//4
		// 	//------------------------------------------------------------------------
		// 	// Vertex Shader
		// 	//------------------------------------------------------------------------
		// 	v2f vert()
		// 	{

		// 	}

		// 	//5
		// 	//------------------------------------------------------------------------
		// 	// Fragment Shader
		// 	//------------------------------------------------------------------------
		// 	fixed4 frag() : SV_Target { }

		// 	//6
		// 	ENDCG
		// }

		Cull Off // 背面カリング無効
		ZWrite Off // デプス書き込み無効
		ZTest Always // デプステスト常に合格

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			Stencil
			{
				Ref 0
				Comp NotEqual
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform half _Intensity;

			//------------------------------------------------------------------------
			// Vertex Shader
			//------------------------------------------------------------------------
			float4 vert(float4 vertex : POSITION) : SV_POSITION
			{
				return UnityObjectToClipPos(vertex);
			}

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag() : SV_Target
			{
				return fixed4(0, 0, 0, _Intensity);
			}
			ENDCG
		}
	}
}
