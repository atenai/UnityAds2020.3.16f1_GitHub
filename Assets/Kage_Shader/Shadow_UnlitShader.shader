Shader "Unlit/Shadow_UnlitShader"
{
	//Parameters
	//Parametersのパートにはインスペクタに公開する変数を書きます。
	//C#スクリプトのpublic変数のようなものと考えれば理解しやすいと思います。
    Properties
    {
		//マテリアルのInspectorで設定したいプロパティを記述します。
		//プロパティ名 ("Inspectorに表示する名前", 型) = "デフォルト値" { オプション }
        _MainTex ("Texture", 2D) = "white" {}
    }
	//Parameters
	
    SubShader
    {
		//Shader Settings
		//Shader Settingsのパートにはライティングや透明度などのシェーダの設定項目を記述します。

		//Unity側にシェーダの設定を伝えるためにタグを付けます。
		//RenderTypeはシェーダがどのようなグループに属しているのかを指定します。
        Tags { "RenderType"="Opaque" }
		//LODは Level of Detail の略で、しきい値の役割を果たしています。
        LOD 100

		//Passの冒頭に必要に応じてタグを書きます。
		//Passでしか使えないタグはライティングに関わる部分が主で、今回は特にタグは登場しません。
        Pass
        {
            CGPROGRAM//ここからCg言語のプログラムを書くという合図
			
			//シェーダを記述
			//プラグマ（pragma）とは、コンパイラに対して情報を渡すための命令のことです。
            #pragma vertex vert//頂点シェーダ関数名
            #pragma fragment frag//フラグメントシェーダ関数名
            
			//multi_compile から始まるのはシェーダバリアントという機能を使うための命令です。
			//UnlitShaderは所々に「FOG」とついた命令があるのが分かると思います。
			//FOGとはそのままフォグという機能のことです。
            #pragma multi_compile_fog
			
			//インクルード（include）は、指定したファイルの中身をそのままこの位置に貼り付ける命令です。
            #include "UnityCG.cginc"
		//Shader Settings

			//Surface Shader
			//Surface Shaderのパートにはシェーダ本体のプログラムを書きます。
			//この部分を修正して目的のシェーダを作ります。

			//頂点シェーダへ入力する頂点データの定義です。
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
			
			//頂点シェーダからフラグメントシェーダへ受け渡すデータの定義です。
            struct v2f
            {
                float2 uv : TEXCOORD0;//フォグ処理をするために必要なfogCoord変数を定義する必要があるけれど、何番目のTEXCOORDを使ったらいいかはシェーダによって変わるので指定できる仕組みになっているわけですね。
                UNITY_FOG_COORDS(1)//UNITY_FOG_COORDSは、UnityCG.cgincで定義されています。
                float4 vertex : SV_POSITION;//座標変換された後の頂点座標（float4）
            };

			//グローバル変数の宣言
            sampler2D _MainTex;
            float4 _MainTex_ST;

			//頂点シェーダの処理
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			//フラグメントシェーダの処理
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
			//Surface Shader

            ENDCG//プログラム終了
        }

		// 影の描画//追加した部分
		Pass
		{
		   Tags { "LightMode" = "ShadowCaster" }//LightModeTagを設定しない場合には、Unityはライティングや影なしで描画しようとします。
		   CGPROGRAM
		   #pragma vertex vert
		   #pragma fragment frag
		   #pragma multi_compile_shadowcaster

		   #include "UnityCG.cginc"

		   struct appdata
		   {
			   float4 vertex : POSITION;
			   float3 normal : NORMAL;
			   float2 uv : TEXCOORD0;
		   };

		   //シャドウマップにキューブマップを使うポイントライトかを見ているifになります。
		   //また、SHADOWS_CUBEはLightコンポーネントのTypeとShadowTypeによって定義されているものになります。
		   struct v2f 
		   {
			   V2F_SHADOW_CASTER;
		   };

		   v2f vert(appdata v) 
		   {
			   v2f o;
			   TRANSFER_SHADOW_CASTER_NORMALOFFSET(o);
			   return o;
		   }

		   fixed4 frag(v2f i) : SV_Target 
		   {
			   SHADOW_CASTER_FRAGMENT(i)
		   }
		   ENDCG
		}
		// 影の描画//追加した部分
    }
}
