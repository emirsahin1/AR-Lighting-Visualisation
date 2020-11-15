using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class lightScaler : MonoBehaviour
{
    public GameObject arObject;
    public Text debugger;
    private Light light;
    public float initialIntensity;
    private float intensity;
    private float ratio;
    private Vector3 lastScale;
    // Start is called before the first frame update
    void Start()
    {
        //arObject = GameObject.FindGameObjectWithTag("ArObject");
        light = gameObject.GetComponent<Light>();
        ratio = light.intensity / arObject.transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        //if (arObject.transform.hasChanged)
        //{
        //    intensity = ((ratio / 10) * arObject.transform.localScale.magnitude);
        //    //intensity = Math.Max(initialIntensity - 1 / (arObject.transform.localScale.magnitude * 20f), 0.007f);
        //    light.intensity = intensity;

        //    arObject.transform.hasChanged = false;
        //    //debugger.text = "Intensity " + intensity + "Ratio " + ratio;
        //}
    }
  
    
}
