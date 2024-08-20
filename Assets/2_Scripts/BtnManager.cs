using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
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
}
