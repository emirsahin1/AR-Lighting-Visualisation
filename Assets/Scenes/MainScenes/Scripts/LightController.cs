using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightController : MonoBehaviour
{
    private Light[] lights;
    [SerializeField] private TMP_Text closeButtonText;
    private Dropdown dropDown;
    private Slider redSlider, greenSlider, blueSlider, intensitySlider, rotateXSlider, rotateYSlider;
    private int activeLightIndex;
    private const string optionString = "Light ";
    private bool callOnValueChanged = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        redSlider = GameObject.Find("RedSlider").GetComponent<Slider>();
        greenSlider = GameObject.Find("GreenSlider").GetComponent<Slider>();
        blueSlider = GameObject.Find("BlueSlider").GetComponent<Slider>();
        intensitySlider = GameObject.Find("IntensitySlider").GetComponent<Slider>();
        rotateXSlider = GameObject.Find("RotationXSlider").GetComponent<Slider>();
        rotateYSlider = GameObject.Find("RotationYSlider").GetComponent<Slider>();

        lights = FindObjectsOfType<Light>();
        dropDown = GetComponentInChildren<Dropdown>(true);

        initDropDown(lights);
        initSliderValues();
    }


    //Initiliases the dropdown according to the number of lights.
    private void initDropDown(Light[] lights)
    {
        List<string> options = new List<string>();

        for (int i = 0; i < lights.Length; i++) {
            options.Add(optionString + (i + 1));
            //lights[i].GetComponentInParent<TMP_Text>().SetText("Light " + i);
            lights[i].transform.parent.GetComponentInChildren<TMP_Text>().SetText("Light " + (i + 1));
        }
        dropDown.ClearOptions();
        dropDown.AddOptions(options);

    }

    //Sets the lights index to be controlled
    public void setActiveLight(int val)
    {
        activeLightIndex = val;
        initSliderValues();
    }

    public void updateLightColor()
    {
        if (callOnValueChanged)
        {
            lights[activeLightIndex].color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
            lights[activeLightIndex].transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", lights[activeLightIndex].color);
        }
    }
    public void updateLightIntensity()
    {
        if (callOnValueChanged)
        {
            lights[activeLightIndex].intensity = intensitySlider.value;
        }
    }
    public void updateLightRotation()
    {
        if (callOnValueChanged)
        {
            //Vector3 lightRotation = lights[activeLightIndex].transform.rotation.eulerAngles;
            lights[activeLightIndex].transform.parent.parent.localRotation = Quaternion.Euler(rotateYSlider.value, rotateXSlider.value, 1f);
            //lights[activeLightIndex].transform.parent.parent.RotateAround(new Vector3(0,0,0),Vector3.up, rotateYSlider.value);
            //lights[activeLightIndex].transform.parent.parent.RotateAround(new Vector3(0,0,0), Vector3.right, rotateXSlider.value);
        }
    }

    public void initSliderValues()
    {
        callOnValueChanged = false;

        redSlider.value = lights[activeLightIndex].color.r;
        greenSlider.value = lights[activeLightIndex].color.g;
        blueSlider.value = lights[activeLightIndex].color.b;
        intensitySlider.value = lights[activeLightIndex].intensity;

        for (int i = 0; i < lights.Length; i++)
        {
            //lights[i].transform.parent.gameObject.GetComponent<Renderer>().material = Instantiate(Resources.Load("Material") as Material);
            lights[i].transform.parent.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", lights[i].color);
        }

        callOnValueChanged = true;
    }

    public void toggleVisiblity()
    {
        if (gameObject.activeInHierarchy)
        {
            turnOffController();
        }
        else
        {
            turnOnController();
        }

    }

    public void turnOffController()
    {
        gameObject.SetActive(false);
        closeButtonText.text = "Open Menu";

    }

    public void turnOnController()
    {
        gameObject.SetActive(true);
        closeButtonText.text = "Close Menu";

    }
}
