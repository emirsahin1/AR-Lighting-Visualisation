Shader "FX/Matte Shadow3" {
    Properties{
    _Color("Main Color", Color) = (1,1,1,1)
    _MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
    _Cutoff("Alpha cutoff", Range(0,1)) = 0.01
    _ShadowStrength("Shadow strength", Range(0,5)) = 1
    }
        SubShader{
            Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
            LOD 100
            Blend srcAlpha oneMinusSrcAlpha
            ZWrite Off

            CGPROGRAM
            #pragma surface surf ShadowOnly alphatest:_Cutoff

            fixed4 _Color;
            float _ShadowStrength;

            struct Input {
                float2 uv_MainTex;
            };

            inline fixed4 LightingShadowOnly(SurfaceOutput s, fixed3 lightDir, fixed atten) {
                fixed4 c;
                c.rgb = s.Albedo * atten;
                //    c.rgb = lerp(_ShadowStrength *.75, 1, atten).rrr;
                    c.a = s.Alpha;
                    return c;
                }

                void surf(Input IN, inout SurfaceOutput o) {
                    //fixed4 c = _LightColor0 + _Color;
                    fixed4 c = _LightColor0 + 0.1 * _Color;
                    //fixed4 c = _Color;
                    o.Albedo = c.rgb * _ShadowStrength;
                    o.Alpha = 0;
                }

            ENDCG
    }
        Fallback "Transparent/Cutout/VertexLit"
}