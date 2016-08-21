// unlit, alpha blended, cull off

Shader "BudgeSprite/UnlitBlendColor" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	}

	SubShader 
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 100
		
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha 
		Cull Off
		Lighting Off
		
        Pass 
        {            
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;	
			fixed4 _Color;
					
			struct a2v
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
			
			struct v2f 
			{
			    float4 pos : SV_POSITION;
			    float2 uv : TEXCOORD1;			// We need high precision on the UVs (for large atlases with dicing)
			    fixed4 color : Color;
			};
			
			v2f vert (a2v v)
			{
			    v2f o;			    
			    o.uv = v.texcoord.xy;
			    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);			    
			    o.color = v.color;
			    return o;
			}
			
			fixed4 frag( v2f i ) : COLOR
			{			
			    return tex2D(_MainTex, i.uv) * _Color * i.color;
			}
			
			ENDCG
	  	}
	}
}
