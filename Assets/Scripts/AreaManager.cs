using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 블록 종류를 ㅈㄴ 많이 만들고 블록들을 한 오브젝트의 자식으로 둔 뒤
// 자식 오브젝트 중 하나를 랜덤으로 뽑아서 액티브 온
// 화면에서 블록이 사라지면 
public class AreaManager : MonoBehaviour
{
    public List<GameObject> Areas;  // 블록 종류
    public Vector2 targetPos;   // 블록이 생성될 위치

    public GameObject areasPrefab;  // 모든 종류 블록의 부모 프리팹

    [SerializeField] private float speed = 2;   // 블록 스피드
    public bool isMove = true;  // 블록이 움직일 수 있는지 여부

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

    // 생성할 블록 뽑기
    public void SelectArea()
    {
        afterChildObj = Areas[Random.Range(0, Areas.Count)];
    }

    // 블록 생성 & 이전 블록 이동
    public void GenerateArea(GameObject area)
    {
        afterChildObj.SetActive(true);

    }

    // 블록 초기화 및 위치 재설정
    public void ResetArea()
    {
            beforeChildObj.SetActive(false);
            beforeChildObj.transform.position = targetPos;
            beforeChildObj = afterChildObj;
    }

    // 블록 움직임
    private void MoveArea(GameObject area)
    {
        if (isMove)
        {
            area.transform.Translate(new Vector2(-0.1f * speed, 0));

        }
    }

    // 임의로 이동시키게 하기
    public void Move(GameObject area)
    {
        if (isMove)
        {
            area.transform.Translate(new Vector2(-0.1f * speed, 0));
            Destroy(area, 5.0f);
        }
    }
}
