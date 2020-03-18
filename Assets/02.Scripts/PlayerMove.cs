using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    [SerializeField]
    protected PlayerStat health;
    [SerializeField]
    protected float InitHealth = 30;

    void Start()
    {
        //체력 초기화(현재 값, 최대 값)
        health.Initialize(InitHealth, InitHealth);
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Walk Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        //Direction Sprite
        if (Input.GetButton("Horizontal"))
         {
             spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
         }
       /* Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw ("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-0.5f, 0.5f, 2); //Left Flip
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(0.5f, 0.5f, 2); //Right Flip
        } */

        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {

            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.1f, rigid.velocity.y);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }
    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        if (rigid.velocity.x < maxSpeed*(-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        int xpos;
        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            if (spriteRenderer.flipX == false)
            
                xpos = 1;
            
            else
                xpos = -1;

            Vector2 frontVec = new Vector2(rigid.position.x + xpos * 0.3f, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down * (0.5f), new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 0.4f, LayerMask.GetMask("Platform"));
            Debug.DrawRay(rigid.position, Vector3.down * (0.4f), new Color(0, 1, 0));
            RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.down, 0.4f, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null || rayHit2.collider != null)
            {
                if (rayHit.distance < 0.4f)
                    anim.SetBool("isJumping", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10) //layer가 Enemy이면 
        {
            OnDamaged(collision.transform.position);

            if(health.MyCurrentValue <= 0) //플레이어가 죽었을 때
            {
                Invoke("Delay", 2f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        //체력조절: -HP
        health.MyCurrentValue -= 1;

        //Change Layer (Immortal Active)
        gameObject.layer = 12;

        //View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //Reaction Force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*5, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    void OffDamaged()
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void Delay()
    {
        Debug.Log("딜레이");
    }
}