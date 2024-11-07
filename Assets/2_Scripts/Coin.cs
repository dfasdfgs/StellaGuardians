using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 12f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.Coin += 10;
            Destroy(gameObject);
        }
    }
}
