using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject[] UIall;
    public Animator animator;
    bool onBtn = true;

    public void OnShootingSceneGO()
    {
        SceneManager.LoadScene("ShootingScene");
    }
    public void OnMainSceneGO()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnSettingMenuon()
    {
        Time.timeScale = 0f;
    }
    public void OnSettingMenuoff()
    {
        Time.timeScale = 1.0f;
    }


    public void Onhidego()
    {
        if (onBtn == true)
        {
            animator.SetBool("hideon", true);
            animator.SetBool("hideoff", false);

            Onhideback();

            onBtn = false;
        }
        else
        {
            animator.SetBool("hideon", false);
            animator.SetBool("hideoff", true);

            Onhideback();

            onBtn = true;
        }

        void Onhideback()
        {
            UIall[0].SetActive(!onBtn);
            UIall[1].SetActive(!onBtn);
            UIall[2].SetActive(!onBtn);
            UIall[3].SetActive(!onBtn);
        }

    }
}
