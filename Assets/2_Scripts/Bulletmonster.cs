using UnityEngine;

public class Bulletmonster : MonoBehaviour
{
    Vector3 PlayerVec;
    void Start()
    {
        PlayerVec = FindAnyObjectByType<PlayerController>().transform.position;
        Destroy(gameObject, 1.3f);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerVec, 0.02f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.isGameOver = true;
            GameManager.Instance.gameovertime();
        }
    }
}
