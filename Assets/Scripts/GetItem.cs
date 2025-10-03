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
        // �߷� �ʱ�ȭ & �ݶ��̴� �ʱ�ȭ
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

    // ������ Ƣ�����
    private void ItemAddForce(float power)
    {
        transform.GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 2;
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }

}
