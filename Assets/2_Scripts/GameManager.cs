using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject GameoverPanal;
    public bool isGameOver = false;
    public bool isGameClear = false;
    public Text GameOvertext;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (ScoreManager.instance.score >= 120)
        {
            isGameClear = true;
        }

        if (isGameClear)
        {
            Time.timeScale = 0f;
            GameoverPanal.SetActive(true);

            GameOvertext.text = " ���� Ŭ���� ";
        }
    }

    public void gameovertime()
    {
        Time.timeScale = 0f;
        GameoverPanal.SetActive(true);

        GameOvertext.text = "�̵��� �Ÿ� : " + ScoreManager.instance.score.ToString("F0") + "KM";
    }
}
