using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 블록 종류를 ㅈㄴ 많이 만들고 블록들을 한 오브젝트의 자식으로 둔 뒤
// 자식 오브젝트 중 하나를 랜덤으로 뽑아서 액티브 온
// 화면에서 블록이 사라지면 
public class AreaManager : MonoBehaviour
{
    public List<GameObject> Areas;  // 블록 종류
    public Vector2 targetPos;   // 블록이 이동할 위치
    [SerializeField]private GameObject jellyGenerator;
    
    private float speed;   // 블록 스피드
    public bool isMove = true;  // 블록이 움직일 수 있는지 여부

    private GameObject ChildObj = null;    // 껐다 킬 오브젝트

    // public static AreaManager instance = null;


    private void Awake()
    {
        //if (instance == null)
        //    instance = this;

    }
    private void Start()
    {
        // 자식 오브젝트 배열에 저장하기
        for (int i = 0; i < transform.childCount; i++)
        {
            Areas.Add(transform.GetChild(i).gameObject);
        }
        ChildObj = Areas[Random.Range(0, transform.childCount)];

        jellyGenerator = ChildObj.transform.GetComponentInChildren<JellyGenerator>().gameObject;
    }


    private void FixedUpdate()
    {
        MoveArea(transform.gameObject);  // 일정한 속도로 계속 이동

    }

    private void Update()
    {
        // 블록이 화면 뒤로 넘어가면 초기화 로직 실행
        if (transform.position.x <= -18)
        {
            jellyGenerator.SendMessage("DestroyCoin", SendMessageOptions.DontRequireReceiver);

            ResetArea();
        }

    }

    // 생성할 블록 뽑기 & 활성화
    public void SelectArea()
    {
        ChildObj = Areas[Random.Range(0, transform.childCount)];
        ChildObj.SetActive(true);
        jellyGenerator.SendMessage("GenerateCoin", SendMessageOptions.DontRequireReceiver);

    }

    // 블록 초기화 및 위치 재설정
    public void ResetArea()
    {
        ChildObj.SetActive(false);
        transform.position = targetPos;

        SelectArea();
    }

    // 블록 움직임
    private void MoveArea(GameObject area)
    {
        speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            transform.Translate(new Vector2(-0.1f * speed, 0));
        }
    }

}
