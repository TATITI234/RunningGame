using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyPos : MonoBehaviour
{
    public List<GameObject> jellys = new();     // ������(������ ���� �� ���� �ʱ�ȭ��)
    public List<Vector3> jellyPos = new();   // ���� �ʱ� ��ġ����(������ ���� �� ���� �ʱ�ȭ��)
    /*
    public static JellyPos instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }*/

    private bool isInitialized = false; // �� ���� ����ǰ� �ϱ� ���� bool ����

    public void FillJellys()
    {
        if (isInitialized) return;
        isInitialized = true;

        gameObject.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform Child = transform.GetChild(i);
            jellys.Add(Child.gameObject);
            jellyPos.Add(Child.position);
        }
        Debug.Log($"{name} ���� �ʱ�ȭ �Ϸ�");

    }

}
