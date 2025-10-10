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
    public List<GameObject> Areas1 = new();  // �̱��� Area���� ������ �迭
    public List<GameObject> Areas2 = new();  
    
    private float speed;   // ��� ���ǵ�
    public bool isMove = true;  // ����� ������ �� �ִ��� ����

    private GameObject ChildObj1 = null;    // ���� ų ������Ʈ
    private GameObject ChildObj2 = null;

    // public static AreaManager instance = null;


    private void Awake()
    {
        //if (instance == null)
        //    instance = this;

    }
    private void Start()
    {

        // �ڽ� ������Ʈ �迭�� �����ϱ�
        SetChild(cycleBlock1, Areas1);
        SetChild(cycleBlock2, Areas2);
        ChildObj1 = GetRandomChild(Areas1);
        ChildObj2 = GetRandomChild(Areas2);
    }

    // cycleBlock�� Areas�� �μ��� �޾� �ڽ� ������Ʈ�� ���
    private void SetChild(GameObject cycleBlock, List<GameObject> Areas)
    {/*
        Debug.Log("cycleBlock�� �̸�: " + cycleBlock.name);
        Debug.Log("cycleBlock�� �ڽ� ��: " + cycleBlock.transform.childCount);
     */
        for (int i = 0; i < cycleBlock.transform.childCount; i++)
        {
            Areas.Add(cycleBlock.transform.GetChild(i).gameObject);
        }
    }

    // Areas �迭�� �μ��� �޾� �� �� �������� �ϳ� ����
    private GameObject GetRandomChild(List<GameObject> Areas)
    {
        GameObject ChildObj = Areas[Random.Range(0, Areas.Count)];
        return ChildObj;
    }

    private void Update()
    {
        // ����� ȭ�� �ڷ� �Ѿ�� �ʱ�ȭ ���� ����
        ResetArea(cycleBlock1, Areas1, ref ChildObj1);
        ResetArea(cycleBlock2, Areas2, ref ChildObj2);

        MoveArea(cycleBlock1);  // ������ �ӵ��� ��� �̵�
        MoveArea(cycleBlock2);
    }


    // ��� �ʱ�ȭ �� ��ġ �缳��
    public void ResetArea(GameObject cycleBlock, List<GameObject> Areas, ref GameObject ChildObj)
    {
        if (cycleBlock.transform.position.x <= -GameDataManager.Instance.blockSize)
        {
            // ���� �ִ� Area��Ȱ��ȭ
            ChildObj.SetActive(false);

            // ��ġ�� �ʱ�ȭ
            //cycleBlock.transform.position = targetPos;
            cycleBlock.transform.position
                = new Vector2(cycleBlock.transform.position.x + GameDataManager.Instance.blockSize/*�� ũ��*/ * 2/*��� ����*/
                , cycleBlock.transform.position.y);
            // Area���� �̱�
            SelectArea(Areas, ref ChildObj);
        }
    }

    // ������ ��� �̱� & Ȱ��ȭ
    public void SelectArea(List<GameObject> Areas, ref GameObject ChildObj)
    {
        ChildObj = GetRandomChild(Areas);
        ChildObj.SetActive(true);
    }



    // ��� ������
    private void MoveArea(GameObject cycleBlock)
    {
        speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            cycleBlock.transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
        }
    }

}
