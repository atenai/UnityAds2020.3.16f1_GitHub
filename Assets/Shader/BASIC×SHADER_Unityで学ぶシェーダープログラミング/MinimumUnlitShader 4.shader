//最小のシェーダーコードらしい
Shader "BASIC*SHADER/Unlit/MinimumUnlitShader4" //Shader 直後の名前がマテリアルの「Shader」選択項目に反映されます。
{
    Properties //Properties の中には、Unity エディタからシェーダーコードに渡したい情報を定義します。定義したプロパティは、マテリアルのインスペクタから GUI で編集が可能です。 
    {
        //プロパティに必要な定義は、「プロパティ名」「インスペクタ表示名」「プロパティ型」「デフォルト値」です。プロパティ名は、慣習的に _ を接頭辞とします。
      _Name1("Display 1", Int) = 1
      _Name2("Display 2", Float) = 0.5
      _Name3("Display 3", Range(0,1)) = 0.5
      _Name4("Display 4", Vector) = (0,1,0,1)
      _Name5("Display 5", Color) = (1,0,0,1)
      _Name6("Display 6", 2D) = "white"{}
      _Name7("Display 7", Cube) = "black"{}
      _Name8("Display 8", 3D) = "gray"{}
    }

    SubShader// SubShader の中には、レンダリングパスを定義します。複数の SubShader を列挙した場合、Unity は上から順番に試行して、実行可能な SubShader を適用します。
    {
        Tags 
        {
            "Queue" = "Geometry"//Queue レンダリング順 (Background | Geometry | AlphaTest | Transparent | Overlay)
            "RenderType" = "Opaque"//RenderType グループ分類 (Opaque | Transparent | TransparentCutout | Background | Overlay)
            //DisableBatching バッチングの無効化 (True | False | LODFading)
            //ForceNoShadowCasting シャドウ投影の無効化 (True | False)
            //IgnoreProjector プロジェクタ投影の無効化 (True | False)
            //CanUseSpriteAtlas スプライトアトラスの使用 (True | False)
            //PreviewType インスペクタプレビュー (Sphere | Plane | Skybox)
        }

        LOD 200//LOD Level of Detail の閾値
        
        Pass// Pass の中には、レンダリング内容を定義します。複数の Pass を列挙した場合、レンダリングを複数回実行します。 そのほか、パスの再利用には UsePass、画面テクスチャの取得には GrabPass が用意されています。
        {
            Tags 
            {
                "LightMode" = "ForwardBase"//LightMode ライティング (Always | ForwardBase | ForwardAdd | Deferred | ShadowCaster | MotionVectors) 
                //PassFlags データ転送フラグ (OnlyDirectional) 
                //RequireOptions 条件レンダリング (SoftVegetation)
            }

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
            #pragma vertex vert
            #pragma fragment frag

            float4 vert (float4 vertex:POSITION) : SV_POSITION
            {
                return UnityObjectToClipPos(vertex);
            }

            fixed4 frag () : SV_Target
            {
                return fixed4(1.0,0,0,1.0);
            }
            ENDCG
        }

		CGINCLUDE//再利用するための Cg によるシェーダーコードは、CGINCLUDE と ENDCG の間に記述します。HLSL には HLSLINCLUDE と ENDHLSL、GLSL には GLSLINCLUDE と ENDGLSL が用意されています。
		
		ENDCG

		//Fallback "Diffuse"//Fallback には、既存のシェーダーを指定します。実行可能な SubShader がない場合に適用されます。
		//CustomEditor "CustomShaderGUI"//CustomEditor には、Unity のエディタ拡張を指定します。C# の ShaderGUI を継承したクラスが対象です。
	
		// Category //Category を用いると、複数の SubShader に共通する設定を記述できます。
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
