using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 AreaManager ���� - 
���� : AreaManager������Ʈ�� ����. 
�����Ϳ��� �� ���� ��ȯ��� ���� �Ҵ�.  
�� ��ȯ����� �ڽ� ������Ʈ�� Areas1,Areas2�迭�� ����.
�� ��ȯ����� �ڽ� ������Ʈ �� �ϳ��� �������� �̾Ƽ� Ȱ��ȭ
	��ȯ����� ��ġ�� �̿��� �ʱ�ȭ���� �˻���.
	�ʱ�ȭ �Լ��� ����Ǹ� �ش� ��ȯ����� �μ��� �޾�
	����� �ڽ� �����̱� �޼��� ����
 */
public class AreaManager : MonoBehaviour
{
    public GameObject cycleBlock1;  // ��ȯ���
    public GameObject cycleBlock2;

    // public static AreaManager instance = null;

    private void Awake()
    {
        //if (instance == null)
        //    instance = this;

    }
    private void Start()
    {

    }

}
