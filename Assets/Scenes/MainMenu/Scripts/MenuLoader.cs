using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    public static GameObject MenuLoaderObject;
    public string lastMenu;

    private void Awake()
    {
        if(MenuLoaderObject != null)
        {
            Destroy(this.gameObject);
            return;
        }
        MenuLoaderObject = this.gameObject;
        GameObject.DontDestroyOnLoad(MenuLoaderObject);
    }

    public void setLastMenu(string currentMenu)
    {
        lastMenu = currentMenu;
        Debug.LogError("setLastMenu: " + lastMenu);
    }

    public void activateLastMenu()
    {
        Debug.Log("finding menu to acitvate");
        GameObject.Find(lastMenu).transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Debug.Log("MenuLoader is destroyed.");
    }
}
