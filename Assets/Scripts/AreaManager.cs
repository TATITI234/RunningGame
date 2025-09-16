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

    private GameObject beforeChildObj;
    private GameObject afterChildObj;

    public static AreaManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {

    }


    private void FixedUpdate()
    {
        MoveArea(areasPrefab);

    }

    private void Update()
    {
        if (areasPrefab.transform.position.x <= 0)
        {
            GenerateArea(areasPrefab);
        }
        if (afterChildObj.transform.position.x <= (targetPos.x - 18))
        {
            ResetArea();
        }

    }

    // ������ ��� �̱�
    public void SelectArea()
    {
        afterChildObj = Areas[Random.Range(0, Areas.Count)];
    }

    // ��� ���� & ���� ��� �̵�
    public void GenerateArea(GameObject area)
    {
        afterChildObj.SetActive(true);

    }

    // ��� �ʱ�ȭ �� ��ġ �缳��
    public void ResetArea()
    {
            beforeChildObj.SetActive(false);
            beforeChildObj.transform.position = targetPos;
            beforeChildObj = afterChildObj;
    }

    // ��� ������
    private void MoveArea(GameObject area)
    {
        if (isMove)
        {
            area.transform.Translate(new Vector2(-0.1f * speed, 0));

        }
    }

    // ���Ƿ� �̵���Ű�� �ϱ�
    public void Move(GameObject area)
    {
        if (isMove)
        {
            area.transform.Translate(new Vector2(-0.1f * speed, 0));
            Destroy(area, 5.0f);
        }
    }
}
