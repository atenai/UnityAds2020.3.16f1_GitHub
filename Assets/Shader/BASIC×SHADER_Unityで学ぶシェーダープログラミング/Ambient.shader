Shader "BASICxSHADER/Lighting/Ambient"
{
    SubShader
    {
        Pass{
            CGPROGRAM//Cg によるシェーダーコードは、CGPROGRAM と ENDCG の間に記述します。HLSL には HLSLPROGRAM と ENDHLSL、GLSL には GLSLPROGRAM と ENDGLSL が用意されています。
            #pragma vertex vert//「頂点シェーダーの実装」
            #pragma fragment frag//「フラグメントシェーダーの実装」です。

            //頂点シェーダー入力の代表的なセマンティクスは、次のとおりです。POSITION は必須です。 
			//セマンティクス 説明 
			//POSITION 頂点位置 
			//NORMAL 法線 
			//TANGENT 接線 
			//TEXCOORD* テクスチャ座標 
			//COLOR* 頂点色
			//そのほか、シェーダーモデルが 3.5 以降であれば、SV_VertexID が使用できます。
			struct appdata 
			{
				float4 vertex : POSITION;
			};

			//頂点シェーダー出力とフラグメントシェーダー入力の代表的なセマンティクスは、次のとおりです。SV_POSITION は必須です。 
			//セマンティクス 説明 
			//SV_POSITION 頂点位置 
			//TEXCOORD* 座標 
			//COLOR* 色 
			//そのほか、シェーダーモデルが 3.0 以降であれば、VPOS や VFACE が使用できます。
			struct v2f 
			{
				float4 pos : SV_POSITION;
			};

			//------------------------------------------------------------------------
	        // Vertex Shader
    	    //------------------------------------------------------------------------
			v2f vert(appdata v) 
			{
				v2f o;
				//頂点変換
				//UnityObjectToClipPos() は、ワールド・ビュー・プロジェクション変換を頂点に適用します。この計算は mul(UNITY_MATRIX_MVP, v.vertex) と同等ですが、コンパイル時に置換されるため、本書では UnityObjectToClipPos() で統一します。
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}

			//------------------------------------------------------------------------
	       	// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target 
			{
				//環境光
				//UNITY_LIGHTMODEL_AMBIENT には、Unity エディタの「Environment」が反映されます。
				return UNITY_LIGHTMODEL_AMBIENT;
			}

			ENDCG
        }   
    }
}
