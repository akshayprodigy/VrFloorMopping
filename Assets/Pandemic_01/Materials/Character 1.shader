// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Character"
{
	Properties
	{
		_T_Pandemic01_BC("T_Pandemic01_BC", 2D) = "white" {}
		_T_Pandemic01_M("T_Pandemic01_M", 2D) = "white" {}
		_Chinstrap("Chinstrap", Color) = (0.4238046,0.5367647,0.2091804,0)
		_Skin("Skin", Color) = (0.3762976,0.8529412,0.8529412,0)
		_Body("Body", Color) = (0.3502207,0.1453287,0.7058823,0)
		_T_Pandemic01_ORM("T_Pandemic01_ORM", 2D) = "white" {}
		_T_Pandemic01_E("T_Pandemic01_E", 2D) = "white" {}
		_T_Pandemic01_N("T_Pandemic01_N", 2D) = "bump" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		Blend One OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _T_Pandemic01_N;
		uniform float4 _T_Pandemic01_N_ST;
		uniform sampler2D _T_Pandemic01_BC;
		uniform float4 _T_Pandemic01_BC_ST;
		uniform sampler2D _T_Pandemic01_M;
		uniform float4 _T_Pandemic01_M_ST;
		uniform float4 _Body;
		uniform float4 _Chinstrap;
		uniform float4 _Skin;
		uniform sampler2D _T_Pandemic01_E;
		uniform float4 _T_Pandemic01_E_ST;
		uniform sampler2D _T_Pandemic01_ORM;
		uniform float4 _T_Pandemic01_ORM_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_T_Pandemic01_N = i.uv_texcoord * _T_Pandemic01_N_ST.xy + _T_Pandemic01_N_ST.zw;
			o.Normal = UnpackNormal( tex2D( _T_Pandemic01_N, uv_T_Pandemic01_N ) );
			float2 uv_T_Pandemic01_BC = i.uv_texcoord * _T_Pandemic01_BC_ST.xy + _T_Pandemic01_BC_ST.zw;
			float4 tex2DNode1 = tex2D( _T_Pandemic01_BC, uv_T_Pandemic01_BC );
			float2 uv_T_Pandemic01_M = i.uv_texcoord * _T_Pandemic01_M_ST.xy + _T_Pandemic01_M_ST.zw;
			float4 tex2DNode7 = tex2D( _T_Pandemic01_M, uv_T_Pandemic01_M );
			float4 blendOpSrc18 = tex2DNode1;
			float4 blendOpDest18 = ( ( tex2DNode7.r * _Body ) + ( tex2DNode7.g * _Chinstrap ) + ( tex2DNode7.b * _Skin ) );
			float4 lerpResult20 = lerp( tex2DNode1 , ( saturate( ( blendOpSrc18 * blendOpDest18 ) )) , ( tex2DNode7.r + tex2DNode7.g + tex2DNode7.b ));
			o.Albedo = lerpResult20.rgb;
			float2 uv_T_Pandemic01_E = i.uv_texcoord * _T_Pandemic01_E_ST.xy + _T_Pandemic01_E_ST.zw;
			o.Emission = tex2D( _T_Pandemic01_E, uv_T_Pandemic01_E ).rgb;
			float2 uv_T_Pandemic01_ORM = i.uv_texcoord * _T_Pandemic01_ORM_ST.xy + _T_Pandemic01_ORM_ST.zw;
			float4 tex2DNode31 = tex2D( _T_Pandemic01_ORM, uv_T_Pandemic01_ORM );
			o.Metallic = tex2DNode31.b;
			o.Smoothness = ( 1.0 - tex2DNode31.g );
			o.Occlusion = tex2DNode31.r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17101
1990;274;1331;683;1078.034;300.2199;1.6;True;True
Node;AmplifyShaderEditor.ColorNode;9;-1444.985,-574.5516;Inherit;False;Property;_Chinstrap;Chinstrap;2;0;Create;True;0;0;False;0;0.4238046,0.5367647,0.2091804,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;10;-1442.444,-353.5398;Inherit;False;Property;_Skin;Skin;3;0;Create;True;0;0;False;0;0.3762976,0.8529412,0.8529412,0;0.992647,0.992647,0.992647,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;7;-1887.009,-594.8746;Inherit;True;Property;_T_Pandemic01_M;T_Pandemic01_M;1;0;Create;True;0;0;False;0;0d9074d065c8e9b48ba7d934f3f0b28a;0d9074d065c8e9b48ba7d934f3f0b28a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;8;-1460.228,-805.3018;Inherit;False;Property;_Body;Body;4;0;Create;True;0;0;False;0;0.3502207,0.1453287,0.7058823,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-1120.04,-823.2207;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-1112.979,-372.5552;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-1097.806,-592.8231;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-818.3879,-713.475;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-593.4131,-380.3087;Inherit;True;Property;_T_Pandemic01_BC;T_Pandemic01_BC;0;0;Create;True;0;0;False;0;None;4aac318c38e5e2a4a8dd18fa2e97a486;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-817.1456,-404.1037;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;18;-326.8182,-861.8714;Inherit;True;Multiply;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;31;-620.7122,231.7004;Inherit;True;Property;_T_Pandemic01_ORM;T_Pandemic01_ORM;5;0;Create;True;0;0;False;0;12b4d7139181b834a93df0255e6dd6ce;12b4d7139181b834a93df0255e6dd6ce;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;38;-151.3,607.3394;Inherit;True;Property;_Pandemic_01_Opacity;Pandemic_01_Opacity;9;0;Create;True;0;0;False;0;66e9bdbbf0c9c534ebc3056cad6dcf50;66e9bdbbf0c9c534ebc3056cad6dcf50;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;36;-196.3446,257.4314;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;41;65.96622,426.1802;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;32;-629.0818,-179.1902;Inherit;True;Property;_T_Pandemic01_E;T_Pandemic01_E;6;0;Create;True;0;0;False;0;f48619442b2c8b6499c29369bcde3f01;f48619442b2c8b6499c29369bcde3f01;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;37;-560.2968,504.7644;Inherit;True;Property;_T_Pandemic01_Opacity;T_Pandemic01_Opacity;8;0;Create;True;0;0;False;0;56ae01627d0e488419c4d2b63b3b1faf;56ae01627d0e488419c4d2b63b3b1faf;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;33;-617.5892,28.31732;Inherit;True;Property;_T_Pandemic01_N;T_Pandemic01_N;7;0;Create;True;0;0;False;0;62d0cf01f3fb0274094526f32984b1dc;62d0cf01f3fb0274094526f32984b1dc;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;20;10.34814,-549.866;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;304.9807,-36.13429;Float;False;True;2;ASEMaterialInspector;0;0;Standard;Character;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;True;Opaque;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;3;1;False;-1;10;False;-1;0;5;False;-1;10;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;11;0;7;1
WireConnection;11;1;8;0
WireConnection;13;0;7;3
WireConnection;13;1;10;0
WireConnection;12;0;7;2
WireConnection;12;1;9;0
WireConnection;14;0;11;0
WireConnection;14;1;12;0
WireConnection;14;2;13;0
WireConnection;15;0;7;1
WireConnection;15;1;7;2
WireConnection;15;2;7;3
WireConnection;18;0;1;0
WireConnection;18;1;14;0
WireConnection;36;0;31;2
WireConnection;41;0;37;0
WireConnection;20;0;1;0
WireConnection;20;1;18;0
WireConnection;20;2;15;0
WireConnection;0;0;20;0
WireConnection;0;1;33;0
WireConnection;0;2;32;0
WireConnection;0;3;31;3
WireConnection;0;4;36;0
WireConnection;0;5;31;1
WireConnection;0;9;37;0
WireConnection;0;10;41;0
ASEEND*/
//CHKSM=5850BC7E3796B624FD5588B205C8D970874D89F6