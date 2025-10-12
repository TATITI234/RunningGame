using System.Collections.Generic;
using UnityEngine;

/*
 패턴들의 부모 오브젝트에 부착
    어떤 패턴이 활성화될지 결정
 */
public class PatternController : MonoBehaviour
{
    public List<GameObject> patterns = new();   // 패턴들
    public GameObject currentPattern = null;   // 현재 뽑은 패턴

    // 패턴들을 Pattern 리스트에 저장
    private void FuckingJelly()
    {
        Debug.Log("FuckingJelly실행됨~~~");
        // Jelly들 위치 저장
        JellyPos[] jellyList = GetComponentsInChildren<JellyPos>(true);
        Debug.Log(jellyList);
        foreach (JellyPos JellyComp in jellyList)
        {
            if (JellyComp != null)
                JellyComp.FillJellys();
            Debug.Log("젤리들 위치 저장됨!!!!!");
        }


    }

    public void ResetSign()
    {
        Debug.Log("ResetSign호출됨");
        // patterns배열에 패턴들 저장
        for(int i = 0; i < transform.childCount; i++)
        {
            patterns.Add(transform.GetChild(i).gameObject);

        }
        currentPattern = patterns[Random.Range(0, patterns.Count)];

        Debug.Log("patterns리스트 채워짐");

        if (patterns == null || patterns.Count == 0)
        {
            Debug.LogError($"patterns배열이 비었거나 0이다. 배열비었나?{patterns == null}, 배열길이{patterns.Count}");
            return;
        }
        FuckingJelly();
        ResetPattren();
    }

    public void ResetPattren()
    {
        Debug.Log("ResetPattren 시작");

        JellyPos JellyComp = currentPattern.GetComponent<JellyPos>();

        if (currentPattern.transform.childCount != JellyComp.jellys.Count
            || JellyComp.jellys.Count != JellyComp.jellyPos.Count)
        {
            Debug.LogError($"패턴수가 일치하지 않는다" +
                $"{currentPattern.transform.childCount}" +
                $",{currentPattern.GetComponent<JellyPos>().jellys.Count} " +
                $"혹은 젤리옵젝과 젤리위치수가 일치하지 않는다" +
                $"{currentPattern.GetComponent<JellyPos>().jellys.Count}" +
                $",{currentPattern.GetComponent<JellyPos>().jellyPos.Count}");
            return;
        }
        
        currentPattern.SetActive(false);
        for (int i = 0; i < JellyComp.jellys.Count; i++)
        {
            JellyComp.jellys[i].SetActive(false);
            JellyComp.jellys[i].transform.position = JellyComp.jellyPos[i];
            JellyComp.jellys[i].SetActive(true);


        }
        
        SelectPattren();
    }

    public void SelectPattren()
    {
        currentPattern = patterns[Random.Range(0, patterns.Count)];
        currentPattern.SetActive(true);
        Debug.Log("초기화 완료");
    }


}
