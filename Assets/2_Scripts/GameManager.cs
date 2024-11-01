using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject GameoverPanal;

    public GameObject ScorePanelUI;
    public GameObject settingBTNUI;
    public GameObject CoinUI;
    public GameObject HPUI;

    public bool isGameOver = false;
    public bool isGameClear = false;
    public Text GameOvertext;
    public Text CoinText;
    float curHealth; //* 현재 체력
    public float maxHealth; //* 최대 체력

    public Slider HpBarSlider;

    public int Coin;


    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;

        curHealth = maxHealth;
        CheckHp();
    }

    public void CheckHp() //*HP 갱신
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth;
    }

    public void Damage(float damage) //* 데미지 받는 함수
    {
        if (maxHealth == 0 || curHealth <= 0) //* 이미 체력 0이하면 패스
            return;
        curHealth -= damage;


        CheckHp(); //* 체력 갱신
        if (curHealth <= 0)
        {
            gameovertime();
        }
    }


    private void Update()
    {
        if (ScoreManager.instance.score >= 120)
        {
            isGameClear = true;
        }

        if (isGameClear)
        {
            ScorePanelUI.SetActive(false);
            settingBTNUI.SetActive(false);
            HPUI.SetActive(false);
            CoinUI.SetActive(false);

        }

        CoinText.text = " : " + Coin.ToString();
    }

    public void gameovertime()
    {
        isGameOver = true;

        Time.timeScale = 0f;
        GameoverPanal.SetActive(true);

        GameOvertext.text = "이동한 거리 : " + ScoreManager.instance.score.ToString("F0") + "KM";
    }

    IEnumerator boss()
    {

        yield break;
    }
}
