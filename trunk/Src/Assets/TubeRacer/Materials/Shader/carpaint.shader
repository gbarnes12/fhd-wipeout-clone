// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:2,uamb:True,mssp:True,lmpd:False,lprd:False,enco:True,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32533,y:32830|diff-195-OUT,spec-288-OUT,gloss-294-OUT,normal-196-RGB,emission-240-OUT;n:type:ShaderForge.SFN_Vector1,id:195,x:32943,y:32573,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:196,x:32883,y:32904,ptlb:Normal,ptin:_Normal,tex:abdaa6318ca2ad040aaeb24526779369,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:206,x:33099,y:32929,ptlb:node_206,ptin:_node_206,tex:4804e3040859d2647bbd584c929a73b5,ntxv:2,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:209,x:33563,y:33255,ptlb:node_209,ptin:_node_209,glob:False,v1:4;n:type:ShaderForge.SFN_Power,id:211,x:33544,y:33096|VAL-216-RGB,EXP-214-OUT;n:type:ShaderForge.SFN_ValueProperty,id:214,x:33756,y:33191,ptlb:node_214,ptin:_node_214,glob:False,v1:3;n:type:ShaderForge.SFN_Cubemap,id:216,x:33756,y:33013,ptlb:node_216,ptin:_node_216,cube:f466cf7415226e046b096197eb7341aa,pvfc:0|DIR-268-OUT;n:type:ShaderForge.SFN_Multiply,id:240,x:32870,y:33108|A-206-RGB,B-241-OUT;n:type:ShaderForge.SFN_Add,id:241,x:33051,y:33132|A-216-RGB,B-242-OUT;n:type:ShaderForge.SFN_Multiply,id:242,x:33245,y:33230|A-211-OUT,B-209-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:268,x:33942,y:32835;n:type:ShaderForge.SFN_Slider,id:288,x:32877,y:32692,ptlb:Specularity,ptin:_Specularity,min:0,cur:0.8045113,max:1;n:type:ShaderForge.SFN_Slider,id:294,x:32864,y:32795,ptlb:Glossiness,ptin:_Glossiness,min:0,cur:0.4736842,max:1;proporder:196-206-209-214-216-288-294;pass:END;sub:END;*/

Shader "Shader Forge/carpaint" {
    Properties {
        _Normal ("Normal", 2D) = "bump" {}
        _node_206 ("node_206", 2D) = "black" {}
        _node_209 ("node_209", Float ) = 4
        _node_214 ("node_214", Float ) = 3
        _node_216 ("node_216", Cube) = "_Skybox" {}
        _Specularity ("Specularity", Range(0, 1)) = 0.8045113
        _Glossiness ("Glossiness", Range(0, 1)) = 0.4736842
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _node_206; uniform float4 _node_206_ST;
            uniform float _node_209;
            uniform float _node_214;
            uniform samplerCUBE _node_216;
            uniform float _Specularity;
            uniform float _Glossiness;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
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
                float2 node_302 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_302.rg, _Normal))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL)*InvPi * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
////// Emissive:
                float4 node_216 = texCUBE(_node_216,viewReflectDirection);
                float3 node_211 = pow(node_216.rgb,_node_214);
                float3 emissive = (tex2D(_node_206,TRANSFORM_TEX(node_302.rg, _node_206)).rgb*(node_216.rgb+(node_211*_node_209)));
///////// Gloss:
                float gloss = _Glossiness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = float3(_Specularity,_Specularity,_Specularity);
                float specularMonochrome = dot(specularColor,float3(0.3,0.59,0.11));
                float normTerm = (specPow + 2.0 ) / (2.0 * Pi);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor*normTerm;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight *= 1-specularMonochrome;
                float node_195 = 0.2;
                finalColor += diffuseLight * float3(node_195,node_195,node_195);
                finalColor += specular;
                finalColor += emissive;
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
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _node_206; uniform float4 _node_206_ST;
            uniform float _node_209;
            uniform float _node_214;
            uniform samplerCUBE _node_216;
            uniform float _Specularity;
            uniform float _Glossiness;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
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
                float2 node_303 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_303.rg, _Normal))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL)*InvPi * attenColor;
///////// Gloss:
                float gloss = _Glossiness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = float3(_Specularity,_Specularity,_Specularity);
                float specularMonochrome = dot(specularColor,float3(0.3,0.59,0.11));
                float normTerm = (specPow + 2.0 ) / (2.0 * Pi);
                float3 specular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow) * specularColor*normTerm;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                diffuseLight *= 1-specularMonochrome;
                float node_195 = 0.2;
                finalColor += diffuseLight * float3(node_195,node_195,node_195);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
