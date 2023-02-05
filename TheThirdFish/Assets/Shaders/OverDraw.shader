Shader "Hidden/Over Draw"
{
    Properties
    {
        _OverDrawColor("Overdraw Color", Color) = (1,1,1,1)
        _FadeFactor("Fade Factor", Range(0, 5)) = 0.5
        _WaveSpeed("Wave Speed", Float) = 5.0
        _WaveFrequency("Wave Frequency", Float) = 10.0
        _SourcePos("Source Position", Vector) = (0,0,0)
    }

        SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }

        ZTest Less
        ZWrite Off
        Blend One One

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            half4 _OverDrawColor;
            float _FadeFactor;
            float _WaveSpeed;
            float _WaveFrequency;
            float3 _SourcePos;

            fixed4 frag(v2f i) : SV_Target
            {
                float t = _Time.y * _WaveSpeed;
                float wave = (sin(t + distance(i.worldPos, _SourcePos) * _WaveFrequency) + 1) * 0.5;
                return _OverDrawColor * lerp(_FadeFactor, 1, wave);
            }
            ENDCG
        }
    }
}
