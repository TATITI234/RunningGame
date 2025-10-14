using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyPos : MonoBehaviour
{
    public List<GameObject> jellys = new();     // ������(������ ���� �� ���� �ʱ�ȭ��)
    
    public static JellyPos instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        FillJellys();
    }

    private bool isInitialized = false; // �� ���� ����ǰ� �ϱ� ���� bool ����

    public void FillJellys()
    {
        if (isInitialized) return;
        isInitialized = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform Child = transform.GetChild(i);
            jellys.Add(Child.gameObject);
        }
        Debug.Log("�ʱ�ȭ �Ϸ�");

    }

}
