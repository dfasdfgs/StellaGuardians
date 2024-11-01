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
    float curHealth; //* ���� ü��
    public float maxHealth; //* �ִ� ü��

    public Slider HpBarSlider;

    public int Coin;


    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;

        curHealth = maxHealth;
        CheckHp();
    }

    public void CheckHp() //*HP ����
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth;
    }

    public void Damage(float damage) //* ������ �޴� �Լ�
    {
        if (maxHealth == 0 || curHealth <= 0) //* �̹� ü�� 0���ϸ� �н�
            return;
        curHealth -= damage;


        CheckHp(); //* ü�� ����
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

        GameOvertext.text = "�̵��� �Ÿ� : " + ScoreManager.instance.score.ToString("F0") + "KM";
    }

    IEnumerator boss()
    {

        yield break;
    }
}
