using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveSkybox : MonoBehaviour
{
    private LightingManager lightingManager;
    [SerializeField]
    float exposure, interval, timeOfDay;
    float timer;
    [SerializeField] bool isMorning;

    private void Awake()
    {
        lightingManager = GetComponent<LightingManager>();
    }
    private void Start()
    {
    }

    void Update()
    {
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.4f); moveskybox
        // RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.time * Mathf.Deg2Rad * 100) + 0.5f);
        //Test2();
       
        timer += Time.deltaTime;

        if (lightingManager.timeOfDay < 12.0f)
        {
            isMorning = true;
        }

        else
        {
            isMorning = false;
        }

        if (isMorning)
        {
            exposure += 0.0009167f;
            RenderSettings.skybox.SetFloat("_Exposure", exposure);

            //if (exposure > 1.0f)
            //{
            //    timer = 0.0f;
            //}
        }
        else if (!isMorning)
        {
            exposure -= 0.0009167f;
            RenderSettings.skybox.SetFloat("_Exposure", exposure);

            //if (exposure < 0.1f)
            //{
            //    timer = 0.0f;
            //}
        }
    }
}
