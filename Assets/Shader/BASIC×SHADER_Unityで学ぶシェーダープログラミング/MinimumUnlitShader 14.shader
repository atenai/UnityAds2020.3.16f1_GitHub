//最小のシェーダーコードらしい
Shader "BASIC*SHADER/Unlit/MinimumUnlitShader14" //Shader 直後の名前がマテリアルの「Shader」選択項目に反映されます。

{
	Properties //Properties の中には、Unity エディタからシェーダーコードに渡したい情報を定義します。定義したプロパティは、マテリアルのインスペクタから GUI で編集が可能です。

	{
		//プロパティに必要な定義は、「プロパティ名」「インスペクタ表示名」「プロパティ型」「デフォルト値」です。プロパティ名は、慣習的に _ を接頭辞とします。
		_Name1 ("Display 1", Int) = 1
		_Name2 ("Display 2", Float) = 0.5
		_Name3 ("Display 3", Range(0, 1)) = 0.5
		_Name4 ("Display 4", Vector) = (0, 1, 0, 1)
		_Name5 ("Display 5", Color) = (1, 0, 0, 1)
		_Name6 ("Display 6", 2D) = "white" { }
		_Name7 ("Display 7", Cube) = "black" { }
		_Name8 ("Display 8", 3D) = "gray" { }
	}

	SubShader// SubShader の中には、レンダリングパスを定義します。複数の SubShader を列挙した場合、Unity は上から順番に試行して、実行可能な SubShader を適用します。

	{
		Tags { "Queue" = "Geometry"//Queue レンダリング順 (Background | Geometry | AlphaTest | Transparent | Overlay) "RenderType" = "Opaque"//RenderType グループ分類 (Opaque | Transparent | TransparentCutout | Background | Overlay)
			//DisableBatching バッチングの無効化 (True | False | LODFading)
			//ForceNoShadowCasting シャドウ投影の無効化 (True | False)
			//IgnoreProjector プロジェクタ投影の無効化 (True | False)
			//CanUseSpriteAtlas スプライトアトラスの使用 (True | False)
			//PreviewType インスペクタプレビュー (Sphere | Plane | Skybox) }

			LOD 200//LOD Level of Detail の閾値
			
			Pass// Pass の中には、レンダリング内容を定義します。複数の Pass を列挙した場合、レンダリングを複数回実行します。 そのほか、パスの再利用には UsePass、画面テクスチャの取得には GrabPass が用意されています。

			{
				Tags { "LightMode" = "ForwardBase"//LightMode ライティング (Always | ForwardBase | ForwardAdd | Deferred | ShadowCaster | MotionVectors)
					//PassFlags データ転送フラグ (OnlyDirectional)
					//RequireOptions 条件レンダリング (SoftVegetation) }

					Name "PassName"//Name パス名

					Cull Off//Cull カリング (Back | Front | Off)

					ZWrite Off//ZWrite デプスバッファ (On | Off)
					ZTest Always//ZTest デプステスト (Less | Greater | LEqual | GEqual | Equal | NotEqual | Always)
					Offset -1, -1//Offset デプスオフセット

					Blend SrcAlpha OneMinusSrcAlpha//Blend ブレンド係数 (One | Zero | SrcColor | SrcAlpha | DstColor | DstAlpha | OneMinusSrcColor | OneMinusSrcAlpha | OneMinusDstColor | OneMinusDstAlpha)
					BlendOp Add//BlendOp ブレンド操作 (Add | Sub | RevSub | Min | Max)
					//AlphaToMask Alpha to Coverage (On | Off)

					ColorMask RGB//ColorMask カラーチャンネルマスク ([RGBA] | 0)

					Stencil
					{
						Ref 1//Ref 比較値 (0–255)
						//ReadMask 読込みビットマスク (0–255)
						//WriteMask 書込みビットマスク (0–255)
						Comp Always//Comp, CompFront, CompBack 比較関数 (Greater | GEqual | Less | LEqual | Equal | NotEqual | Always | Never)
						Pass Replace//Pass, PassFront, PassBack Fail, FailFront, FailBack ZFail, ZFailFront, ZFailBack ステンシル操作 (Keep | Zero | Replace | IncrSat | DecrSat | Invert | IncrWrap | DecrWrap)

					}

					CGPROGRAM//Cg によるシェーダーコードは、CGPROGRAM と ENDCG の間に記述します。HLSL には HLSLPROGRAM と ENDHLSL、GLSL には GLSLPROGRAM と ENDGLSL が用意されています。
					#pragma vertex vert//「頂点シェーダーの実装」
					#pragma fragment frag//「フラグメントシェーダーの実装」です。

					float4 vert(float4 vertex : POSITION) : SV_POSITION
					{
						return UnityObjectToClipPos(vertex);
					}

					fixed4 frag() : SV_Target
					{
						return fixed4(1.0, 0, 0, 1.0);
					}

					//基本データ型は、次の 6 種類です。
					//型 説明
					//float 32 ビット浮動小数点数	//​・​ワールド空間の位置とテクスチャ座標には、float 型を使用してください。
					//half 16 ビット浮動小数点数	//​・​上記以外 (ベクトル、HDR カラーなど) には、half で始めます。必要なときだけ、増加します。
					//fixed 12 ビット固定小数点数	//​・​テクスチャデータのとても簡易な操作には、fixed を使用します。
					//int 32 ビット整数
					//bool 真理値
					//sampler* テクスチャサンプラ

					//定数の接尾辞は、次の 3 種類です。
					//接尾辞 型
					//f float
					//h half
					//x fixed
					//型が混在した計算式の昇格規則は、接尾辞の有無で異なります。明示的に接尾辞を付けない場合、C のような「暗黙的な昇格」が行われません。
					//(例)
					//halfvar * 2.0;   // halfvar * ((half)2.0)
					//halfvar * 2.0f;  // ((float)halfvar) * 2.0f

					//float, half, fixed に次元数 (1-4) を付与すると、ベクトル型になります。() はコンストラクタとして、ベクトルを生成します。
					//float3 vec = float3(1.0, 2.0, 3.0);

					//算術演算子が対応しているため、ベクトルの計算は簡潔に記述できます。
					//float2(1.0, 2.0) + float2(3.0, 4.0);  // float2(4.0, 6.0)
					//float3(1.0, 2.0, 3.0) * 2;            // float3(2.0, 4.0, 6.0)
					
					//スウィズル演算子が対応しているため、xyzw か rgba の記法で成分を抽出できます。また、スカラからベクトルを作成することもできます。
					//float3(1.0, 2.0, 3.0).y;    // 2.0
					//float3(1.0, 2.0, 3.0).zyx;  // float3(3.0, 2.0, 1.0)
					//2.xx;                       // float2(2, 2)

					//float, half, fixed に行数 (1-4) と列数 (1-4) を付与すると、行列型になります。() はコンストラクタとして、行列を生成します。
					//float3x3 mat = float3x3(1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0);

					//算術演算子が対応しているため、行列の計算は簡潔に記述できます。
					//float2x2(1.0, 2.0, 3.0, 4.0) + float2x2(5.0, 6.0, 7.0, 8.0);  // float2x2(6.0, 8.0, 10.0, 12.0)
					//float2x2(1.0, 2.0, 3.0, 4.0) * 2;                             // float2x2(2.0, 4.0, 6.0, 8.0)

					//スウィズル演算子が対応しているため、_m00 か _11 の記法で成分を抽出できます。m の有無で、インデックスの開始番号が異なります。
					//float2x2(1.0, 2.0, 3.0, 4.0)._m01;      // 2.0
					//float2x2(1.0, 2.0, 3.0, 4.0)._m00_m10;  // float2(1.0, 3.0)
					//float2x2(1.0, 2.0, 3.0, 4.0)._12;       // 2.0

					//配列の記述は C と同様です。ただし、Cg にはポインタがないため、ポインタ構文を使用できません。配列の代入は「参照」ではなく「複製」です。
					float3 arr[3] = {
						float3(1.0, 2.0, 3.0),
						float3(4.0, 5.0, 6.0),
						float3(7.0, 8.0, 9.0)
					};

					//構造体の記述は C++ と同様です。struct の記述に typedef が暗黙的に適用されます。
					struct vertices
					{
						float3 a;
						float4 b;
					};
					vertices v;

					//関数の記述は C++ と同様です。デフォルト値やオーバーロードに対応しています。
					// float proc(float x=1.0)
					// {
					// 	return x * 2.0;
					// }
					// proc();
					
					//制御文は if, for, while が対応しています。Cg の言語仕様にはありませんが、Unity では switch も使えます。
					// if (boolvar != true)
					// {
					// 	…
					// }
					// else
					// {
					// 	…
					// }
					
					// for (int i=0; i<3; i++)
					// {
					// 	…
					// }
					
					// while (boolvar)
					// {
					// 	…
					// }
					
					//プリプロセッサは #include, #if, #define など、C の標準規格に準拠しています。
					//UnityCG.cginc などのヘルパーは、Unity の CGInclude ディレクトリに配置されています。
					//このうち、HLSLSupport.cginc と UnityShaderVariables.cginc は、ShaderLab の CGPROGRAM で自動的に読み込まれます。
					//読み込みを除外したい場合は、HLSLPROGRAM に置き換えます。
					#include "UnityCG.cginc"

					//Unity はコンパイル時にマクロを定義します。
					//代表的なマクロとして、Unity バージョンの UNITY_VERSION、シェーダーモデルの SHADER_TARGET、プラットフォームの SHADER_API_D3D11 や
					//SHADER_API_GLCORE、シェーダーステージ の SHADER_STAGE_VERTEX や SHADER_STAGE_FRAGMENT などがあります。
					// #if defined(SHADER_API_MOBILE)
					// …
					// #endif
					
					//シェーダーステージは #pragma ディレクティブで指定します。vertex と fragment は必須です。
					//引数 説明
					//vertex 頂点シェーダー
					//fragment フラグメントシェーダー
					//geometry ジオメトリシェーダー
					//hull ハルシェーダー
					//domain ドメインシェーダー
					#pragma vertex vert
					#pragma fragment frag
					
					//シェーダーモデルは #pragma target で指定します。デフォルト値は 2.5 ですが、geometry の使用時は 4.0、hull や domain の使用時は 4.6 になります。
					//値 説明
					//2.0 DirectX 9 シェーダーモデル 2.0 相当
					//2.5 DirectX 9 シェーダーモデル 2.0 と 3.0 の中間
					//3.0 DirectX 9 シェーダーモデル 3.0 相当
					//3.5 (es3.0) OpenGL ES 3.0 相当
					//4.0 DirectX 11 シェーダーモデル 4.0 相当
					//4.5 (es3.1) OpenGL ES 3.1 相当
					//4.6 (gl4.1) OpenGL 4.1 相当
					//5.0 DirectX 11 シェーダーモデル 5.0 相当
					#pragma target 3.0

					//この例では、 : の後方に位置する POSITION, SV_POSITION, SV_Target が「セマンティクス」です。
					//セマンティクスは、入出力データの役割を GPU に伝えます。
					// float4 vert(float4 vertex : POSITION) : SV_POSITION
					// {
					// 	…
					// }
					
					// fixed4 frag(float4 pos : SV_POSITION) : SV_Target
					// {
					// 	…
					// }

					//入出力データは構造体で定義することが多く、上記の例を置き換えると次のようになります。
					// struct appdata
					// {
					// 	float4 vertex : POSITION;
					// };
					
					// struct v2f
					// {
					// 	float4 pos : SV_POSITION;
					// };
					
					// v2f vert(appdata v)
					// {
					// 	…
					// }
					
					// fixed4 frag(v2f i) : SV_Target
					// {
					// 	…
					// }
					
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
						float4 uv : TEXCOORD0;
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
						float4 uv : TEXCOORD0;
					};
					
					//通常、フラグメントシェーダー出力は、ピクセル色を示す SV_Target だけになります。
					//ただし、遅延シェーディングの場合は、G バッファとして SV_Target0, SV_Target1, SV_Target2, SV_Target3 を使用します。
					//そのほか、Z バッファの上書きには SV_Depth が使用できます。
					struct fragout
					{
						fixed4 color : SV_Target;
					};
					
					//ShaderLab の Properties に定義した情報は、Cg で「プロパティ名」を宣言すると参照できます。
					//宣言時の uniform 修飾子は、Unity では省略可能です。
					// Properties
					// {
					// 	_Name1 ("Display 1", Float) = 0.5
					// 	_Name2 ("Display 2", Color) = (1, 0, 0, 1)
					// 	_Name3 ("Display 3", 2D) = "white" {}
					// }
					// uniform float     _Name1;
					// uniform fixed4    _Name2;
					// uniform sampler2D _Name3;

					//テクスチャプロパティの追加情報は、プロパティ名に特定の接尾辞を付けて宣言すると参照できます。
					//接尾辞 値
					//_ST (Tiling X, Tiling Y, Offset X, Offset Y)
					//_TexelSize (1.0/width, 1.0/height, width, height)
					//そのほか、HDR デコードのための _HDR が用意されています。
					uniform sampler2D _Name3;
					uniform float4    _Name3_ST;
					uniform float4    _Name3_TexelSize;

					//Cg には、標準ライブラリ関数が用意されています。
					//各関数は GPU に最適化されるため、同等の記述は標準ライブラリ関数への置き換えを推奨します。

					//数学関数
					//関数 説明
					//abs(x) x の絶対値。
					//acos(x) x のアークコサイン。
					//all(x) x のすべての要素が 0 でない場合に true を返します。
					//any(x) x のいずれかの要素が 0 でない場合に true を返します。
					//asin(x) x のアークサイン。
					//atan(x) x のアークタンジェント。
					//atan2(y, x) y/x のアークタンジェント。
					//ceil(x) x 以上の最小の整数。
					//clamp(x, min, max) x を [min,max] の範囲に収めます。
					//cos(x) x のコサイン。
					//cosh(x) x のハイパーボリックコサイン。
					//cross(a, b) 3 次元ベクトル a と b の外積。
					//degress(x) x をラジアンから度へ変換。
					//determinant(M) 行列 M の行列式。
					//dot(a, b) ベクトル a と b の内積。
					//exp(x) x の e を底とする指数。
					//exp2(x) x の 2 を底とする指数。
					//floor(x) x 以下の最大の整数。
					//fmod(x, y) x/y の剰余。
					//frac(x) x の小数部。
					//frexp(x, out exp) x の仮数と指数。
					//isfinite(x) x が有限の場合に true を返します。
					//isinf(x) x が無限の場合に true を返します。
					//isnan(x) x が数値以外の場合に true を返します。
					//ldexp(x, exp) x * 2^exp。
					//lerp(x, y, w) x + w(y-x) に基づいた線形補間。
					//lit(NdotL, NdotH, m) (ambient, diffuse, specular, 1.0) のライティング係数ベクトル。
					//log(x) x の e を底とする対数。
					//log10(x) x の 10 を底とする対数。
					//log2(x) x の 2 を底とする対数。
					//max(x, y) x と y の最大値。
					//min(x, y) x と y の最小値。
					//modf(x, out ip) x の小数部と整数部。
					//mul(M, N) 行列 M と N の積。
					//noise(x) パーリンノイズ値。
					//pow(x, y) x^y。
					//radians(x) x を度からラジアンへ変換。
					//round(x) x に最も近い整数。
					//rsqrt(x) x の平方根の逆数。
					//saturate(x) x を [0,1] の範囲に収めます。
					//sign(x) x > 0 の場合は 1 を返します。x < 0 の場合は -1 を返します。それ以外の場合は 0 を返します。
					//sin(x) x のサイン。
					//sincos(x, out s, out c) x のサインとコサイン。
					//sinh(x) x のハイパーボリックサイン。
					//smoothstep(min, max, x) -2*( (x-min)/(max-min) )^3 + 3*( (x-min)/(max-min) )^2 に基づいたエルミート補間。
					//sqrt(x) x の平方根。
					//step(a, x) x < a の場合は 0 を返します。x >= a の場合は 1 を返します。
					//tan(x) x のタンジェント。
					//tanh(x) x のハイパーボリックタンジェント。
					//transpose(M) 行列 M の転置行列。
					//trunc(x) x の整数部。

					//幾何学関数
					//関数 説明
					//distance(pt1, pt2) ポイント pt1 と pt2 の間の距離。
					//faceforward(N, I, Ng) Ng と I の内積が 0 未満の場合は N を返します。それ以外の場合は -N を返します。
					//length(v) ベクトル v の長さ。
					//normalize(v) ベクトル v の正規化。
					//reflect(i, n) 入射方向 i と表面法線 n に対する反射ベクトル。
					//refract(i, n, eta) 入射方向 i と表面法線 n と屈折率 eta に対する屈折ベクトル。

					//テクスチャマッピング関数
					//関数 説明
					//tex1D(tex, s[, dsdx][, dsdy]) 1 次元の非射影。
					//tex1Dproj(tex, sq) 1 次元の射影。
					//tex2D(tex, s[, dsdx][, dsdy]) 2 次元の非射影。
					//tex2Dproj(tex, sq) 2 次元の射影。
					//tex3D(tex, s[, dsdx][, dsdy]) 3 次元の非射影。
					//tex3Dproj(tex, sq) 3 次元の射影。
					//texCUBE(tex, s[, dsdx][, dsdy]) キューブマップの非射影。
					//texCUBEproj(tex, sq) キューブマップの射影。
					//texRECT(tex, s[, dsdx][, dsdy]) 2 次元レクタングルの非射影。
					//texRECTproj(tex, sq) 2 次元レクタングルの射影。

					//導関数
					//関数 説明
					//ddx(a) スクリーン空間の x 座標に対する a の偏微分。
					//ddy(a) スクリーン空間の y 座標に対する a の偏微分。

					//その他
					//関数 説明
					//clip(x) x のいずれかの要素が 0 未満の場合に現在のピクセルを破棄します。

					//ベクトル
					//float2(x, y);

					//長さ
					//length(float2(x, y));

					//正規化
					//normalize(float2(x, y));

					//合成
					//float2(x1, y1) + float2(x2, y2);

					//実数倍
					//float2(x, y) * 2;

					//内積
					//dot(float2(x1, y1), float2(x2, y2));

					//単位ベクトル
					//float2 a = normalize(float2(x1, y1));
					//float2 b = normalize(float2(x2, y2));
					//dot(a, b);

					//外積
					//cross(float3(x1, y1, z1), float3(x2, y2, z2));

					//法線ベクトル
					//float3 a = float3(x1, y1, z1);
					//float3 b = float3(x2, y2, z2);
					//float3 c = cross(a, b);
					//normalize(c);

					//行列
					//float2x2(a, b, c, d);

					//和・差
					//float2x2(a1, b1, c1, d1) + float2x2(a2, b2, c2, d2);

					//積
					//mul(float2x2(a1, b1, c1, d1), float2x2(a2, b2, c2, d2));

					//単位行列
					//float2x2(1.0, 0, 1.0, 0);

					//逆行列
					//float2x2 m = float2x2(a, b, c, d);
					//1.0 / determinant(m) * float2x2(m._m11, -m._m01, -m._m10, m._m00);

					//転置行列
					//transpose(float2x2(a, b, c, d));
					
					//拡大縮小
					//float2x2 scale = float2x2(sx, 0, sy, 0);
					//mul(scale, float2(x, y));

					//回転
					//float2x2 rotation = float2x2(cos(t), -sin(t), sin(t), cos(t));
					//mul(rotation, float2(x, y));

					//平行移動
					//float3x3 translation = float3x3(1.0, 0, tx, 0, 1.0, ty, 0, 0, 1.0);
					//mul(translation, float3(x, y, 1.0));

					//合成
					//float3x3 scale       = float3x3(sx, 0, 0, 0, sy, 0, 0, 0, 1.0);
					//float3x3 rotation    = float3x3(cos(t), -sin(t), 0, sin(t), cos(t), 0, 0, 0, 1.0);
					//float3x3 translation = float3x3(1.0, 0, tx, 0, 1.0, ty, 0, 0, 1.0);
					//float3x3 model = mul(translation, mul(rotation, scale));
					//mul(model, float3(x, y, 1.0));

					//ワールド変換
					//Unity では、オブジェクトの「Transform」を反映した unity_ObjectToWorld が変換行列として提供されます。
					//mul(unity_ObjectToWorld, float4(x, y, z, w));
					
					//ビュー変換
					//mul(UNITY_MATRIX_MV, float4(x, y, z, w));

					//プロジェクション変換
					//mul(UNITY_MATRIX_MVP, float4(x, y, z, w));

					//視線ベクトル
					//_WorldSpaceCameraPos は、ワールド座標系のカメラ位置です。頂点をワールド座標系に変換して、頂点とカメラの位置関係から視線ベクトルを求めます。
					//float4 posWorld = mul(unity_ObjectToWorld, v.vertex);
					//half3  viewDir  = normalize(_WorldSpaceCameraPos.xyz - posWorld.xyz);

					//反射ベクトル
					//反射ベクトルは、入射光と法線から reflect() で求めます。
					//half3 reflectDir = reflect(-lightDir, normal);

					//Phong 反射
					//_LightColor0 を放射照度、_SpecularColor を反射係数として、鏡面反射光を計算します。ハイライトの大きさは _Shininess の値で変化します。
					//fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(RdotV, _Shininess);

					//Phong シェーディング
					// struct v2f
					// {
					// 	float4 pos      : SV_POSITION;
					// 	float3 normal   : NORMAL;
					// 	float4 posWorld : TEXCOORD0;
					// };

					//ハーフベクトル
					//ハーフベクトルは、光源ベクトルと視線ベクトルの中間に位置するため、ベクトルの合成と正規化で求めます。
					//float3 halfDir = normalize(lightDir + viewDir);

					//Blinn-Phong 反射
					//反射強度の計算を、法線とハーフベクトルの内積に置き換えます。
					//fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(NdotH, _Shininess);

					//リムライティング
					//fixed3 rim = _LightColor0.rgb * _RimColor.rgb * pow(1.0 - NdotV, _RimPower);
					
					ENDCG
				}

				CGINCLUDE//再利用するための Cg によるシェーダーコードは、CGINCLUDE と ENDCG の間に記述します。HLSL には HLSLINCLUDE と ENDHLSL、GLSL には GLSLINCLUDE と ENDGLSL が用意されています。
				
				ENDCG

				//Fallback "Diffuse"//Fallback には、既存のシェーダーを指定します。実行可能な SubShader がない場合に適用されます。
				//CustomEditor "CustomShaderGUI"//CustomEditor には、Unity のエディタ拡張を指定します。C# の ShaderGUI を継承したクラスが対象です。
				
				// Ctegory //Category を用いると、複数の SubShader に共通する設定を記述できます。
				// {
				// 	Cull Off
				// 	SubShader
				// 	{

				// 	}
				// 	SubShader
				// 	{

				// 	}
				// }

			}
		}
