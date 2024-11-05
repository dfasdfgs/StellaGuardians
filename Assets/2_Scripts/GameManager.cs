using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject GameoverPanal;

    public GameObject ScorePanelUI;
    public GameObject Boss1;
    public GameObject spawner;
    public GameObject settingBTNUI;
    public GameObject CoinUI;
    public GameObject HPUI;
    public GameObject BossHPUI;
    public GameObject BossText;

    public bool isGameOver = false;
    public bool isGameBoss = false;
    public Text GameOvertext;
    public Text CoinText;
    float curHealth; //* ���� ü��
    public float maxHealth; //* �ִ� ü��

    public Slider HpBarSlider;
    public Slider BossHpBarSlider;

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
        if (BossHpBarSlider != null)
            BossHpBarSlider.value = curHealth;
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
            isGameBoss = true;
        }

        if (isGameBoss)
        {
            spawner.SetActive(false);
            ScorePanelUI.SetActive(false);
            settingBTNUI.SetActive(false);
            HPUI.SetActive(false);

            BossText.SetActive(true);

            StartCoroutine(boss());
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
        BossHPUI.SetActive(true);
        Boss1.SetActive(true);
        yield return new WaitForSeconds(5f);
        BossText.SetActive(false);
        isGameBoss = false;

        
        spawner.SetActive(true);
        yield break;
    }


}
