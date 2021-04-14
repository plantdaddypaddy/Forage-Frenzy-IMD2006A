Shader "Unlit/ToonShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Brightness("Brightnes", Range(0,1)) = 0.3
        _Strength("Strength", Range(0,1)) =0.5
        _Color("Color", Color) =  (0.4,0.4,0.4,0.4)
        [HDR]
        _Ambient("Ambient Color", Color) = (0.4,0.4,0.4,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;

            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                half3 worldNormal: NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Brightness;
            float4 _Ambient;
            float _Strength;
            float4 _Color;
            

            float Toon(float3 normal, float3 lightDir) 
            {
                float NdotL = max(0.0,dot(normalize(normal),normalize(lightDir)));
            
                return floor(NdotL/0.3);
            }


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                col *= Toon(i.worldNormal, _WorldSpaceLightPos0.xyz)* _Color* _Strength+  (_Ambient ) + _Brightness ;
                return col;
            }
            ENDCG
        }
    }
}
