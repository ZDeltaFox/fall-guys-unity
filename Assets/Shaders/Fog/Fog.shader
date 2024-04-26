Shader "Vertex Fragment/Custom/ShaderFog" {
 
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_FogStart("Fog Start", Float) = 0.0
		_FogEnd("Fog End", Float) = 10.0
 
	}
 
		SubShader{
 
		Tags{ "RenderType" = "Opaque" }
		Fog{ Mode off }
 
			Pass{
 
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
 
			uniform sampler2D _MainTex;
			float _FogStart;
			float _FogEnd;
 
			struct appdata {
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};
 
			struct v2f {
				float4 pos : SV_POSITION;
				float4 uv : TEXCOORD0;
				float fog : TEXCOORD1;
			};
 
			v2f vert(appdata v) {
 
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				float fogz = mul(UNITY_MATRIX_MV, v.vertex).z;
				o.fog = saturate((fogz + _FogStart) / (_FogStart - _FogEnd));
 
				return o;
			}
 
			half4 frag(v2f i) : COLOR{
				return lerp(tex2D(_MainTex, i.uv.xy), unity_FogColor, i.fog);//unity_FogColor - variable dentro de unity
			}
 
		ENDCG
		}
	}
}