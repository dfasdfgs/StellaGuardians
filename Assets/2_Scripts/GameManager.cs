using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject GameoverPanal;
    public bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    private void Update()
    {

    }

    public void gameovertime()
    {
        Time.timeScale = 0f;
        GameoverPanal.SetActive(true);
    }
}
