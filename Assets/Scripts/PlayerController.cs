using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private bool canMove = true;
    public int maxJumpCnt = 2;
    public int jumpCnt;
    /// <summary>
    /// 피격시 무적시간
    /// </summary>
    public float ignoreTime = 10.0f;
    bool ignore = false;
    float curTime = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(canMove)
        {
            Jumps();
        }
        if(ignore)
            curTime += Time.deltaTime;
    }
    private void Jumps()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < maxJumpCnt)
        {
            Debug.Log("점프");
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCnt++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCnt = 0;
            Debug.Log("착지");

        }
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "가시")
        {
            if(!ignore)
            {
                Debug.Log("피해");
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpPower / 3, ForceMode2D.Impulse);
                StartCoroutine(SpriteFlash(ignoreTime));
            }

        }
    }

    IEnumerator SpriteFlash( float ignoreTime )
    {
        ignore = true;
        while (curTime < ignoreTime)
        {
            sprite.color = new Color(1, 1, 1, sprite.color.a == 0.5f ? 1 : 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
        sprite.color = new Color(1f, 1f, 1f, 1f);
        curTime = 0;
        ignore = false;
    }
}
