// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Accessories"
{
	Properties
	{
		_T_GANG_FEM_01_BC("T_GANG_FEM_01_BC", 2D) = "white" {}
		_T_GANG_FEM_01_N("T_GANG_FEM_01_N", 2D) = "bump" {}
		_T_GANG_FEM_01_ORM("T_GANG_FEM_01_ORM", 2D) = "white" {}
		_T_Pandemic01_E("T_Pandemic01_E", 2D) = "white" {}
		_T_Pandemic01_Opacity("T_Pandemic01_Opacity", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Overlay+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		Blend One OneMinusSrcAlpha
		
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _T_GANG_FEM_01_N;
		uniform float4 _T_GANG_FEM_01_N_ST;
		uniform sampler2D _T_GANG_FEM_01_BC;
		uniform float4 _T_GANG_FEM_01_BC_ST;
		uniform sampler2D _T_Pandemic01_E;
		uniform float4 _T_Pandemic01_E_ST;
		uniform sampler2D _T_GANG_FEM_01_ORM;
		uniform float4 _T_GANG_FEM_01_ORM_ST;
		uniform sampler2D _T_Pandemic01_Opacity;
		uniform float4 _T_Pandemic01_Opacity_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_T_GANG_FEM_01_N = i.uv_texcoord * _T_GANG_FEM_01_N_ST.xy + _T_GANG_FEM_01_N_ST.zw;
			o.Normal = UnpackNormal( tex2D( _T_GANG_FEM_01_N, uv_T_GANG_FEM_01_N ) );
			float2 uv_T_GANG_FEM_01_BC = i.uv_texcoord * _T_GANG_FEM_01_BC_ST.xy + _T_GANG_FEM_01_BC_ST.zw;
			o.Albedo = tex2D( _T_GANG_FEM_01_BC, uv_T_GANG_FEM_01_BC ).rgb;
			float2 uv_T_Pandemic01_E = i.uv_texcoord * _T_Pandemic01_E_ST.xy + _T_Pandemic01_E_ST.zw;
			o.Emission = tex2D( _T_Pandemic01_E, uv_T_Pandemic01_E ).rgb;
			float2 uv_T_GANG_FEM_01_ORM = i.uv_texcoord * _T_GANG_FEM_01_ORM_ST.xy + _T_GANG_FEM_01_ORM_ST.zw;
			float4 tex2DNode3 = tex2D( _T_GANG_FEM_01_ORM, uv_T_GANG_FEM_01_ORM );
			o.Metallic = tex2DNode3.b;
			o.Smoothness = ( 1.0 - tex2DNode3.g );
			o.Occlusion = tex2DNode3.r;
			float2 uv_T_Pandemic01_Opacity = i.uv_texcoord * _T_Pandemic01_Opacity_ST.xy + _T_Pandemic01_Opacity_ST.zw;
			o.Alpha = tex2D( _T_Pandemic01_Opacity, uv_T_Pandemic01_Opacity ).r;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard keepalpha fullforwardshadows exclude_path:deferred 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17101
1990;274;1331;683;1523.37;432.7364;2.005285;True;True
Node;AmplifyShaderEditor.SamplerNode;3;-819.1085,251.1453;Inherit;True;Property;_T_GANG_FEM_01_ORM;T_GANG_FEM_01_ORM;3;0;Create;True;0;0;False;0;7e400a0fb89ce8942b351db4f47bd8e6;12b4d7139181b834a93df0255e6dd6ce;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-593.4131,-380.3087;Inherit;True;Property;_T_GANG_FEM_01_BC;T_GANG_FEM_01_BC;0;0;Create;True;0;0;False;0;4aac318c38e5e2a4a8dd18fa2e97a486;4aac318c38e5e2a4a8dd18fa2e97a486;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;5;-330.4555,285.4761;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;21;-627.5594,516.5451;Inherit;True;Property;_T_Pandemic01_Opacity;T_Pandemic01_Opacity;5;0;Create;True;0;0;False;0;56ae01627d0e488419c4d2b63b3b1faf;56ae01627d0e488419c4d2b63b3b1faf;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;6;-694.6542,47.06579;Inherit;True;Property;_T_Pandemic01_E;T_Pandemic01_E;4;0;Create;True;0;0;False;0;f48619442b2c8b6499c29369bcde3f01;f48619442b2c8b6499c29369bcde3f01;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-890.925,-199.6094;Inherit;True;Property;_T_GANG_FEM_01_N;T_GANG_FEM_01_N;1;0;Create;True;0;0;False;0;15aaa3a02d92ee247b9b9fba12a4997b;62d0cf01f3fb0274094526f32984b1dc;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;148.4634,-16.196;Float;False;True;2;ASEMaterialInspector;0;0;Standard;Accessories;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;Transparent;;Overlay;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;3;1;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;2;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;3;2
WireConnection;0;0;1;0
WireConnection;0;1;2;0
WireConnection;0;2;6;0
WireConnection;0;3;3;3
WireConnection;0;4;5;0
WireConnection;0;5;3;1
WireConnection;0;9;21;0
ASEEND*/
//CHKSM=92D09CBFC5DB54086FC5B8C1BF4AE3BAE30FAF91