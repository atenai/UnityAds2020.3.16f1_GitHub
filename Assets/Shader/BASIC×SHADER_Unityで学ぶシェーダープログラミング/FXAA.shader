Shader "BASICxSHADER/PostEffect/FXAA"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" { }
	}

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

			//------------------------------------------------------------------------
			// Fragment Shader
			//------------------------------------------------------------------------
			fixed4 frag(v2f i) : SV_Target
			{
				//Attenuation

				//Height Map

				//NormalMap

				//Vector
				//消さない！
				//half3 normal = normalize(i.normal);
				//消さない！
				//half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

				//Reflection

				//Dot
				//half NdotL = saturate(dot(normal, lightDir));

				//Fog
				//float fogCoord = saturate((i.posWorld.y - _MinHeight) / (_MaxHeight - _MinHeight));

				//Color Map

				//Gloss Map

				

				//fixed4 color = tex2D(_MainTex, i.uv);

				//Negaposi
				//color.rgb = 1.0 - color.rgb;

				//Grayscale
				//color.rgb = dot(color.rgb, half3(0.30, 0.59, 0.11));

				//Sepia
				//half y = dot(color.rgb, half3(0.30, 0.59, 0.11));
				//color.rgb = saturate(y + half3(0.19, -0.05, -0.22));

				//Threshold
				//half y = dot(color.rgb, half3(0.30, 0.59, 0.11));
				//color.rgb = step(_Threshold, y);

				//Mosaic
				//float2 scale = _MainTex_TexelSize.xy * _Scale;
				//float2 uv = (floor(i.uv / scale) + 0.5) * scale;
				//fixed4 color = tex2D(_MainTex, uv);

				//LED
				//float2 mask = abs(sin(i.uv / scale * PI));
				//color.rgb *= saturate(mask.x * mask.y * _Mask);

				//Noise
				//float rand = frac(sin(dot(i.uv, float2(12.9898, 78.233))) * 43758.5453);
				//color.rgb = lerp(color.rgb, color.rgb * rand, _Noise);

				//Scanline
				//float theta = i.uv.y * _MainTex_TexelSize.w;
				//float3 scanline = float2(sin(theta), cos(theta)).xyx * 0.5 + 0.5;
				//color.rgb = lerp(color.rgb, color.rgb * scanline, _Scanline);

				//Twirl
				//float2 uv = i.uv - 0.5;
				//float theta = (0.5 - length(uv)) * _Twirl;
				//float s = sin(theta);
				//float c = cos(theta);
				//uv = mul(float2x2(c, -s, s, c), uv) + 0.5;
				//fixed4 color = tex2D(_MainTex, uv);

				//Fisheye
				//float2 uv = i.uv * 2.0 - 1.0;
				//float d = length(uv);
				//float z = sqrt(1.0 - d * d);
				//float r = atan2(d, z) * INV_PI;
				//float theta = atan2(uv.y, uv.x);
				//uv = r * float2(cos(theta), sin(theta)) * _Fisheye + 0.5;

				//Mask
				//fixed4 color = tex2D(_MainTex, uv);
				//color.rgb *= step(d, 1.0);

				//Luminance
				//half3 luma = half3(0.3, 0.59, 0.11);
				//float4 offset = float4(_MainTex_TexelSize.xy, -_MainTex_TexelSize.xy);
				//half yNW = dot(tex2D(_MainTex, i.uv + offset.zy).rgb, luma);
				//half yN = dot(tex2D(_MainTex, i.uv + float2(0, offset.y)).rgb, luma);
				//half yNE = dot(tex2D(_MainTex, i.uv + offset.xy).rgb, luma);
				//half yW = dot(tex2D(_MainTex, i.uv + float2(offset.z, 0)).rgb, luma);
				//half yM = dot(color.rgb, luma);
				//half yE = dot(tex2D(_MainTex, i.uv + float2(offset.x, 0)).rgb, luma);
				//half ySW = dot(tex2D(_MainTex, i.uv + offset.zw).rgb, luma);
				//half yS = dot(tex2D(_MainTex, i.uv + float2(0, offset.w)).rgb, luma);
				//half ySE = dot(tex2D(_MainTex, i.uv + offset.xw).rgb, luma);

				//Sobel
				//half2 hv = half2((yNE - yNW) + (yE - yW) * 2.0 + (ySE - ySW), (yNW - ySW) + (yN - yS) * 2.0 + (yNE - ySE));
				//half sobel = sqrt(dot(hv, hv)) / yM;
				//color.rgb = 1.0 - sobel;

				//Kuwahara
				// int n = (_Radius + 1) * (_Radius + 1);
				// half3 m[4] = {
				// 	half3(0, 0, 0), half3(0, 0, 0), half3(0, 0, 0), half3(0, 0, 0)
				// };
				// half3 s[4] = {
				// 	half3(0, 0, 0), half3(0, 0, 0), half3(0, 0, 0), half3(0, 0, 0)
				// };
				// for (int v = 0; v <= _Radius; v++)
				// {
				// 	for (int h = 0; h <= _Radius; h++)
				// 	{
				// 		half3 c = tex2D(_MainTex, i.uv + _MainTex_TexelSize * float2(h - _Radius, v)).rgb;
				// 		m[0] += c;
				// 		s[0] += c * c;
				// 		c = tex2D(_MainTex, i.uv + _MainTex_TexelSize.xy * float2(h, v)).rgb;
				// 		m[1] += c;
				// 		s[1] += c * c;
				// 		c = tex2D(_MainTex, i.uv + _MainTex_TexelSize.xy * float2(h - _Radius, v - _Radius)).rgb;
				// 		m[2] += c;
				// 		s[2] += c * c;
				// 		c = tex2D(_MainTex, i.uv + _MainTex_TexelSize.xy * float2(h, v - _Radius)).rgb;
				// 		m[3] += c;
				// 		s[3] += c * c;
				// 	}
				// }
				// m[0] /= n;
				// s[0] = s[0] / n - m[0] * m[0];
				// m[1] /= n;
				// s[1] = s[1] / n - m[1] * m[1];
				// m[2] /= n;
				// s[2] = s[2] / n - m[2] * m[2];
				// m[3] /= n;
				// s[3] = s[3] / n - m[3] * m[3];

				//Luminance
				half3 luma = half3(0.3, 0.59, 0.11);
				// half y[4];
				// y[0] = dot(s[0], luma);
				// y[1] = dot(s[1], luma);
				// y[2] = dot(s[2], luma);
				// y[3] = dot(s[3], luma);
				// half yMin = min(min(y[0], y[1]), min(y[2], y[3]));

				// //Color
				// //fixed4 color = fixed4(NdotL, NdotL, NdotL, 1.0);
				// //color.rgb = lerp(unity_FogColor.rgb, color.rgb, fogCoord);

				// fixed4 color = fixed4(m[0], 1.0);
				// color.rgb = lerp(color.rgb, m[1], step(y[1], yMin));
				// color.rgb = lerp(color.rgb, m[2], step(y[2], yMin));
				// color.rgb = lerp(color.rgb, m[3], step(y[3], yMin));

				float4 offset = float4(_MainTex_TexelSize.xy, -_MainTex_TexelSize.xy) * 0.5;
				half yNW = dot(tex2D(_MainTex, i.uv + offset.zy).rgb, luma);
				half yNE = dot(tex2D(_MainTex, i.uv + offset.xy).rgb, luma);
				half ySW = dot(tex2D(_MainTex, i.uv + offset.zw).rgb, luma);
				half ySE = dot(tex2D(_MainTex, i.uv + offset.xw).rgb, luma);
				yNE += 1e-4;

				//Edge
				float2 dir1 = float2(-ySW + ySE - (yNW + yNE), yNW + ySW - (yNE + ySE));//なんか透明になってカッコイイ
				//float2 dir1 = float2(ySW + ySE - (yNW + yNE), yNW + ySW - (yNE + ySE));//こっちが正しい
				dir1 = normalize(dir1);
				float2 dir2 = clamp(dir1 / (min(abs(dir1.x), abs(dir1.y)) * 8.0), -2.0, 2.0);
				dir1 += _MainTex_TexelSize.xy * 0.5;
				dir2 *= _MainTex_TexelSize.xy * 2.0;

				//Gradient
				fixed3 rgbP1 = tex2D(_MainTex, i.uv + dir1).rgb;
				fixed3 rgbN1 = tex2D(_MainTex, i.uv - dir1).rgb;
				fixed3 rgbP2 = tex2D(_MainTex, i.uv + dir2).rgb;
				fixed3 rgbN2 = tex2D(_MainTex, i.uv - dir2).rgb;
				fixed3 rgbA = (rgbP1 + rgbN1) * 0.5;
				fixed3 rgbB = (rgbP1 + rgbN1 + rgbP2 + rgbN2) * 0.25;

				//Color
				half yB = dot(rgbB, luma);
				half yMin = min(min(yNW, yNE), min(ySW, ySE));
				half yMax = max(max(yNW, yNE), max(ySW, ySE));
				fixed4 color = fixed4((yB < yMin || yB > yMax) ? rgbA : rgbB, 1.0);

				return color;
			}

			ENDCG
		}
	}
}
