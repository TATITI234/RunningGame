using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
   [SerializeField] private SpriteRenderer sprite;
    private Vector3 myScale;

    [Header("PlayerSetting")]
    [SerializeField] private float jumpPower;
    [SerializeField] private int maxJumpCnt;
    [SerializeField] private int jumpCount;
    [SerializeField] private float ignoreTime;
    [SerializeField] private float slideMinusSize;

    private bool isIgnore = false;
    private bool isMove = true;
    private bool isJumping = false;
    private bool falling;
    private float curTime = 0;
    private bool isCrouch = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        myScale = transform.localScale; 
    }

    private void Update()
    {
        if (!isMove)
            return;

        CheckJump();
        CheckSlide();

        if (isIgnore)
            curTime += Time.deltaTime;

        if (transform.GetComponent<Rigidbody2D>().velocity.y < 0.01f)
        {
            falling = true;
            //Debug.Log(falling);
        }
        else
        {
            falling = false;
            //Debug.Log(falling);

        }
        // Á¡ÇÁ Ä«¿îÆ® µð¹ö±ë ¾Ã
        DebugingJump();
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCnt)
        {
            isJumping = true;
            Jumps();
        }
            
    }

    private void CheckSlide()
    {
        if (Input.GetKey(KeyCode.LeftControl) && jumpCount == 0 && !isJumping)
            Slide();
        else
            StandUp();

    }

    private void Jumps()
    {
        animator.SetTrigger("Jump");
        jumpCount++;

    }

    public void AddFoce()
    {
        JumpAddForce(jumpPower);
    }

    private void Slide()
    {
        
        if(!isCrouch)
        {
            transform.localScale = new Vector3(1, myScale.y - slideMinusSize, 1);
            transform.Translate(0, -slideMinusSize / 2, 0);
            isCrouch = true;
        }
        
    }
    private void StandUp()
    {
        if (isCrouch)
        {
            transform.Translate(0, slideMinusSize / 2, 0);
            transform.localScale = myScale;
            isCrouch = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckObjectTigger(collision, "Ground") && falling)
        {
            jumpCount = 0;
            Debug.Log("ÂøÁö");
            isJumping = false;
        }
        if (!CheckObjectTigger(collision, "Enemy") && !CheckObjectTigger(collision, "°¡½Ã"))
            return;

        if (!isIgnore)
        {
            // JumpAddForce(jumpPower / 3);
            StartCoroutine(SpriteFlash(ignoreTime));
        }
    }

    private void JumpAddForce(float power)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

    IEnumerator SpriteFlash( float ignoreTime )
    {
        isIgnore = true;
        while (curTime < ignoreTime)
        {
            sprite.color = new Color(1, 1, 1, sprite.color.a == 0.5f ? 1 : 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
        sprite.color = new Color(1f, 1f, 1f, 1f);
        curTime = 0;
        isIgnore = false;
    }

    private bool CheckObjectTigger(Collider2D collision, string name)
    {
        return collision.gameObject.CompareTag(name);
    }
    public Text jmpCntTxt;
    private void DebugingJump()
    {
        jmpCntTxt.text = jumpCount.ToString();

    }
}
