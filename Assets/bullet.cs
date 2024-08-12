using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector]Rigidbody2D Rigidbody;
    monster monster;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = transform.up * speed;
        monster = FindAnyObjectByType<monster>();

        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "monster")
        {
            monster playerController = GetComponent<monster>();

            if(monster != null)
            {
                monster.Die();
            }
        }        
    }
}
