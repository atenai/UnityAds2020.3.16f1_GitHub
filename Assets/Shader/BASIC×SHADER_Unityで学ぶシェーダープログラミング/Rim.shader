Shader "BASICxSHADER/Lighting/Rim"
{
    Properties{
		_DiffuseColor("Diffuse Color",Color)=(1,1,1,1)
		_SpecularColor("Specular Color",Color)=(1,1,1,1)
		_Shininess("Shininess",Float)=20
		_RimColor("Rim Color",Color)=(1,1,1,1)
		_RimPower("Rim Power",Float)=5
	}

	SubShader{
		Pass{
			Tags{"LightMode" = "ForwardBase"}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//Properties
			uniform fixed4 _LightColor0;
			uniform fixed4 _DiffuseColor;
			uniform fixed4 _SpecularColor;
			uniform half _Shininess;
			uniform fixed4 _RimColor;
			uniform half _RimPower;

			//Vertex Input
			struct appdata{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			//Vertex to Fragment
			struct v2f{
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
				float4 posWorld : TEXCOORD0;
			};

			//------------------------------------------------------------------------
       		// Vertex Shader
       		//------------------------------------------------------------------------
			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);

				return o;
			}

			//------------------------------------------------------------------------
       		// Fragment Shader
       		//------------------------------------------------------------------------
			fixed4 frag(v2f i):SV_Target{
				//Vector
				half3 normal = normalize(i.normal);
				half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.posWorld);
				half3 halfDir = normalize(lightDir + viewDir);

				//Dot
				half NdotL = saturate(dot(normal, lightDir));
				half NdotV = saturate(dot(normal,viewDir));
				half NdotH = saturate(dot(normal, halfDir));

				//Color
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * _DiffuseColor.rgb;
				fixed3 diffuse = _LightColor0.rgb * _DiffuseColor.rgb * NdotL;
				fixed3 specular = _LightColor0.rgb * _SpecularColor.rgb * pow(NdotH, _Shininess);
				fixed3 rim = _LightColor0.rgb * _RimColor.rgb * pow(1.0 - NdotV, _RimColor);
				fixed4 color = fixed4(ambient + diffuse + specular + rim, 1.0);

				return color;
			}

			ENDCG

		}
	}
}
