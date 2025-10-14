using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 닿으면 튀는 효과 + 오브젝트 껐다 킬 시 초기화
public class GetItem : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 originPos;
    [SerializeField]private float boundPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GravityReset();
    }
    private void GravityReset()
    {
        // 중력 초기화 & 콜라이더 초기화
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        transform.GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            originPos = transform.localPosition;
            ItemAddForce(boundPower);
        }

    }
    private void Update()
    {
        if(transform.position.y <= -5.5f)
        {
            transform.localPosition = originPos;
            GravityReset();
            Debug.Log("젤리초기화");
        }
    }

    // 아이템 튀어오름
    private void ItemAddForce(float power)
    {
        transform.GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 2;
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * Random.Range(-1,1), ForceMode2D.Impulse);
        
    }

}
