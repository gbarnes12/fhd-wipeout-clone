// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:Bumped Specular,lico:1,lgpr:1,nrmq:1,limd:3,uamb:True,mssp:True,lmpd:True,lprd:False,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32708,y:32713|diff-37-OUT,spec-65-OUT,gloss-67-OUT,normal-2-RGB,amdfl-12-OUT,amspl-81-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:32700,y:32491,cmnt:Normal,tex:c7e26deb99c5ab34a9f9b72f41bfc465,ntxv:0,isnm:False|TEX-7-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7,x:32967,y:32434,ptlb:Normal Map,ptin:_NormalMap,glob:False,tex:c7e26deb99c5ab34a9f9b72f41bfc465;n:type:ShaderForge.SFN_Lerp,id:12,x:33148,y:32901|A-13-RGB,B-16-OUT,T-14-OUT;n:type:ShaderForge.SFN_AmbientLight,id:13,x:33331,y:32735;n:type:ShaderForge.SFN_Slider,id:14,x:33409,y:33064,ptlb:Ambient VS IBL,ptin:_AmbientVSIBL,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:15,x:33600,y:32765,ptlb:IBL Strength,ptin:_IBLStrength,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:16,x:33445,y:32850|A-15-OUT,B-17-OUT;n:type:ShaderForge.SFN_Add,id:17,x:33845,y:32873|A-23-OUT,B-27-OUT;n:type:ShaderForge.SFN_Cubemap,id:22,x:34889,y:32812,ptlb:DiffuseIBL,ptin:_DiffuseIBL,cmnt:Ambient Diffuse IBL Cubemap,cube:44ffc862fc175cc4f9f7d77b7b88ddd7,pvfc:0|DIR-32-OUT;n:type:ShaderForge.SFN_Multiply,id:23,x:34031,y:32649|A-46-OUT,B-25-OUT;n:type:ShaderForge.SFN_Multiply,id:25,x:34246,y:32637|A-40-OUT,B-27-OUT;n:type:ShaderForge.SFN_Multiply,id:27,x:34449,y:32801|A-22-RGB,B-29-OUT;n:type:ShaderForge.SFN_Multiply,id:29,x:34673,y:32971|A-22-A,B-30-OUT;n:type:ShaderForge.SFN_Vector1,id:30,x:34976,y:33030,v1:5;n:type:ShaderForge.SFN_NormalVector,id:32,x:35112,y:32799,pt:False;n:type:ShaderForge.SFN_Tex2d,id:33,x:34977,y:31920,cmnt:DiffuseMap,tex:8a758778e34919d4a9837886f4c22f06,ntxv:0,isnm:False|TEX-34-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:34,x:35287,y:31966,ptlb:DiffuseMap Gloss(A),ptin:_DiffuseMapGlossA,glob:False,tex:8a758778e34919d4a9837886f4c22f06;n:type:ShaderForge.SFN_Color,id:35,x:35287,y:32177,ptlb:Diffuse Color,ptin:_DiffuseColor,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:36,x:34625,y:31920|A-33-RGB,B-35-RGB;n:type:ShaderForge.SFN_Add,id:37,x:33767,y:31933|A-36-OUT,B-44-OUT;n:type:ShaderForge.SFN_Fresnel,id:40,x:34578,y:32115|EXP-41-OUT;n:type:ShaderForge.SFN_Slider,id:41,x:34788,y:32145,ptlb:Diffuse Fresnel,ptin:_DiffuseFresnel,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:42,x:34257,y:32057|A-36-OUT,B-40-OUT;n:type:ShaderForge.SFN_Multiply,id:44,x:34036,y:32126|A-42-OUT,B-46-OUT;n:type:ShaderForge.SFN_Multiply,id:46,x:34375,y:32245|A-41-OUT,B-48-OUT;n:type:ShaderForge.SFN_Vector1,id:48,x:34647,y:32297,v1:0.1;n:type:ShaderForge.SFN_Color,id:50,x:36429,y:32445,ptlb:SpecularColor Gloss(A),ptin:_SpecularColorGlossA,glob:False,c1:0.1,c2:0.1,c3:0.1,c4:1;n:type:ShaderForge.SFN_Multiply,id:52,x:36087,y:32428|A-50-RGB,B-61-OUT;n:type:ShaderForge.SFN_Multiply,id:54,x:35958,y:32646|A-50-A,B-63-OUT;n:type:ShaderForge.SFN_Multiply,id:56,x:35704,y:32596|A-33-A,B-54-OUT;n:type:ShaderForge.SFN_Multiply,id:58,x:35704,y:32755|A-33-A,B-50-A;n:type:ShaderForge.SFN_Multiply,id:60,x:35704,y:32945|A-50-RGB,B-61-OUT;n:type:ShaderForge.SFN_Vector1,id:61,x:36082,y:33040,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:63,x:36288,y:32796,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:65,x:35119,y:32406|A-52-OUT,B-69-OUT;n:type:ShaderForge.SFN_Multiply,id:67,x:35119,y:32578|A-69-OUT,B-56-OUT;n:type:ShaderForge.SFN_Fresnel,id:69,x:35314,y:32470|EXP-71-OUT;n:type:ShaderForge.SFN_Slider,id:71,x:35501,y:32444,ptlb:Specular Fresnel,ptin:_SpecularFresnel,min:-0.1,cur:0,max:3;n:type:ShaderForge.SFN_Multiply,id:81,x:33442,y:33278|A-69-OUT,B-83-OUT;n:type:ShaderForge.SFN_Multiply,id:83,x:33779,y:33309|A-60-OUT,B-85-OUT;n:type:ShaderForge.SFN_Multiply,id:85,x:34075,y:33213|A-91-RGB,B-87-OUT;n:type:ShaderForge.SFN_Multiply,id:87,x:34335,y:33376|A-91-A,B-99-OUT;n:type:ShaderForge.SFN_Cubemap,id:91,x:34673,y:33211,ptlb:SpecularIBL,ptin:_SpecularIBL,cmnt:Ambient Diffuse IBL Cubemap,cube:44ffc862fc175cc4f9f7d77b7b88ddd7,pvfc:0|DIR-107-OUT,MIP-93-OUT;n:type:ShaderForge.SFN_Multiply,id:93,x:34971,y:33349|A-106-OUT,B-95-OUT;n:type:ShaderForge.SFN_Vector1,id:95,x:35467,y:33431,v1:8;n:type:ShaderForge.SFN_Vector1,id:99,x:34565,y:33520,v1:5;n:type:ShaderForge.SFN_Multiply,id:105,x:35306,y:33261|A-58-OUT,B-95-OUT;n:type:ShaderForge.SFN_OneMinus,id:106,x:35137,y:33235|IN-105-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:107,x:34971,y:33130;proporder:35-14-15-41-50-71-34-7-22-91;pass:END;sub:END;*/

