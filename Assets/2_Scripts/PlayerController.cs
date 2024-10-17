using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] Rigidbody2D Rigidbody2D;
    public float maxspeed;
    public float BulletTime;
    public Transform spwanObject;

    [SerializeField] GameObject bulletins;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GameManager.Instance.isGameOver || !GameManager.Instance.isGameClear)
        {
            move();
            bulletsh();


            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                ObjectMove();
            }
        }
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


    private void ObjectMove()
    {
        // Screen 좌표계인 mousePosition을 World 좌표계로 바꾼다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 오브젝트는 x로만 움직여야 하기 때문에 y는 고정
        mousePos.y = spwanObject.transform.position.y;
        mousePos.z = spwanObject.transform.position.z;

        spwanObject.transform.position = mousePos;
    }
}
