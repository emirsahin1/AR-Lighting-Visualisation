using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightController : MonoBehaviour
{
    public Text debugger;

    private InteractiveLight[] lights;
    [SerializeField] private TMP_Text closeButtonText;
    private Dropdown dropDown;
    private Slider redSlider, greenSlider, blueSlider, intensitySlider, rotateXSlider, rotateYSlider;
    private int activeLightIndex;
    private InteractiveLight activeLight;
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

        lights = FindObjectsOfType<InteractiveLight>();
        dropDown = GetComponentInChildren<Dropdown>(true);

        initDropDown(lights);
        initSliderValues();
    }


    //Initiliases the dropdown according to the number of lights.
    private void initDropDown(InteractiveLight[] lights)
    {
        activeLight = lights[0];
        List<string> options = new List<string>();

        for (int i = 0; i < lights.Length; i++) {
            options.Add(optionString + (i + 1));
            //lights[i].GetComponentInParent<TMP_Text>().SetText("Light " + i);
            lights[i].title.SetText("Light " + (i + 1));
        }
        dropDown.ClearOptions();
        dropDown.AddOptions(options);
    }

    //Sets the lights index to be controlled
    public void setActiveLight(int val)
    {
        activeLight = lights[val];
        initSliderValues();
    }

    public void updateLightColor()
    {
        if (callOnValueChanged)
        {
            activeLight.lightComp.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
            activeLight.lightBulb.GetComponent<Renderer>().material.SetColor("_BaseColor", activeLight.lightComp.color);
        }
    }
    public void updateLightIntensity()
    {
        if (callOnValueChanged)
        {
            activeLight.lightComp.intensity = intensitySlider.value;
        }
    }
    public void updateLightRotation()
    {
        if (callOnValueChanged)
        {
            activeLight.gameObject.transform.localRotation = Quaternion.Euler(rotateYSlider.value, rotateXSlider.value, 0f);
            debugger.text = activeLight.gameObject.transform.eulerAngles.y.ToString();
        }
    }

    public void initSliderValues()
    {
        callOnValueChanged = false;

        redSlider.value = activeLight.lightComp.color.r;
        greenSlider.value = activeLight.lightComp.color.g;
        blueSlider.value = activeLight.lightComp.color.b;
        rotateXSlider.value = activeLight.gameObject.transform.localEulerAngles.y;
        rotateYSlider.value = activeLight.gameObject.transform.localEulerAngles.x;
        intensitySlider.value = activeLight.lightComp.intensity;

        for (int i = 0; i < lights.Length; i++)
        {
            //lights[i].transform.parent.gameObject.GetComponent<Renderer>().material = Instantiate(Resources.Load("Material") as Material);
            lights[i].lightBulb.GetComponent<Renderer>().material.SetColor("_BaseColor", lights[i].lightComp.color);
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
