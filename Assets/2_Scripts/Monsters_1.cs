using UnityEngine;
using UnityEngine.UI;

public class Monsters_1 : MonoBehaviour
{
    public float speed = -1f;
    public int monsterHP = 40;
    public Image HPImg;
    public GameObject coinnn;



    public void Die()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
        if (!GameManager.Instance.isGameOver)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            monsterHP -= 15;
            HPImg.fillAmount -= 0.33f;

            if (monsterHP <= 0)
            {
                if (!GameManager.Instance.isGameBoss)
                {
                Instantiate(coinnn, this.transform.position, Quaternion.identity);
                }
                Die();
            }

        }
    }
}
