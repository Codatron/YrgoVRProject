using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField]
    private Light directionalLight;

    [SerializeField]
    private LightingPreset preset;

    [SerializeField, Range (0,24)]
    public float timeOfDay;

    float exposure;
    //float exposureTo = 1f;


    public AnimationCurve animCurv;

    //maxtid/currenttid kanske tvärtom

    private void Start()
    {
        animCurv = GetComponent<AnimationCurve>();
    }
    private void Update()
    {
        if (preset == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24; //clamp between 0-24
            UpdateLighting(timeOfDay/24f);
            UpdateSkybox(timeOfDay / 24f);
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
            UpdateSkybox(timeOfDay / 24f);
        }      
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);
 
        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0)); //har kan siffrorna behovas andras 
        }
    }

    void UpdateSkybox(float timePerence)
    {

        exposure = animCurv.Evaluate(timePerence*24);
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    }

    //Debug.Log(timePerence);

    //    if (timePerence < 0.5f)
    //    {
    //        exposure = 0.4f;
    //        exposure = Mathf.Lerp(exposure, exposureTo,timePerence);
    //        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    //    }

    //    if (timePerence > 0.5f)

    //    {
    //        exposure = 0.4f;
            
    //        exposure = Mathf.Lerp(exposureTo, exposure, timePerence);
    //        Debug.Log(exposure);
    //        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    //    }
    //}

    private void OnValidate()
    {
        if (directionalLight!= null)
        {
            return;
        }

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }

        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();

            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
