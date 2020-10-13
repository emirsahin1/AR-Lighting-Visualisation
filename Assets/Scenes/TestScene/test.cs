using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private SceneSwitcher sceneSwitcher;

        private void Start()
    {
        sceneSwitcher = gameObject.GetComponent<SceneSwitcher>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneSwitcher.switchScene(0);
        }
    }
}
