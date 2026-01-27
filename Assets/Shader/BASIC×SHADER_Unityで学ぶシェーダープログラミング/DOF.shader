Shader "BASICxSHADER/PostEffect/DOF"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" { }
		_Radius ("Radius", Float) = 3
		_Depth ("Depth", Range(0, 1)) = 0.1
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
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;
			uniform half2 _Direction;
			uniform half _Radius;
			
			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 color = tex2D(_MainTex, i.uv);

				//GaussianBlur
				float weights[5] = {
					0.227027f, 0.1945946f, 0.1216216f, 0.054054f, 0.016216f
				};
				float2 offset = _Direction * _MainTex_TexelSize.xy * _Radius;
				color.rgb *= weights[0];
				color.rgb += tex2D(_MainTex, i.uv + offset).rgb * weights[1];
				color.rgb += tex2D(_MainTex, i.uv - offset).rgb * weights[1];
				color.rgb += tex2D(_MainTex, i.uv + offset * 2.0).rgb * weights[2];
				color.rgb += tex2D(_MainTex, i.uv - offset * 2.0).rgb * weights[2];
				color.rgb += tex2D(_MainTex, i.uv + offset * 3.0).rgb * weights[3];
				color.rgb += tex2D(_MainTex, i.uv - offset * 3.0).rgb * weights[3];
				color.rgb += tex2D(_MainTex, i.uv + offset * 4.0).rgb * weights[4];
				color.rgb += tex2D(_MainTex, i.uv - offset * 4.0).rgb * weights[4];

				return color;
			}

			ENDCG
		}

		//1:DOF
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform sampler2D _MainTex;
			uniform sampler2D _BlurTex;
			uniform float _Depth;
			uniform sampler2D _CameraDepthTexture;

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				half4 color = tex2D(_MainTex, i.uv);

				//DOF
				float depth = tex2D(_CameraDepthTexture, i.uv).r;
				depth = 1.0 / (_ZBufferParams.x * depth + _ZBufferParams.y) * _Depth;
				float blur = saturate(depth * _ProjectionParams.z);
				color.rgb = lerp(color.rgb, tex2D(_BlurTex, i.uv).rgb, blur);

				return color;
			}
			ENDCG
		}
	}
}
