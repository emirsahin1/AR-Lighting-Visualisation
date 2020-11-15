Shader "Custom/SpecOnly" {
    Properties{
    }
    SubShader{
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf SpecularOnly finalcolor:alphaFix alpha 

        struct Input {
          half Specular;
        };

        half4 LightingSpecularOnly(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
          half3 h = normalize(lightDir + viewDir);
          half diff = max(0, dot(s.Normal, lightDir));
          float nh = max(0, dot(s.Normal, h));
          float spec = pow(nh, s.Specular * 128.0);
          half4 c;
          c.rgb = (_LightColor0.rgb * spec) * (atten * 2);
          c.a = spec;
          return c;
          }

        void alphaFix(Input IN, SurfaceOutput o, inout fixed4 color) {
          color.a = color.rgb;
          }

        void surf(Input IN, inout SurfaceOutput o) {
            o.Specular = 1;
        }
        ENDCG
    }
}