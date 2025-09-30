using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
�÷��̾��� Y��ǥ�� �����ͼ� �ڱ��ڽ�(�÷���)���� ���� ������
 �ݶ��̴��� Ȱ��ȭ���Ѽ� �ö�Ż �� �ְ� �����
 */
public class PlatformOnOff : MonoBehaviour
{
    // �÷��̾� ���̸� ������ �÷��̾� Ʈ������
    public Transform Player;

    void Start()
    {
        // Player�±��� ������Ʈ�� ã�Ƽ� Ʈ������ �Ҵ�(FindWithFag : ��� ������Ʈ�� �˻���)
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {


    }
    void Update()
    {

        // �÷��̾��� �߹ٴ� ��ġ�� �÷������� ������ �ݶ��̴��� Ȱ��ȭ��Ű��
        if (Player.position.y - (Player.transform.GetComponent<BoxCollider2D>().size.y / 2)
            + 0.1f >= transform.position.y// + (transform.localScale.y / 2) && falling // ���� �ӵ��� ������ �� ���������� ������Ʈ�� �վ �������� ��
            )
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            transform.GetComponent<Collider2D>().enabled = false;

        }
    }

}
