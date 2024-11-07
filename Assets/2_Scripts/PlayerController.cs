using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] Rigidbody2D Rigidbody2D;
    public float maxspeed;
    public float BulletTime;
    public Transform spwanObject;
    public SpriteRenderer spriteRenderer;

    public bool isRespawnTime = false;

    [SerializeField] GameObject bulletins;

    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); //������ �ٲٱ� ������ ���� ���� �ʿ� 
    }


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (GameManager.Instance.isGameOver == false)
        {
            move();
            bulletsh();


            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                ObjectMove();
            }
        }

    }

    void Unbeatable()
    {
        isRespawnTime = !isRespawnTime;

        if (isRespawnTime) //���� Ÿ�� ����Ʈ (����)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);


        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1); //���� Ÿ�� ����(�������)
        }


    }

    public void Die()
    {

    }

    private void bulletsh()
    {
        if (GameManager.Instance.isBullet)
        {
            BulletTime += Time.deltaTime;
            if (BulletTime > 0.5f)
            {
                Instantiate(bulletins, transform.position, transform.rotation);
                BulletTime = 0f;
            }
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
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� �ٲ۴�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������Ʈ�� x�θ� �������� �ϱ� ������ y�� ����
        mousePos.y = spwanObject.transform.position.y;
        mousePos.z = spwanObject.transform.position.z;

        spwanObject.transform.position = mousePos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "monster")
        {
            if (isRespawnTime) //���� �ð��̸� ������ ���� ����
                return;
            GameManager.Instance.Damage(15);


            Unbeatable();
            Invoke("Unbeatable", 1f);
        }
    }

}
