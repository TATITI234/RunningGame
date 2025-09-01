using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [Header("PlayerSetting")]
    [SerializeField] private float jumpPower;
    [SerializeField] private int maxJumpCnt = 2;
    [SerializeField] private int jumpCount;
    [SerializeField] private float ignoreTime = 10.0f;

    private bool isIgnore = false;
    private bool isMove = true;
    private float curTime = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isMove)
            return;

        CheckJump();

        if (isIgnore)
            curTime += Time.deltaTime;
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCnt)
            Jumps();
    }

    private void Jumps()
    {
        JumpAddForce(jumpPower);
        jumpCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckObjectTigger(collision, "Ground"))
        {
            jumpCount = 0;
            Debug.Log("ÂøÁö");
        }
        if (!CheckObjectTigger(collision, "Enemy") && !CheckObjectTigger(collision, "°¡½Ã"))
            return;

        if (!isIgnore)
        {
            JumpAddForce(jumpPower / 3);
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
}
