Shader "Custom/SandShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "yellow" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _BumpMap ("Bumpmap", 2D) = "bump" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
            INTERNAL_DATA
        };

        struct SurfaceOutput
        {
            fixed3 Albedo;  // diffuse color
            fixed3 Normal;  // tangent space normal, if written
            fixed3 Emission;
            half Specular;  // specular power in 0..1 range
            fixed Gloss;    // specular intensity
            fixed Alpha; 
        }; 

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float3 nlerp(float3 n1, float3 n2, float t)
        {
            return normalize(lerp(n1, n2, t));
        }

        float3 _TerrainColor; 
        float3 _ShadowColor; 

        float3 DiffuseColor(float3 N, float3 L){
            N.y *= 0.3; 
            float NdotL = saturate(4 * dot(N, L)); 

            float3 color = lerp(_ShadowColor, _TerrainColor, NdotL); 
            return color; 
        }

        sampler2D_float _SandTex;
        float _SandStrength;
        
        float3 SandNormal (float2 uv, float3 N)
        {
            // Random vector
            float3 random = tex2D(_SandTex, uv).rgb;
            // Random direction
            // [0,1]->[-1,+1]
            float3 S = normalize(random * 2 - 1);
            
            // Rotates N towards Ns based on _SandStrength
            float3 Ns = nlerp(N, S, _SandStrength);
            return Ns;
        }

        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            // Calculates normal in world space
            float3 N_WORLD = WorldNormalVector(IN, o.Normal);
            float3 UP_WORLD = float3(0, 1, 0);
            float3 Z_WORLD = float3(0, 0, 1)

            // Calculates "steepness"
            // => 0: steep (90 degrees surface)
            //  => 1: shallow (flat surface)
            float steepness = saturate(dot(N_WORLD, UP_WORLD));
            // Steepness to blending
            steepness = pow(steepness, _SteepnessSharpnessPower);

            float2 uv = W.xz;

            // [0,1]->[-1,+1]
            float3 shallow = UnpackNormal(tex2D(_ShallowTex, TRANSFORM_TEX(uv, _ShallowTex)));
            float3 steep   = UnpackNormal(tex2D(_SteepTex,   TRANSFORM_TEX(uv, _SteepTex  )));

            // Steepness normal
            float3 S = normalerp(steep, shallow, steepness);

            

            //Sand Tutorial 
            o.Albedo = _SandColor; 
            o.Alpha = 1; 

            float3 N = float3(0, 0, 1); 
            N = RipplesNormal(IN.uv_SandTex.xy, N); 
            N = SandNormal(IN.uv_SandTex.xy, N); 

            o.Normal = N; 
        }

        sampler2D_float _GlitterTex;
        float _GlitterThreshold;
        float3 _GlitterColor;
        //https://www.alanzucconi.com/2019/10/08/journey-sand-shader-5/
        float3 GlitterSpecular (float2 uv, float3 N, float3 L, float3 V)
        {
            // Random glitter direction
            float3 G = normalize(tex2D(_GlitterTex, uv).rgb * 2 - 1); // [0,1]->[-1,+1]

            // Light that reflects on the glitter and hits the eye
            float3 R = reflect(L, G);
            float RdotV = max(0, dot(R, V));
            
            // Only the strong ones (= small RdotV)
            if (RdotV > _GlitterThreshold)
                return 0;
            
            return (1 - RdotV) * _GlitterColor;
        }

        float _OceanSpecularPower;
        float _OceanSpecularStrength;
        float3 _OceanSpecularColor;
        
        float3 OceanSpecular (float3 N, float3 L, float3 V)
        {
            // Blinn-Phong
            float3 H = normalize(V + L); // Half direction
            float NdotH = max(0, dot(N, H));
            float specular = pow(NdotH, _OceanSpecularPower) * _OceanSpecularStrength;
            return specular * _OceanSpecularColor;
        }

        float _TerrainRimPower;
        float _TerrainRimStrength;
        float3 _TerrainRimColor;
        
        float3 RimLighting(float3 N, float3 V)
        {
            float rim = 1.0 - saturate(dot(N, V));
            rim = saturate(pow(rim, _TerrainRimPower) * _TerrainRimStrength);
            rim = max(rim, 0); // Never negative
            return rim * _TerrainRimColor;
        }

        float4 LightingJourney (SurfaceOutput s, fixed3 viewDir, UnityGI gi)
        {
            float3 diffuseColor = DiffuseColor    ();
            float3 rimColor     = RimLighting     ();
            float3 oceanColor   = OceanSpecular   ();
            float3 glitterColor = GlitterSpecular ();

            float3 specularColor = saturate(max(rimColor, oceanColor));
            float3 color = diffuseColor + specularColor + glitterColor;
            
            return float4(color * s.Albedo, 1);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
