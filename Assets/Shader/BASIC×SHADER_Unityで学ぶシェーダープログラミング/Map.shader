Shader "BASICxSHADER/Shadow/Map"
{
	Properties
	{
		_ShadowMap ("ShadowMap", 2D) = "" { }
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
		
		//1
		//0:Shade
		Pass
		{
			//2
			//消さない！
			Tags { "LightMode" = "ForwardBase" }

			//3
			CGPROGRAM
			//消さない！
			#pragma vertex vert
			//消さない！
			#pragma fragment frag

			//Properties
			uniform sampler2D _ShadowMap;
			uniform half _Intensity;
			uniform float4x4 _LightVPMatrix;

			//Vertex Input
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
				//消さない！
				float4 vertex : POSITION;
				//消さない！
				float3 normal : NORMAL;
			};

			//Vertex to Fragment
			//頂点シェーダー出力とフラグメントシェーダー入力の代表的なセマンティクスは、次のとおりです。SV_POSITION は必須です。
			//セマンティクス 説明
			//SV_POSITION 頂点位置
			//TEXCOORD* 座標
			//COLOR* 色
			//そのほか、シェーダーモデルが 3.0 以降であれば、VPOS や VFACE が使用できます。
			struct v2f
			{
				//消さない！
				float4 pos : SV_POSITION;
				//消さない！
				float3 normal : NORMAL;
				float4 shadowCoord : TEXCOORD0;
			};

			//4
			//------------------------------------------------------------------------
			// Vertex Shader
			//------------------------------------------------------------------------
			//↑（Vertex Input）で定義した構造体を引数に取る
			v2f vert(appdata v)
			{
				//Vector

				//↑（Vertex to Fragment）で定義した構造体を宣言
				//消さない！
				v2f o;

				//頂点変換
				//UnityObjectToClipPos()は、ワールド・ビュー・プロジェクション変換を頂点に適用します。
				//この計算はmul(UNITY_MATRIX_MVP, v.vertex)と同等ですが、コンパイル時に置換されるため、本書ではUnityObjectToClipPos()で統一します。
				//o.posは↑のv2fのSV_POSITIONセマンティクスに対応
				//v.vertexは↑のappdataのPOSITIONセマンティクスに対応
				//消さない！
				o.pos = UnityObjectToClipPos(v.vertex);

				//法線ベクトル
				//ライティングに必要な法線ベクトル (ワールド座標系) は、NORMALセマンティクスの法線ベクトル (ローカル座標系) を変換して求めます。
				//ただし、法線の情報は「向き」なので、頂点と同じ変換行列が使えません。
				//法線の変換行列には、「平行移動成分の除去」「同じ回転成分」「逆の拡大縮小成分」が必要です。
				//平行移動成分は、3x3 行列にすれば除去できる。
				//回転成分は、直交行列なので転置行列と逆行列が等しい。
				//拡大縮小成分は、対称行列なので転置行列と自身が等しい。
				//これらの性質を考えると、「変換行列の逆行列の転置行列」の 3x3 成分は都合のよい行列です。
				//逆転置により、回転成分が元に戻り、拡大縮小成分だけが逆になります。
				//unity_WorldToObject は、ワールド変換の逆行列 mul() の引数を入れ替えて、転置行列として計算します。
				//o.normalは↑のv2fのNORMALセマンティクスに対応
				//v.normalは↑のappdataのNORMALセマンティクスに対応
				//mul()は行列とベクトルの乗算
				//normalize()は正規化
				//消さない！
				o.normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
				
				//Shadow Map
				float4 posShadow = mul(_LightVPMatrix, mul(unity_ObjectToWorld, v.vertex));
				o.shadowCoord = float4(posShadow.xyz * 0.5 + 0.5, posShadow.w);

				return o;
			}

			//5
			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			//↑（Vertex to Fragment）で定義した構造体を引数に取る
			fixed4 frag(v2f i) : SV_Target
			{
				//Attenuation

				//Height Map

				//NormalMap

				//Vector
				//消さない！
				half3 normal = normalize(i.normal);
				
				half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

				//Reflection
				
				//Dot
				half NdotL = saturate(dot(normal, lightDir));

				//Color Map

				//Gloss Map

				//Shadow Map
				half depth = tex2D(_ShadowMap, i.shadowCoord.xy).r;
				#if defined(UNITY_REVERSED_Z)
					depth = 1.0 - depth;
				#endif
				fixed shadow = 1.0 - step(depth, i.shadowCoord.z - 1e-4) * _Intensity;

				//Color

				fixed4 color = fixed4(NdotL, NdotL, NdotL, 1.0);
				color.rgb *= shadow;
				return color;
			}

			//6
			ENDCG
		}

		//1:Shadow
		Pass
		{
			Tags { "LightMode" = "ForwardBase" }
			Cull Off
			ZWrite Off
			Offset 1, 1
			ColorMask 0
			Stencil
			{
				Comp Always
				ZFailFront DecrWrap
				ZFailBack IncrWrap
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform float _Volume;

			//------------------------------------------------------------------------
			// Vertex Shader
			//------------------------------------------------------------------------
			float4 vert(float4 vertex : POSITION, float3 normal : NORMAL) : SV_POSITION
			{
				//Shadow Projection
				float4 posWorld = mul(unity_ObjectToWorld, vertex);
				normal = normalize(mul(normal, unity_WorldToObject).xyz);
				half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				posWorld.xyz += -lightDir * step(dot(normal, lightDir), 0) * _Volume;

				return mul(UNITY_MATRIX_VP, posWorld);
			}

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag() : SV_Target
			{
				return fixed4(0, 0, 0, 0);
			}
			ENDCG
		}
	}
}
