Shader "Unlit/AccretionDiskShader"
{
    Properties
    {
        _MainTex ("Base Disk Texture", 2D) = "white" {}
        _ControlTex ("Control (Radial Gradient)", 2D) = "white" {}

        _ColorA ("Inner Color", Color) = (1, 1, 1, 1)
        _ColorB ("Mid Inner Color", Color) = (1, 1, 0, 1)
        _ColorC ("Mid Color", Color) = (1, 0.5, 0, 1)
        _ColorD ("Mid Outer Color", Color) = (1, 0, 0, 1)
        _ColorE ("Outer Color", Color) = (0.2, 0, 0, 1)

        _RotationSpeed ("Rotation Speed", Float) = 1.0

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

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _ControlTex;
            float4 _ControlTex_ST;

            fixed4 _ColorA;
            fixed4 _ColorB;
            fixed4 _ColorC;
            fixed4 _ColorD;
            fixed4 _ColorE;
            float _RotationSpeed;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // Use same UVs for everything
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float radius = i.uv.y;
                float angle = i.uv.x * 6.2831853; // 0–2π

                // Rotate the angle for main base texture only
                float angularVelocity = 1.5 / (radius + 0.05);
                float rotatedAngle = angle - _Time.y * _RotationSpeed * angularVelocity;

                // Compute rotated polar UV for main texture
                float2 rotatedUV = float2(cos(rotatedAngle), sin(rotatedAngle)) * radius * 0.5 + 0.5;
                fixed4 baseTex = tex2D(_MainTex, rotatedUV);

                // Sample control texture without rotating (preserve radial bands)
                float2 diskControlUV = float2(cos(angle), sin(angle)) * radius * 0.5 + 0.5;
                float control = tex2D(_ControlTex, diskControlUV).r;

                // Use control value to interpolate between ring colors
                fixed4 ringColor;
                if (control < 0.2)
                    ringColor = _ColorA;
                else if (control < 0.4)
                    ringColor = lerp(_ColorA, _ColorB, (control - 0.2) / 0.2);
                else if (control < 0.6)
                    ringColor = lerp(_ColorB, _ColorC, (control - 0.4) / 0.2);
                else if (control < 0.8)
                    ringColor = lerp(_ColorC, _ColorD, (control - 0.6) / 0.2);
                else
                    ringColor = lerp(_ColorD, _ColorE, (control - 0.8) / 0.2);

                return baseTex * ringColor;
            }


            ENDCG
        }
    }
}
