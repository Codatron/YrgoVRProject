using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    public Slider slider;
    public SONectar sONectar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = sONectar.maxNectar;
        slider.value = sONectar.currentNectar;
    }
}