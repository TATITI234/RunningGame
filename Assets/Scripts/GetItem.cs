using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float boundPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        // 중력 초기화 & 콜라이더 초기화
        rb.gravityScale = 0;
        transform.GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ItemAddForce(boundPower);
        }

    }
    private void Update()
    {

    }

    // 아이템 튀어오름
    private void ItemAddForce(float power)
    {
        transform.GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 2;
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

}
