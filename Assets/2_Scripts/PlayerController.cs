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

        spriteRenderer = GetComponent<SpriteRenderer>(); //색깔을 바꾸기 때문에 변수 선언 필요 
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

        if (isRespawnTime) //무적 타임 이펙트 (투명)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);


        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1); //무적 타임 종료(원래대로)
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
        // Screen 좌표계인 mousePosition을 World 좌표계로 바꾼다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 오브젝트는 x로만 움직여야 하기 때문에 y는 고정
        mousePos.y = spwanObject.transform.position.y;
        mousePos.z = spwanObject.transform.position.z;

        spwanObject.transform.position = mousePos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "monster")
        {
            if (isRespawnTime) //무적 시간이면 적에게 맞지 않음
                return;
            GameManager.Instance.Damage(15);


            Unbeatable();
            Invoke("Unbeatable", 1f);
        }
    }

}
