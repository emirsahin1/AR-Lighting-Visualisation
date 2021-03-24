using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveLight : MonoBehaviour
{
    private Vector3 _initialRotation;
    [SerializeField] private GameObject _lightBulb;
    [SerializeField] private Light _lightComp;
    [SerializeField] private TMP_Text _title;

    public TMP_Text title
    {
        get { return _title; }
        set { _title = value; }
    }
    public Vector3 initialRotation
    {
        get{ return _initialRotation; }
        set { _initialRotation = value; }
    }
    public GameObject lightBulb
    {
        get { return _lightBulb; }
        set { _lightBulb = value; }
    }
    public Light lightComp
    {
        get { return _lightComp; }
        set { _lightComp = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _initialRotation = gameObject.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
