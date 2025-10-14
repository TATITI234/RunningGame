using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 순환 블록 관리 스크립트 -
 역할 : 자식 랜덤으로 껐다켜기, 이동해줌
    순환블록의 자식 오브젝트를 Areas배열에 저장.
    순환블록의 자식 오브젝트 중 하나를 랜덤으로 뽑아서 활성화
	순환블록의 위치를 이용해 초기화할지 검사함.
	초기화 함수가 실행되면 해당 순환블록을 인수로 받아
	블록의 자식 랜덤뽑기 메서드 실행
 */
public class CycleBlockController : MonoBehaviour
{
    public List<GameObject> areas;  // AreaPart 종류

    private float speed;   // 겜데타메니저에서 받아올 블록 스피드
    public bool isMove = true;  // 블록이 움직일 수 있는지 여부

    private GameObject childObj = null;    // 껐다 킬 오브젝트

    private void Start()
    {
        // 자식 오브젝트 배열에 저장하기
        for (int i = 0; i < transform.childCount; i++)
        {
            areas.Add(transform.GetChild(i).gameObject);
        }
        // 시작할 때 임의로 하나 지정
        childObj = GetRandomChild(areas);

    }

    private void Update()
    {
        // 일정한 속도로 계속 이동
        MoveArea();  

        // 블록이 화면 뒤로 넘어가면 초기화 로직 실행
        if (transform.position.x <= -GameDataManager.Instance.blockSize)
        {
            ResetArea();
        }

    }

    // 생성할 블록 뽑기 & 활성화
    public void SelectArea()// 뭐 어쩌라고
    {
        childObj = GetRandomChild(areas);
        GameObject Pattern = childObj.GetComponentInChildren<JellyPos>(true).gameObject;
        Pattern.SetActive(true);
        childObj.SetActive(true);

    }

    // 블록 초기화 및 위치 재설정
    public void ResetArea()
    {
        childObj.SetActive(false);
        transform.position = new Vector2(transform.position.x
            + GameDataManager.Instance.blockSize/*내 크기*/ * 2/*블록 갯수*/, transform.position.y);

        SelectArea();
    }

    // Areas 배열을 인수로 받아 그 중 랜덤으로 하나 추출
    private GameObject GetRandomChild(List<GameObject> Areas)
    {
        GameObject ChildObj = Areas[Random.Range(0, Areas.Count)];
        return ChildObj;
    }

    // 블록 움직임
    private void MoveArea()
    {
        speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, 0);
        }
    }

}

