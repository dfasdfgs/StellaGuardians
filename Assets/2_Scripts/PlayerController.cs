using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]Rigidbody2D Rigidbody2D;
    public float maxspeed;
    public float BulletTime;

    [SerializeField]GameObject bulletins;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
        bulletsh();
    }

    public void Die()
    {

    }

    private void bulletsh()
    {
        BulletTime += Time.deltaTime;
        if (BulletTime > 0.5f)
        {
            Instantiate(bulletins, transform.position, transform.rotation);
            BulletTime = 0f;
        }
    }



    private void move()
    {
        float xInput = Input.GetAxis("Horizontal");

        float xSpeed = xInput * maxspeed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, 0);
        Rigidbody2D.velocity = newVelocity;
    }
}
