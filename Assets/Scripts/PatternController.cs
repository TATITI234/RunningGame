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
    private void Awake()
    {
        // patterns배열에 패턴들 저장
        for(int i = 0; i < transform.childCount; i++)
        {
            patterns.Add(transform.GetChild(i).gameObject);

        }
        currentPattern = patterns[Random.Range(0, patterns.Count)];
    }

    private void OnEnable()
    {
        if (patterns == null || patterns.Count == 0)
        {
            Debug.LogError($"patterns배열이 비었거나 0이다. 배열비었나?{patterns == null}, 배열길이{patterns.Count}");
            return;
        }
        ResetPattren();
    }
    public void ResetPattren()
    {
        Debug.Log("ResetPattren 시작");

        JellyPos JellyComp = currentPattern.GetComponent<JellyPos>();
        
        if (currentPattern.transform.childCount != JellyComp.jellys.Count
            || JellyComp.jellys.Count != JellyComp.jellyPos.Count)
        {
            Debug.LogError($"패턴수가 일치하지 않는다{currentPattern.transform.childCount},{currentPattern.GetComponent<JellyPos>().jellys.Count} 혹은 젤리옵젝과 젤리위치수가 일치하지 않는다{currentPattern.GetComponent<JellyPos>().jellys.Count},{currentPattern.GetComponent<JellyPos>().jellyPos.Count}");
            return;
        }
        
        currentPattern.SetActive(false);
        for (int i = 0; i < JellyComp.jellys.Count; i++)
        {
            
            JellyComp.jellys[i].transform.position = JellyComp.jellyPos[i];
        }
        Debug.Log("초기화 완료");
        SelectPattren();
    }

    public void SelectPattren()
    {
        currentPattern = patterns[Random.Range(0, patterns.Count)];
        currentPattern.SetActive(true);

    }


}
