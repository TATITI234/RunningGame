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
