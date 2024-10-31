using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            GameManager.Instance.Coin += 10;
            Destroy(gameObject);
        }
    }
}
