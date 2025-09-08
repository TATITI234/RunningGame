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
    // 블록 생성
    public void GenerateArea(GameObject area)
    {
        area = Instantiate(Areas[Random.Range(0, Areas.Count)], targetPos, Quaternion.identity);
        childObj = Areas[Random.Range(0, Areas.Count)]
    }

    // 블록 움직임
    private void MoveArea(GameObject area)
    {
        if (isMove)
        {
            area.transform.Translate(new Vector2(-0.1f * speed, 0));

        }
    }
}
