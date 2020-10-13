using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject loadingMenu;
    public Image black;
    public Animator animator;

    public void switchScene(int index)
    {
        StartCoroutine(Fade(index));
    }

    IEnumerator Fade(int index)
    {
        animator.SetBool("Fade", true);

        yield return new WaitUntil(() => black.color.a == 1);
        loadingMenu.SetActive(true);
        SceneManager.LoadSceneAsync(index);
    }
}
