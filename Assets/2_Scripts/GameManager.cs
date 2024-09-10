using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject GameoverPanal;
    public bool isGameOver = false;
    public Text GameOvertext;

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

        GameOvertext.text = "이동한 거리 : " + ScoreManager.instance.score.ToString("F0") + "KM";
    }
}
