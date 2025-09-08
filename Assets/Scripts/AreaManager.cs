using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ������ ���� ���� ����� ��ϵ��� �� ������Ʈ�� �ڽ����� �� ��
// �ڽ� ������Ʈ �� �ϳ��� �������� �̾Ƽ� ��Ƽ�� ��
// ȭ�鿡�� ����� ������� 
public class AreaManager : MonoBehaviour
{
    public List<GameObject> Areas;  // ��� ����
    public Vector2 targetPos;   // ����� ������ ��ġ

    public GameObject areasPrefab;  // ��� ���� ����� �θ� ������

    [SerializeField] private float speed = 2;   // ��� ���ǵ�
    public bool isMove = true;  // ����� ������ �� �ִ��� ����

    private GameObject childObj;    // 

    private void Awake()
    {

    }
    private void Start()
    {
    }


    void FixedUpdate()
    {
        MoveArea(areasPrefab);

    }

    private void Update()
    {
        if (areasPrefab.transform.position.x <= 0)
        {
            GenerateArea(areasPrefab);
        }


    }
    // ��� ����
    public void GenerateArea(GameObject area)
    {
        area = Instantiate(Areas[Random.Range(0, Areas.Count)], targetPos, Quaternion.identity);
        childObj = Areas[Random.Range(0, Areas.Count)]
    }

    // ��� ������
    private void MoveArea(GameObject area)
    {
        if (isMove)
        {
            area.transform.Translate(new Vector2(-0.1f * speed, 0));

        }
    }
}
