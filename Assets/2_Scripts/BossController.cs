using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject[] BossmainSP;
    public GameObject[] BulletSP;

    public float speed = -1f;
    public int monsterHP = 300;
    public GameObject coinnn;

    public void Die()
    {
        Destroy(gameObject);
    }


    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            monsterHP -= 15;

            if (monsterHP <= 0)
            {
                Instantiate(coinnn, this.transform.position, Quaternion.identity);
                Die();
            }

        }
    }
}
