using UnityEngine;
using UnityEngine.UI;

public class Monsters_1 : MonoBehaviour
{
    public float speed = -1f;
    public int monsterHP = 40;
    public Image HPImg;

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
                Die();
        }

        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.isGameOver = true;
            GameManager.Instance.gameovertime();
        }
    }
}
