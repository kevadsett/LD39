Shader "Unlit/EnemyShader"
{
	Properties
	{
		_Color ("Colour", Color) = (1.0, 1.0, 1.0, 1.0)
		_AddColor ("Additive Colour", Color) = (0.5, 0.5, 0.5, 1.0)
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
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			fixed4 _Color;
			fixed4 _AddColor;
			sampler2D _LightBuffer;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = ComputeScreenPos (o.vertex).xy;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = _Color * tex2D (_LightBuffer, i.uv) + _AddColor;
				return col;
			}
			ENDCG
		}
	}
}
