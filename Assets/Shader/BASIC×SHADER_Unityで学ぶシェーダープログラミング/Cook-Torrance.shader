Shader "BASICxSHADER/Lighting/Cook-Torrance"
{
	Properties
	{
		_Albedo ("Albedo", Color) = (1, 1, 1, 1)
		_Roughness ("Roughness", Range(0, 1)) = 0.5
		_Metallic ("Metallic", Range(0, 1)) = 0.5
	}

	SubShader
	{
		Pass
		{
			//ディレクショナルライト
			//Unity エディタのディレクショナルライトは、LightMode に ForwardBase を設定したパスから参照できます。本節では、_LightColor0 と _WorldSpaceLightPos0 を利用します。 ForwardBase を設定したパスの _WorldSpaceLightPos0 には、光源の「位置」ではなく「向き」が入ります。リアルタイムレンダリングのディレクショナルライトは、「無限遠に位置する」と考えるため、距離の概念はありません。
			Tags { "LightMode" = "ForwardBase" }

			CGPROGRAM//Cg によるシェーダーコードは、CGPROGRAM と ENDCG の間に記述します。HLSL には HLSLPROGRAM と ENDHLSL、GLSL には GLSLPROGRAM と ENDGLSL が用意されています。
			#pragma vertex vert//「頂点シェーダーの実装」
			#pragma fragment frag//「フラグメントシェーダーの実装」です。
			
			#define PI 3.14159265359f

			// Properties
			uniform fixed4 _LightColor0;
			uniform fixed4 _Albedo;
			uniform half _Roughness;
			uniform half _Metallic;

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
				float4 normal : TEXCOORD0;
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
			}

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				half3 normal = normalize(i.normal);
				half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.posWorld);
				half3 halfDir = normalize(lightDir + viewDir);

				//Dot
				half NdotL = saturate(dot(normal, lightDir));
				half NdotV = saturate(dot(normal, viewDir));
				half NdotH = saturate(dot(normal, halfDir));
				half LdotH = saturate(dot(lightDir, halfDir));
				half NdotHSqr = NdotH * NdotH;

				//Roughness
				half roughness = _Roughness * _Roughness;
				half roughnessSqr = roughness * roughness;

				//Oren-Nayar
				half A = 1.0 - 0.5 * (roughnessSqr / (roughnessSqr + 0.33));
				half B = 0.45 * (roughnessSqr / (roughnessSqr + 0.09));
				half C = saturate(dot(normalize(viewDir - normal * NdotV), normalize(lightDir - normal * NdotL)));
				half angleL = acos(NdotL);
				half angleV = acos(NdotV);
				half alpha = max(angleL, angleV);
				half beta = min(angleL, angleV);
				fixed3 diffuse = _Albedo.rgb * (A + B * C * sin(alpha) * tan(beta)) * _LightColor0.rgb * NdotL;

				//Cook-Torrance
				half D = roughnessSqr / (PI * pow(NdotHSqr * (roughnessSqr - 1.0) + 1.0, 2.0));
				half k = roughness * 0.5;
				half gl = NdotL / (NdotL * (1.0 - k) + k);
				half gv = NdotV / (NdotV * (1.0 - k) + k);
				half G = gl * gv;
				half F = _Metallic + (1.0 - _Metallic) * pow(1.0 - LdotH, 5.0);
				fixed3 specular = saturate((D * G * F) / (4.0 * NdotV)) * PI * _LightColor0.rgb;

				//Color
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * _Albedo.rgb;
				fixed4 color = fixed4(ambient + lerp(diffuse, specular, _Metallic), 1.0);

				//環境光
				return color;
			}

			ENDCG
		}
	}
}
