using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ��� ������ ���� ���� ����� ��ϵ��� �� ������Ʈ�� �ڽ����� �� ��
// �ڽ� ������Ʈ �� �ϳ��� �������� �̾Ƽ� ��Ƽ�� ��
// ȭ�鿡�� ����� ������� 
public class AreaManager : MonoBehaviour
{
    public List<GameObject> Areas;  // ��� ����
    public Vector2 targetPos;   // ����� �̵��� ��ġ
    [SerializeField]private GameObject jellyGenerator;
    
    private float speed;   // ��� ���ǵ�
    public bool isMove = true;  // ����� ������ �� �ִ��� ����

    private GameObject ChildObj = null;    // ���� ų ������Ʈ

    // public static AreaManager instance = null;


    private void Awake()
    {
        //if (instance == null)
        //    instance = this;

    }
    private void Start()
    {
        // �ڽ� ������Ʈ �迭�� �����ϱ�
        for (int i = 0; i < transform.childCount; i++)
        {
            Areas.Add(transform.GetChild(i).gameObject);
        }
        ChildObj = Areas[Random.Range(0, transform.childCount)];

        jellyGenerator = ChildObj.transform.GetComponentInChildren<JellyGenerator>().gameObject;
    }


    private void FixedUpdate()
    {
        MoveArea(transform.gameObject);  // ������ �ӵ��� ��� �̵�

    }

    private void Update()
    {
        // ����� ȭ�� �ڷ� �Ѿ�� �ʱ�ȭ ���� ����
        if (transform.position.x <= -18)
        {
            jellyGenerator.SendMessage("DestroyCoin", SendMessageOptions.DontRequireReceiver);

            ResetArea();
        }

    }

    // ������ ��� �̱� & Ȱ��ȭ
    public void SelectArea()
    {
        ChildObj = Areas[Random.Range(0, transform.childCount)];
        ChildObj.SetActive(true);
        jellyGenerator.SendMessage("GenerateCoin", SendMessageOptions.DontRequireReceiver);

    }

    // ��� �ʱ�ȭ �� ��ġ �缳��
    public void ResetArea()
    {
        ChildObj.SetActive(false);
        transform.position = targetPos;

        SelectArea();
    }

    // ��� ������
    private void MoveArea(GameObject area)
    {
        speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            transform.Translate(new Vector2(-0.1f * speed, 0));
        }
    }

}
