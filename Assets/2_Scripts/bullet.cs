using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector]Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
    }
}