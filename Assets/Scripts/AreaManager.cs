using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 AreaManager 수정 - 
역할 : AreaManager오브젝트에 붙음. 
에디터에서 두 개의 순환블록 각각 할당.  
각 순환블록의 자식 오브젝트를 Areas1,Areas2배열에 저장.
각 순환블록의 자식 오브젝트 중 하나를 랜덤으로 뽑아서 활성화
	순환블록의 위치를 이용해 초기화할지 검사함.
	초기화 함수가 실행되면 해당 순환블록을 인수로 받아
	블록의 자식 랜덤뽑기 메서드 실행
 */
public class AreaManager : MonoBehaviour
{
    public GameObject cycleBlock1;  // 순환블록
    public GameObject cycleBlock2;
    public List<GameObject> Areas1 = new();  // 뽑기할 Area들을 저장할 배열
    public List<GameObject> Areas2 = new();  
    
    private float speed;   // 블록 스피드
    public bool isMove = true;  // 블록이 움직일 수 있는지 여부

    private GameObject ChildObj1 = null;    // 껐다 킬 오브젝트
    private GameObject ChildObj2 = null;

    // public static AreaManager instance = null;


    private void Awake()
    {
        //if (instance == null)
        //    instance = this;

    }
    private void Start()
    {

        // 자식 오브젝트 배열에 저장하기
        SetChild(cycleBlock1, Areas1);
        SetChild(cycleBlock2, Areas2);
        ChildObj1 = GetRandomChild(Areas1);
        ChildObj2 = GetRandomChild(Areas2);
    }

    // cycleBlock과 Areas를 인수로 받아 자식 오브젝트로 상속
    private void SetChild(GameObject cycleBlock, List<GameObject> Areas)
    {/*
        Debug.Log("cycleBlock의 이름: " + cycleBlock.name);
        Debug.Log("cycleBlock의 자식 수: " + cycleBlock.transform.childCount);
     */
        for (int i = 0; i < cycleBlock.transform.childCount; i++)
        {
            Areas.Add(cycleBlock.transform.GetChild(i).gameObject);
        }
    }

    // Areas 배열을 인수로 받아 그 중 랜덤으로 하나 추출
    private GameObject GetRandomChild(List<GameObject> Areas)
    {
        GameObject ChildObj = Areas[Random.Range(0, Areas.Count)];
        return ChildObj;
    }

    private void Update()
    {
        // 블록이 화면 뒤로 넘어가면 초기화 로직 실행
        ResetArea(cycleBlock1, Areas1, ref ChildObj1);
        ResetArea(cycleBlock2, Areas2, ref ChildObj2);

        MoveArea(cycleBlock1);  // 일정한 속도로 계속 이동
        MoveArea(cycleBlock2);
    }


    // 블록 초기화 및 위치 재설정
    public void ResetArea(GameObject cycleBlock, List<GameObject> Areas, ref GameObject ChildObj)
    {
        if (cycleBlock.transform.position.x <= -GameDataManager.Instance.blockSize)
        {
            // 원래 있던 Area비활성화
            ChildObj.SetActive(false);

            // 위치값 초기화
            //cycleBlock.transform.position = targetPos;
            cycleBlock.transform.position
                = new Vector2(cycleBlock.transform.position.x + GameDataManager.Instance.blockSize/*내 크기*/ * 2/*블록 갯수*/
                , cycleBlock.transform.position.y);
            // Area새로 뽑기
            SelectArea(Areas, ref ChildObj);
        }
    }

    // 생성할 블록 뽑기 & 활성화
    public void SelectArea(List<GameObject> Areas, ref GameObject ChildObj)
    {
        ChildObj = GetRandomChild(Areas);
        ChildObj.SetActive(true);
    }



    // 블록 움직임
    private void MoveArea(GameObject cycleBlock)
    {
        speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            cycleBlock.transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
        }
    }

}
