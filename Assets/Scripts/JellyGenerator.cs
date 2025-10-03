using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 젤리들의 위치를 나타내는 빈 오브젝트의 위치[배열] 받아온다.
// 오브젝트가 활성화 됐을 때, 받아온 위치들에 젤리 오브젝트[배열]를 이동시켜준다.
// (위치값 오브젝트 배열 길이가 젤리 오브젝트 배열 길이보다 적다면 위치값 오브젝트 갯수 까지만 가져온다)
// Area가 초기화될 때 젤리들도 제자리로 돌려놓는다.
// ㄴ여기서 문제가 발생(돌아가는 Area는 두 개인데 받아온 젤리들을 다음 구역에 생성하려면
//    이전 구역의 젤리를 회수해야함. 근데 그걸 안만들었음 시발 젤리를 먹기 전에 사라짐.
public class JellyGenerator : MonoBehaviour
{
    public List<GameObject> jellyPos = new List<GameObject>();
    public List<GameObject> jellyObj = new List<GameObject>();

    private GameObject Area;
    private GameObject jellys;

    void Start()
    {
        // 위치값 오브젝트 배열에 저장하기
        for(int i = 0; i < transform.childCount; i++)
        {
            jellyPos.Add(transform.GetChild(i).gameObject);
        }
        jellyObj = GameDataManager.Instance.jellyObj;
        Area = transform.parent.gameObject;
        jellys = GameDataManager.Instance.Jellys;

    }

    void Update()
    {
        
    }

    public void GenerateCoin()
    {
        // 위치값 오브젝트 위치에 젤리 오브젝트들 배치하기
        for (int i = 0; i < jellyPos.Count; i++)
        {
            GameDataManager.Instance.jellyObj[i].transform.position = jellyPos[i].transform.position;
            GameDataManager.Instance.jellyObj[i].SetActive(true);
            GameDataManager.Instance.jellyObj[i].transform.SetParent(Area.transform);
        }

    }

    public void DestroyCoin()
    {
        if(jellyObj == null || jellyObj.Count == 0)
        {
            Debug.LogError($"{jellyObj}가 비어있습니다!");
            return;
        }
        //  젤리 오브젝트들 초기화하기
        for (int i = 0; i < jellyPos.Count; i++)
        {
            GameDataManager.Instance.jellyObj[i].transform.position = Vector3.zero;
            GameDataManager.Instance.jellyObj[i].SetActive(false);
            GameDataManager.Instance.jellyObj[i].transform.SetParent(jellys.transform);
        }

    }
}
