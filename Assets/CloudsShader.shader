Shader "Custom/NoiseShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _NoiseScale ("Noise Scale", Range(1, 10)) = 1
        _NoiseStrength ("Noise Strength", Range(0, 1)) = 0.1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed _NoiseScale;
        fixed _NoiseStrength;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Sample the main texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            // Generate noise
            float noise = tex2D(_MainTex, IN.uv_MainTex * _NoiseScale).r;

            // Add noise to the color
            c.rgb += noise * _NoiseStrength;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
