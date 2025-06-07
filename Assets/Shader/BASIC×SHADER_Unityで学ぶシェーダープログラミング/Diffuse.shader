Shader "BASICxSHADER/Lighting/Diffuse"
{
    Properties{
		_DiffuseColor("Diffuse Color",Color) = (1,1,1,1)
	}

	SubShader{
		Pass{
			//ディレクショナルライト
			//Unity エディタのディレクショナルライトは、LightMode に ForwardBase を設定したパスから参照できます。本節では、_LightColor0 と _WorldSpaceLightPos0 を利用します。 ForwardBase を設定したパスの _WorldSpaceLightPos0 には、光源の「位置」ではなく「向き」が入ります。リアルタイムレンダリングのディレクショナルライトは、「無限遠に位置する」と考えるため、距離の概念はありません。
			Tags{"LightMode" = "ForwardBase"}

			CGPROGRAM//Cg によるシェーダーコードは、CGPROGRAM と ENDCG の間に記述します。HLSL には HLSLPROGRAM と ENDHLSL、GLSL には GLSLPROGRAM と ENDGLSL が用意されています。
            #pragma vertex vert//「頂点シェーダーの実装」
            #pragma fragment frag//「フラグメントシェーダーの実装」です。
			
			// Properties
			uniform fixed4 _LightColor0;
			uniform fixed4 _DiffuseColor;

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

			//頂点シェーダー出力とフラグメントシェーダー入力の代表的なセマンティクスは、次のとおりです。SV_POSITION は必須です。 
			//セマンティクス 説明 
			//SV_POSITION 頂点位置 
			//TEXCOORD* 座標 
			//COLOR* 色 
			//そのほか、シェーダーモデルが 3.0 以降であれば、VPOS や VFACE が使用できます。
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

				// Dot
				//内積
				//内積は角度が 90° を超えると負の値になるため、saturate() で下限を 0 にします。
				half NDotL = saturate(dot(normal, lightDir));

				// Color
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * _DiffuseColor.rgb;
				//Lambertian 反射
				//_LightColor0 を放射照度、_DiffuseColor を反射係数として、拡散反射光を計算します。
				fixed3 diffuse = _LightColor0.rgb * _DiffuseColor.rgb * NDotL;
				o.color = fixed4(ambient + diffuse, 1.0);

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
