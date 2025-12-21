Shader "BASICxSHADER/Texturing/Gloss"
{
	Properties
	{
		_MainTex ("Main Texture", 2D) = "white" { }
		_SpecTex ("Specular Texture", 2D) = "black" { }
		_Shininess ("Shininess", Float) = 20
	}

	SubShader
	{
		Pass
		{
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform fixed4 _LightColor0;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform sampler2D _SpecTex;
			uniform float4 _SpecTex_ST;
			uniform half _Shininess;

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
				float4 vertex : POSITION;
				float3 normal : NORMAL;
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
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
				float4 posWorld : TEXCOORD1;
			};

			//------------------------------------------------------------------------
			// Vertex Shader
			//------------------------------------------------------------------------
			//↑（Vertex Input）で定義した構造体を引数に取る
			v2f vert(appdata v)
			{
				//↑（Vertex to Fragment）で定義した構造体を宣言
				v2f o;

				//頂点変換
				//UnityObjectToClipPos() は、ワールド・ビュー・プロジェクション変換を頂点に適用します。
				//この計算は mul(UNITY_MATRIX_MVP, v.vertex) と同等ですが、コンパイル時に置換されるため、本書では UnityObjectToClipPos() で統一します。
				//o.posは↑のv2fのSV_POSITIONセマンティクスに対応
				//v.vertexは↑のappdataのPOSITIONセマンティクスに対応
				o.pos = UnityObjectToClipPos(v.vertex);

				//Vector
				//法線ベクトル
				//ライティングに必要な法線ベクトル (ワールド座標系) は、NORMAL セマンティクスの法線ベクトル (ローカル座標系) を変換して求めます。
				//ただし、法線の情報は「向き」なので、頂点と同じ変換行列が使えません。法線の変換行列には、「平行移動成分の除去」「同じ回転成分」「逆の拡大縮小成分」が必要です。
				//平行移動成分は、3x3 行列にすれば除去できる。回転成分は、直交行列なので転置行列と逆行列が等しい。
				//拡大縮小成分は、対称行列なので転置行列と自身が等しい。
				//これらの性質を考えると、「変換行列の逆行列の転置行列」の 3x3 成分は都合のよい行列です。
				//逆転置により、回転成分が元に戻り、拡大縮小成分だけが逆になります。
				//unity_WorldToObject は、ワールド変換の逆行列 mul() の引数を入れ替えて、転置行列として計算します。
				//o.normalは↑のv2fのNORMALセマンティクスに対応
				//v.normalは↑のappdataのNORMALセマンティクスに対応
				//mul()は行列とベクトルの乗算
				//normalize()は正規化
				o.normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
				
				o.uv = v.uv;

				o.posWorld = mul(unity_ObjectToWorld, v.vertex);

				return o;
			}

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				//Attenuation

				//Vector
				half3 normal = normalize(i.normal);
				half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.posWorld);
				half3 halfDir = normalize(lightDir + viewDir);

				//Dot
				half NdotL = saturate(dot(normal, lightDir));
				half NdotH = saturate(dot(normal, halfDir));

				//Color Map
				fixed4 mainTex = tex2D(_MainTex, i.uv * _MainTex_ST.xy + _MainTex_ST.zw);
				fixed3 diffuse = _LightColor0.rgb * mainTex.rgb * NdotL;
				
				//Gloss Map
				fixed4 specTex = tex2D(_SpecTex, i.uv * _SpecTex_ST.xy + _SpecTex_ST.zw);
				fixed3 specular = _LightColor0.rgb * specTex.rgb * pow(NdotH, _Shininess) * specTex.a;

				//Color
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * mainTex.rgb;
				fixed4 color = fixed4(ambient + diffuse + specular, 1.0);

				//環境光
				return color;
			}

			ENDCG
		}
	}
}