Shader "Shader Forge/PB Bumped Specular" {
    Properties {
        _DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
        _AmbientVSIBL ("Ambient VS IBL", Range(0, 1)) = 0
        _IBLStrength ("IBL Strength", Range(0, 1)) = 0
        _DiffuseFresnel ("Diffuse Fresnel", Range(0, 5)) = 0
        _SpecularColorGlossA ("SpecularColor Gloss(A)", Color) = (0.1,0.1,0.1,1)
        _SpecularFresnel ("Specular Fresnel", Range(-0.1, 3)) = 0
        _DiffuseMapGlossA ("DiffuseMap Gloss(A)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "black" {}
        _DiffuseIBL ("DiffuseIBL", Cube) = "_Skybox" {}
        _SpecularIBL ("SpecularIBL", Cube) = "_Skybox" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #pragma glsl
            #ifndef LIGHTMAP_OFF
                float4 unity_LightmapST;
                sampler2D unity_Lightmap;
                #ifndef DIRLIGHTMAP_OFF
                    sampler2D unity_LightmapInd;
                #endif
            #endif
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _AmbientVSIBL;
            uniform float _IBLStrength;
            uniform samplerCUBE _DiffuseIBL;
            uniform sampler2D _DiffuseMapGlossA; uniform float4 _DiffuseMapGlossA_ST;
            uniform float4 _DiffuseColor;
            uniform float _DiffuseFresnel;
            uniform float4 _SpecularColorGlossA;
            uniform float _SpecularFresnel;
            uniform samplerCUBE _SpecularIBL;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                #ifndef LIGHTMAP_OFF
                    float2 uvLM : TEXCOORD5;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                #ifndef LIGHTMAP_OFF
                    o.uvLM = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
                #endif
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_291 = i.uv0;
                float3 normalLocal = tex2D(_NormalMap,TRANSFORM_TEX(node_291.rg, _NormalMap)).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                #ifndef LIGHTMAP_OFF
                    float4 lmtex = tex2D(unity_Lightmap,i.uvLM);
                    #ifndef DIRLIGHTMAP_OFF
                        float3 lightmap = DecodeLightmap(lmtex);
                        float3 scalePerBasisVector = DecodeLightmap(tex2D(unity_LightmapInd,i.uvLM));
                        UNITY_DIRBASIS
                        half3 normalInRnmBasis = saturate (mul (unity_DirBasis, normalLocal));
                        lightmap *= dot (normalInRnmBasis, scalePerBasisVector);
                    #else
                        float3 lightmap = DecodeLightmap(lmtex);
                    #endif
                #endif
                #ifndef LIGHTMAP_OFF
                    #ifdef DIRLIGHTMAP_OFF
                        float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                    #else
                        float3 lightDirection = normalize (scalePerBasisVector.x * unity_DirBasis[0] + scalePerBasisVector.y * unity_DirBasis[1] + scalePerBasisVector.z * unity_DirBasis[2]);
                        lightDirection = mul(lightDirection,tangentTransform); // Tangent to world
                    #endif
                #else
                    float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                #endif
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                #ifndef LIGHTMAP_OFF
                    float3 diffuse = lightmap.rgb;
                #else
                    float3 diffuse = max( 0.0, NdotL)*InvPi * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb*2;
                #endif
///////// Gloss:
                float node_69 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_SpecularFresnel);
                float4 node_33 = tex2D(_DiffuseMapGlossA,TRANSFORM_TEX(node_291.rg, _DiffuseMapGlossA)); // DiffuseMap
                float gloss = (node_69*(node_33.a*(_SpecularColorGlossA.a*1.5)));
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float node_61 = 0.5;
                float node_95 = 8.0;
                float4 node_91 = texCUBElod(_SpecularIBL,float4(viewReflectDirection,((1.0 - ((node_33.a*_SpecularColorGlossA.a)*node_95))*node_95))); // Ambient Diffuse IBL Cubemap
                float3 specularColor = ((_SpecularColorGlossA.rgb*node_61)*node_69);
                float specularMonochrome = dot(specularColor,float3(0.3,0.59,0.11));
                float HdotL = max(0.0,dot(halfDirection,lightDirection));
                float3 fresnelTerm = specularColor + ( 1.0 - specularColor ) * pow((1.0 - HdotL),5);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float3 fresnelTermAmb = specularColor + ( 1.0 - specularColor ) * ( pow((1.0 - NdotV),5) / (4-3*gloss) );
                float alpha = 1.0 / ( sqrt( (Pi/4.0) * specPow + Pi/2.0 ) );
                float visTerm = ( NdotL * ( 1.0 - alpha ) + alpha ) * ( NdotV * ( 1.0 - alpha ) + alpha );
                visTerm = 1.0 / visTerm;
                float normTerm = (specPow + 8.0 ) / (8.0 * Pi);
                float3 specularAmb = (node_69*((_SpecularColorGlossA.rgb*node_61)*(node_91.rgb*(node_91.a*5.0)))) * fresnelTermAmb;
                float3 specular = 1*NdotL * pow(max(0,dot(halfDirection,normalDirection)),specPow)*fresnelTerm*visTerm*normTerm + specularAmb;
                #ifndef LIGHTMAP_OFF
                    #ifndef DIRLIGHTMAP_OFF
                        specular *= lightmap;
                    #else
                        specular *= (floor(attenuation) * _LightColor0.xyz);
                    #endif
                #else
                    specular *= (floor(attenuation) * _LightColor0.xyz);
                #endif
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float node_46 = (_DiffuseFresnel*0.1);
                float node_40 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_DiffuseFresnel);
                float4 node_22 = texCUBE(_DiffuseIBL,i.normalDir); // Ambient Diffuse IBL Cubemap
                float3 node_27 = (node_22.rgb*(node_22.a*5.0));
                diffuseLight += lerp(UNITY_LIGHTMODEL_AMBIENT.rgb,(_IBLStrength*((node_46*(node_40*node_27))+node_27)),_AmbientVSIBL); // Diffuse Ambient Light
                diffuseLight *= 1-specularMonochrome;
                float3 node_36 = (node_33.rgb*_DiffuseColor.rgb);
                finalColor += diffuseLight * (node_36+((node_36*node_40)*node_46));
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #pragma glsl
            #ifndef LIGHTMAP_OFF
                float4 unity_LightmapST;
                sampler2D unity_Lightmap;
                #ifndef DIRLIGHTMAP_OFF
                    sampler2D unity_LightmapInd;
                #endif
            #endif
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _DiffuseMapGlossA; uniform float4 _DiffuseMapGlossA_ST;
            uniform float4 _DiffuseColor;
            uniform float _DiffuseFresnel;
            uniform float4 _SpecularColorGlossA;
            uniform float _SpecularFresnel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_292 = i.uv0;
                float3 normalLocal = tex2D(_NormalMap,TRANSFORM_TEX(node_292.rg, _NormalMap)).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL)*InvPi * attenColor;
