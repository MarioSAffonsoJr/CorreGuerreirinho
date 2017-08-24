// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CustomShaders/VerticalGradient"
{
	Properties
	{
		_PrimaryColor("Color1", Color) = (1, 1, 1, 1)
		_SecondaryColor("Color2", Color) = (1, 1, 1, 1)
		_Texture("Texture", 2D) = "white"
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"PreviewType" = "Plane"
		}
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

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
				float4 vertex : SV_POSITION;
				float2 uv : TEXTCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			float4 _PrimaryColor;
			float4 _SecondaryColor;
			sampler2D _Texture;

			float4 frag(v2f i) : SV_Target
			{
				float4 color = tex2D(_Texture, i.uv) * float4(_PrimaryColor * i.uv.y + _SecondaryColor * (1 - i.uv.y));
				return color;
			}
			ENDCG
		}
	}
}
