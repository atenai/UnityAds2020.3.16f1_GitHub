Shader "BASICxSHADER/Lighting/Specular"
{
    Properties{
		_DiffuseColor("Diffuse Color",Color) = (1,1,1,1)
		_SpecularColor("Specular Color",Color) = (1,1,1,1)
		_Shininess("Shininess",Float) = 20
	}

	SubShader{
		Pass{
			Tags{"LightMode" = "ForwardBase"}

			CGPROGRAM//Cg によるシェーダーコードは、CGPROGRAM と ENDCG の間に記述します。HLSL には HLSLPROGRAM と ENDHLSL、GLSL には GLSLPROGRAM と ENDGLSL が用意されています。
            #pragma vertex vert//「頂点シェーダーの実装」
            #pragma fragment frag//「フラグメントシェーダーの実装」です。
			
			// Properties
			uniform fixed4 _LightColor0;
			uniform fixed4 _DiffuseColor;
			uniform fixed4 _SpecularColor;
			uniform half _Shininess;

			// Vertex Input
			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			// Vertex to Fragment
			struct v2f
			{
				float4 pos : SV_POSITION;
				fixed4 color : COLOR0;
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
				half3 normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
				half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				float4 posWorld = mul(unity_ObjectToWorld, v.vertex);
				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - posWorld.xyz);
				half3 reflectDir = reflect(-lightDir, normal);

				// Dot
				half NdotL = saturate(dot(normal, lightDir));
				half RdotV = saturate(dot(reflectDir, viewDir));

				// Color
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * _DiffuseColor.rgb;
				fixed3 diffuse = _LightColor0.rgb * _DiffuseColor.rgb * NdotL;
				fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(RdotV, _Shininess);
				o.color = fixed4(ambient + diffuse + specular, 1.0);

				return o;
			}

			//------------------------------------------------------------------------
	       	// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target 
			{
				//環境光
				return i.color;
			}

			ENDCG
		}
	}
}
