using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenu.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
    }
}
