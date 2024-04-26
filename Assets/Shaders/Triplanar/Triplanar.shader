Shader "Custom/Triplanar" {
    Properties {
        _MainTexX ("X Texture", 2D) = "white" {}
        _MainTexY ("Y Texture", 2D) = "white" {}
        _MainTexZ ("Z Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Metallic ("Metallic", Range(0,1)) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 1
        _Scale ("Scale", Range(1, 0.1)) = 1
        _Emission ("Emission", Range(0, 1)) = 0
    }
    
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _MainTexX;
        sampler2D _MainTexY;
        sampler2D _MainTexZ;
        float4 _Color;
        float _Metallic;
        float _Glossiness;
        float _Scale;
        float _Emission;

        struct Input {
            float3 worldNormal;
            float3 worldPos;
            float3 worldViewDir;
        };

        void surf (Input IN, inout SurfaceOutputStandard o) {
            float3 X = tex2D(_MainTexX, IN.worldPos.xz * _Scale).rgb;
            float3 Y = tex2D(_MainTexY, IN.worldPos.xy * _Scale).rgb;
            float3 Z = tex2D(_MainTexZ, IN.worldPos.yz * _Scale).rgb;

            o.Albedo = (X + Y + Z) / 3 * _Color.rgb;
            o.Emission = _Emission * _Color.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
