Shader "BASICxSHADER/PostEffect/DOF"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" { }
		_Radius ("Radius", Float) = 3
		_Intensity ("Intensity", Range(0, 1)) = 0.5
	}

	CGINCLUDE

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
		//float3 normal : NORMAL;
		float2 uv : TEXCOORD0;
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
		//float3 normal : NORMAL;
		float2 uv : TEXCOORD0;
	};

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
		//o.normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
		
		//Fog
		
		//o.posWorld = mul(unity_ObjectToWorld, v.vertex);

		o.uv = v.uv;

		return o;
	}

	ENDCG

	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			//消さない！
			//Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			//消さない！
			#pragma vertex vert
			//消さない！
			#pragma fragment frag

			#define PI 3.14159265359f
			#define INV_PI 0.31830988618f

			//Properties
			uniform half _Radius;
			uniform half _Intensity;
			uniform sampler2D _CameraDepthNormalsTexture;
			
			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				//DepthNormal
				half4 depthNormals = tex2D(_CameraDepthNormalsTexture, i.uv);
				half3 nn = half3((depthNormals.rg * 2.0 - 1.0) * 1.7777, 1.0);
				half g = 2.0 / dot(nn, nn);
				half3 normal = half3(nn.xy * g, - (g - 1.0));
				half depth = dot(depthNormals, half2(1.0, 1.0 / 255.0));

				//View Space
				float3 pos = float3(i.uv * 2.0 - 1.0, depth * _ProjectionParams.z);
				pos.xy = ((pos.xy - unity_CameraProjection._13_31) / unity_CameraProjection._11_22) * pos.z;

				//Hemisphere Distribution
				float gn = frac(52.9829189 * frac(dot(i.uv * _ScreenParams.xy, float2(0.06711056, 0.00583715))));
				float theta = gn * 2.0 * PI;
				float u = gn * 2.0 - 1.0;
				float3 rand = float3(float2(cos(theta), sin(theta)) * sqrt(1.0 - u * u), u);
				rand = faceforward(rand, -normal, rand);

				//Ambient Occlusion
				half ao = 0;
				int n = 4;
				for (int j = 0; j < n; j++)
				{
					float3 randPos = pos + rand * (float(j + 1) / n) * _Radius;
					float2 sampleUv = (mul(unity_CameraProjection, randPos).xy / randPos.z) * 0.5 + 0.5;
					half4 sampleDepthNormals = tex2D(_CameraDepthNormalsTexture, sampleUv);
					half sampleDepth = dot(sampleDepthNormals.ba, half2(1.0, 1.0 / 255.0));
					float3 samplePos = float3(sampleUv * 2.0 - 1.0, sampleDepth * _ProjectionParams.z);
					samplePos.xy = ((samplePos.xy - unity_CameraProjection._13_31) / unity_CameraProjection._11_22) * samplePos.z;
					float3 v = samplePos - pos;
					ao += max(dot(normal, v) - (_ProjectionParams.z / 65536.0), 0) / (dot(v, v) + 1e-4);
				}
				ao = max(1.0 - (ao / n) * _Intensity, 0);

				return fixed4(ao, ao, ao, 1);
			}

			ENDCG
		}

		//1:Bilateral Filter
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;
			uniform float2 _Direction;
			uniform sampler2D _CameraDepthNormalsTexture;

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				half4 color = tex2D(_MainTex, i.uv);

				//Bilateral Filter
				float weights[5] = {
					0.227027f, 0.1945946f, 0.1216216f, 0.054054f, 0.016216f
				};
				float2 offset = _Direction * _MainTex_TexelSize.xy;
				half depth = dot(tex2D(_CameraDepthNormalsTexture, i.uv).ba, half2(1.0, 1.0 / 255.0));
				half3 totalColor = color.rgb * weights[0];
				float totalWeight = weights[0];
				for (int j = 1; j < 5; j++)
				{
					float2 uv1 = i.uv + offset * j;
					float2 uv2 = i.uv - offset * j;
					half d1 = dot(tex2D(_CameraDepthNormalsTexture, uv1).ba, half2(1.0, 1.0 / 255.0));
					half d2 = dot(tex2D(_CameraDepthNormalsTexture, uv2).ba, half2(1.0, 1.0 / 255.0));
					half w1 = weights[j] * (1.0 - step(0.2, abs(d1 - depth) * _ProjectionParams.z));
					half w2 = weights[j] * (1.0 - step(0.2, abs(d2 - depth) * _ProjectionParams.z));
					totalColor += tex2D(_MainTex, uv1).rgb * w1 + tex2D(_MainTex, uv2).rgb * w2;
					totalWeight += w1 + w2;
				}

				color.rgb = totalColor / totalWeight;

				return color;
			}
			ENDCG
		}

		//2:SSAO
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform sampler2D _MainTex;
			uniform sampler2D _SSAOTex;

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 color = tex2D(_MainTex, i.uv);

				//SSAO
				color.rgb *= tex2D(_SSAOTex, i.uv).rgb;

				return color;
			}

			ENDCG
		}
	}
}
