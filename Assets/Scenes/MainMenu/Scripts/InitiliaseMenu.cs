using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiliaseMenu : MonoBehaviour
{
    public GameObject menuLoader;
    private MenuLoader menuLoaderScript;
    public string initialMenu;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        menuLoader = GameObject.Find("MenuLoader");
        menuLoaderScript = menuLoader.GetComponent<MenuLoader>();
        Debug.Log("getting MENULOADER");
        
        menuLoaderScript.activateLastMenu();
    }

}
