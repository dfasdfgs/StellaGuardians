using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject[] BossmainSP;
    public GameObject[] BulletSP;

    private int maxHealth = 1500;
    int curHealth = 1500;
    public Slider BossHpBarSlider;

    public void Die()
    {
        GameManager.Instance.gameClear();
        Destroy(gameObject);
    }

    public void CheckHp() //*HP 갱신
    {
        if (BossHpBarSlider != null)
            BossHpBarSlider.value = curHealth;
    }

    public void Damage(int damage) //* 데미지 받는 함수
    {
        if (maxHealth == 0 || curHealth <= 0) //* 이미 체력 0이하면 패스
            return;
        curHealth -= damage;


        CheckHp(); //* 체력 갱신
        if (curHealth <= 0)
        {
            Die();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Damage(15);
            Destroy(collision.gameObject);
        }
    }
}
