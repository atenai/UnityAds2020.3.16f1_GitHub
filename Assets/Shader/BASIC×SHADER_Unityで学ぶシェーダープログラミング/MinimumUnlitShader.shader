//最小のシェーダーコードらしい
Shader "BASIC*SHADER/Unlit/MinimumUnlitShader" //Shader 直後の名前がマテリアルの「Shader」選択項目に反映されます。
{
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
    Properties
    {
      …
    }
    SubShader 
    {
      …
    }
    Fallback "Diffuse"
    CustomEditor "CustomShaderGUI"
} 
*/
