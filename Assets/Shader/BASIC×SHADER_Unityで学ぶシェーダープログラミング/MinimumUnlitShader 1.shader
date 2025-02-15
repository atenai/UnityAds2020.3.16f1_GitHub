//最小のシェーダーコードらしい
Shader "BASIC*SHADER/Unlit/MinimumUnlitShader" //Shader 直後の名前がマテリアルの「Shader」選択項目に反映されます。
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

    SubShader
    {
        Pass
        {
            CGPROGRAM
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
    }
}

/* 
Shader "Name" //Shader 直後の名前がマテリアルの「Shader」選択項目に反映されます。
{
    Properties //Properties の中には、Unity エディタからシェーダーコードに渡したい情報を定義します。定義したプロパティは、マテリアルのインスペクタから GUI で編集が可能です。
    {
      … // プロパティに必要な定義は、「プロパティ名」「インスペクタ表示名」「プロパティ型」「デフォルト値」です。プロパティ名は、慣習的に _ を接頭辞とします。
    }

    SubShader 
    {
      …
    }
      
    Fallback "Diffuse"
    CustomEditor "CustomShaderGUI"
} 
*/
