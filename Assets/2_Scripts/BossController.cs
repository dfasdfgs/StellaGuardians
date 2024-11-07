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

    public void CheckHp() //*HP ����
    {
        if (BossHpBarSlider != null)
            BossHpBarSlider.value = curHealth;
    }

    public void Damage(int damage) //* ������ �޴� �Լ�
    {
        if (maxHealth == 0 || curHealth <= 0) //* �̹� ü�� 0���ϸ� �н�
            return;
        curHealth -= damage;


        CheckHp(); //* ü�� ����
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