///////// Gloss:
                float node_69 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_SpecularFresnel);
                float4 node_33 = tex2D(_DiffuseMapGlossA,TRANSFORM_TEX(node_292.rg, _DiffuseMapGlossA)); // DiffuseMap
                float gloss = (node_69*(node_33.a*(_SpecularColorGlossA.a*1.5)));
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float node_61 = 0.5;
                float3 specularColor = ((_SpecularColorGlossA.rgb*node_61)*node_69);
                float specularMonochrome = dot(specularColor,float3(0.3,0.59,0.11));
                float HdotL = max(0.0,dot(halfDirection,lightDirection));
                float3 fresnelTerm = specularColor + ( 1.0 - specularColor ) * pow((1.0 - HdotL),5);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float alpha = 1.0 / ( sqrt( (Pi/4.0) * specPow + Pi/2.0 ) );
                float visTerm = ( NdotL * ( 1.0 - alpha ) + alpha ) * ( NdotV * ( 1.0 - alpha ) + alpha );
                visTerm = 1.0 / visTerm;
                float normTerm = (specPow + 8.0 ) / (8.0 * Pi);
                float3 specular = attenColor*NdotL * pow(max(0,dot(halfDirection,normalDirection)),specPow)*fresnelTerm*visTerm*normTerm;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight *= 1-specularMonochrome;
                float3 node_36 = (node_33.rgb*_DiffuseColor.rgb);
                float node_40 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_DiffuseFresnel);
                float node_46 = (_DiffuseFresnel*0.1);
                finalColor += diffuseLight * (node_36+((node_36*node_40)*node_46));
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Bumped Specular"
    CustomEditor "ShaderForgeMaterialInspector"
}
