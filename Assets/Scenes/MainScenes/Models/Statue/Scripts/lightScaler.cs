using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class lightScaler : MonoBehaviour
{
    public GameObject arObject;
    private Light light;
    public float initialIntensity;
    private float intensity;
    private float ratio;
    private float range;
    private Vector3 lastScale;
    // Start is called before the first frame update
    void Start()
    {
        //arObject = GameObject.FindGameObjectWithTag("ArObject");
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        intensity = Math.Max(initialIntensity - 1/(arObject.transform.localScale.magnitude * 20f), 0.003f);
        light.intensity = intensity;
     }
  
    
}
