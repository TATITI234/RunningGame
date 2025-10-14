using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ������ Ƣ�� ȿ�� + ������Ʈ ���� ų �� �ʱ�ȭ
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
        // �߷� �ʱ�ȭ & �ݶ��̴� �ʱ�ȭ
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
            Debug.Log("�����ʱ�ȭ");
        }
    }

    // ������ Ƣ�����
    private void ItemAddForce(float power)
    {
        transform.GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 2;
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * Random.Range(-1,1), ForceMode2D.Impulse);
        
    }

}
