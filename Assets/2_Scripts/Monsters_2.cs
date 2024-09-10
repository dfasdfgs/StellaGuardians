using System.Collections;
using UnityEngine;

public class Monsters_2 : MonoBehaviour
{

    void Start()
    {
    }

    public void Update()
    {
        fall_meteor();
    }

    IEnumerator warning()
    {

        yield break;
    }

    private void fall_meteor()
    {
        transform.Translate(new Vector3(-0.1f, -0.1f, 0));

        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.isGameOver = true;
            GameManager.Instance.gameovertime();
        }
    }
}
