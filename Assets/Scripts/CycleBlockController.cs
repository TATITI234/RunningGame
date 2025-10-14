using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ��ȯ ��� ���� ��ũ��Ʈ -
 ���� : �ڽ� �������� �����ѱ�, �̵�����
    ��ȯ����� �ڽ� ������Ʈ�� Areas�迭�� ����.
    ��ȯ����� �ڽ� ������Ʈ �� �ϳ��� �������� �̾Ƽ� Ȱ��ȭ
	��ȯ����� ��ġ�� �̿��� �ʱ�ȭ���� �˻���.
	�ʱ�ȭ �Լ��� ����Ǹ� �ش� ��ȯ����� �μ��� �޾�
	����� �ڽ� �����̱� �޼��� ����
 */
public class CycleBlockController : MonoBehaviour
{
    public List<GameObject> areas;  // AreaPart ����

    private float speed;   // �׵�Ÿ�޴������� �޾ƿ� ��� ���ǵ�
    public bool isMove = true;  // ����� ������ �� �ִ��� ����

    private GameObject childObj = null;    // ���� ų ������Ʈ

    private void Start()
    {
        // �ڽ� ������Ʈ �迭�� �����ϱ�
        for (int i = 0; i < transform.childCount; i++)
        {
            areas.Add(transform.GetChild(i).gameObject);
        }
        // ������ �� ���Ƿ� �ϳ� ����
        childObj = GetRandomChild(areas);

    }

    private void Update()
    {
        // ������ �ӵ��� ��� �̵�
        MoveArea();  

        // ����� ȭ�� �ڷ� �Ѿ�� �ʱ�ȭ ���� ����
        if (transform.position.x <= -GameDataManager.Instance.blockSize)
        {
            ResetArea();
        }

    }

    // ������ ��� �̱� & Ȱ��ȭ
    public void SelectArea()// �� ��¼���
    {
        childObj = GetRandomChild(areas);
        GameObject Pattern = childObj.GetComponentInChildren<JellyPos>(true).gameObject;
        Pattern.SetActive(true);
        childObj.SetActive(true);

    }

    // ��� �ʱ�ȭ �� ��ġ �缳��
    public void ResetArea()
    {
        childObj.SetActive(false);
        transform.position = new Vector2(transform.position.x
            + GameDataManager.Instance.blockSize/*�� ũ��*/ * 2/*��� ����*/, transform.position.y);

        SelectArea();
    }

    // Areas �迭�� �μ��� �޾� �� �� �������� �ϳ� ����
    private GameObject GetRandomChild(List<GameObject> Areas)
    {
        GameObject ChildObj = Areas[Random.Range(0, Areas.Count)];
        return ChildObj;
    }

    // ��� ������
    private void MoveArea()
    {
        speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, 0);
        }
    }

}

