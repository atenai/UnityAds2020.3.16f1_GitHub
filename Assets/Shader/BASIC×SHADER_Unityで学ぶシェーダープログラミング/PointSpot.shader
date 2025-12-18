Shader "BASICxSHADER/Lighting/PointSpot"
{
	Properties
	{
		_DiffuseColor ("Diffuse Color", Color) = (1, 1, 1, 1)
	}

	SubShader
	{
		CGINCLUDE

		// Properties
		uniform fixed4 _LightColor0;
		uniform fixed4 _DiffuseColor;

		// Vertex Input
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
			float3 normal : NORMAL;
		};

		// Vertex to Fragment
		//頂点シェーダー出力とフラグメントシェーダー入力の代表的なセマンティクスは、次のとおりです。SV_POSITION は必須です。
		//セマンティクス 説明
		//SV_POSITION 頂点位置
		//TEXCOORD* 座標
		//COLOR* 色
		//そのほか、シェーダーモデルが 3.0 以降であれば、VPOS や VFACE が使用できます。
		struct v2f
		{
			float4 pos : SV_POSITION;
			float3 normal : NORMAL;
			float4 posWorld : TEXCOORD0;
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

			// Vector
			//法線ベクトル
			//ライティングに必要な法線ベクトル (ワールド座標系) は、NORMAL セマンティクスの法線ベクトル (ローカル座標系) を変換して求めます。
			//ただし、法線の情報は「向き」なので、頂点と同じ変換行列が使えません。法線の変換行列には、「平行移動成分の除去」「同じ回転成分」「逆の拡大縮小成分」が必要です。
			//平行移動成分は、3x3 行列にすれば除去できる。回転成分は、直交行列なので転置行列と逆行列が等しい。拡大縮小成分は、対称行列なので転置行列と自身が等しい。
			//これらの性質を考えると、「変換行列の逆行列の転置行列」の 3x3 成分は都合のよい行列です。逆転置により、回転成分が元に戻り、拡大縮小成分だけが逆になります。
			//unity_WorldToObject は、ワールド変換の逆行列 mul() の引数を入れ替えて、転置行列として計算します。
			o.normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
			o.posWorld = mul(unity_ObjectToWorld, v.vertex);

			return o;
		}

		//------------------------------------------------------------------------
		// Fragment Shader
		//------------------------------------------------------------------------
		fixed4 frag(v2f i) : SV_Target
		{
			//Attenuation
			float3 toLight = _WorldSpaceLightPos0.xyz - i.posWorld.xyz * _WorldSpaceLightPos0.w;
			half atten = lerp(1.0, 1.0 / dot(toLight, toLight), _WorldSpaceLightPos0.w);

			//Vector
			half3 normal = normalize(i.normal);
			half3 lightDir = normalize(toLight);

			//Dot
			half NdotL = saturate(dot(normal, lightDir));
			
			//Color
			fixed3 ambient = lerp(UNITY_LIGHTMODEL_AMBIENT.rgb * _DiffuseColor.rgb, 0, _WorldSpaceLightPos0.w);
			fixed3 diffuse = _LightColor0.rgb * _DiffuseColor.rgb * NdotL * atten;
			fixed4 color = fixed4(ambient + diffuse, 1.0);

			//環境光
			return color;
		}

		ENDCG

		//0:ForwardBase
		Pass
		{
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}

		//1:ForwarAdd
		Pass
		{
			Tags { "LightMode" = "ForwardAdd" }
			Blend One One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
	}
}
