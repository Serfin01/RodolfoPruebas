//------------------------------------------------------------------------------------------------------
// Main Light
//------------------------------------------------------------------------------------------------------

void MainLight_float (float3 WorldPos, out float3 Direction, out float3 Color,
    out float DistanceAtten)
{
 
#ifdef SHADERGRAPH_PREVIEW
    Direction = normalize(float3(1,1,-0.4));
    Color = float4(1,1,1,1);
    DistanceAtten = 1;
#else
    Light mainLight = GetMainLight();
    Direction = mainLight.direction;
    Color = mainLight.color;
    DistanceAtten = mainLight.distanceAttenuation;
#endif
}



//------------------------------------------------------------------------------------------------------
// Main Light Shadows
//------------------------------------------------------------------------------------------------------
void MainLightShadows_float (float3 WorldPos, out float ShadowAtten)
{
	#ifdef SHADERGRAPH_PREVIEW
		ShadowAtten = 1;
	#else
	//float4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
    // or if cascades are needed (and _MAIN_LIGHT_SHADOWS_CASCADE isn't defined) :
     half cascadeIndex = ComputeCascadeIndex(WorldPos);
     //ShadowCord is for receiving shadows and cascade is for smoothing shadows near camera
     float4 shadowCoord = mul(_MainLightWorldToShadow[cascadeIndex], float4(WorldPos, 1.0)); 
 
    ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
    float shadowStrength = GetMainLightShadowStrength();
    ShadowAtten = SampleShadowmap(shadowCoord, TEXTURE2D_ARGS(_MainLightShadowmapTexture, sampler_MainLightShadowmapTexture), shadowSamplingData, shadowStrength, false);
	#endif
}


//------------------------------------------------------------------------------------------------------
// Default Additional Lights
//------------------------------------------------------------------------------------------------------
void AdditionalLights_float(float3 SpecColor, float Smoothness, float3 WorldPosition, float3 WorldNormal, float3 WorldView,
							out float3 Diffuse, out float3 Specular) 
{
   float3 diffuseColor = 0;
   float3 specularColor = 0;

#ifndef SHADERGRAPH_PREVIEW
   Smoothness = exp2(10 * Smoothness + 1);
   WorldNormal = normalize(WorldNormal);
   WorldView = SafeNormalize(WorldView);
   int pixelLightCount = GetAdditionalLightsCount();
   for (int i = 0; i < pixelLightCount; ++i) {
       Light light = GetAdditionalLight(i, WorldPosition);
       float3 attenuatedLightColor = light.color * (light.distanceAttenuation * light.shadowAttenuation);
       diffuseColor += LightingLambert(attenuatedLightColor, light.direction, WorldNormal);
       specularColor += LightingSpecular(attenuatedLightColor, light.direction, WorldNormal, WorldView, float4(SpecColor, 0), Smoothness);
   }
#endif

   Diffuse = diffuseColor;
   Specular = specularColor;
}
//------------------------------------------------------------------------------------------------------
//  Additional Lights Toon
//------------------------------------------------------------------------------------------------------
void AdditionalLightsToon_float(float3 SpecColor, float Smoothness, float3 WorldPosition, float3 WorldNormal, float3 WorldView,
							out float3 Diffuse, out float3 Specular) {
	float3 diffuseColor = 0;
	float3 specularColor = 0;
	
#ifndef SHADERGRAPH_PREVIEW
	Smoothness = exp2(10 * Smoothness + 1);
	WorldNormal = normalize(WorldNormal);
	WorldView = SafeNormalize(WorldView);
	int pixelLightCount = GetAdditionalLightsCount();
	for (int i = 0; i < pixelLightCount; ++i) {
		Light light = GetAdditionalLight(i, WorldPosition);

		// DIFFUSE
		diffuseColor += light.color * (0.5 + step(0.5, light.distanceAttenuation)) * step(0.1, light.distanceAttenuation * light.shadowAttenuation);
		
		/* (LightingLambert)
		half NdotL = saturate(dot(normal, lightDir));
		diffuseColor += lightColor * NdotL;
		*/

		// SPECULAR
		// Didn't really like the look of specular lighting in the toon shader here, so just keeping it at 0 (black, no light).
	   	/* (LightingSpecular)
		float3 halfVec = SafeNormalize(float3(lightDir) + float3(viewDir));
		half NdotH = saturate(dot(normal, halfVec));
		half modifier = pow(NdotH, smoothness);
		half3 specularReflection = specular.rgb * modifier;
		specularColor += lightColor * specularReflection;
		*/
   }
#endif

   Diffuse = diffuseColor;
   Specular = specularColor;
}