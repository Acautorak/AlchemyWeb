Shader "Unlit/WaterShader2D"
{
    // dodatak dva
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _DistortionSpeed ("Distortion Speed", Range(0.1, 1.0)) = 0.5
        _DistortionAmount ("Distortion Amount", Range(0.0, 0.1)) = 0.05
    }
 
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
 
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
            float _DistortionSpeed;
            float _DistortionAmount;
 
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                fixed2 uv = i.uv;
 
                // Simulate water distortion using sine wave
                float time = _Time.y * _DistortionSpeed;
                float distortion = sin(uv.x * 30.0 + time) + sin(uv.y * 20.0 + time) * 0.5;
                distortion *= _DistortionAmount;
 
                // Offset UV coordinates based on distortion
                uv += distortion;
 
                // Sample the main texture and apply distortion
                fixed4 color = tex2D(_MainTex, uv);
 
                return color;
            }
            ENDCG
        }
    }
}
