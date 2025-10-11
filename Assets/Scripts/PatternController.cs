using System.Collections.Generic;
using UnityEngine;

/*
 ���ϵ��� �θ� ������Ʈ�� ����
    � ������ Ȱ��ȭ���� ����
 */
public class PatternController : MonoBehaviour
{
    public List<GameObject> patterns = new();   // ���ϵ�
    public GameObject currentPattern = null;   // ���� ���� ����

    // ���ϵ��� Pattern ����Ʈ�� ����
    private void Awake()
    {
        // patterns�迭�� ���ϵ� ����
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
            Debug.LogError($"patterns�迭�� ����ų� 0�̴�. �迭�����?{patterns == null}, �迭����{patterns.Count}");
            return;
        }
        ResetPattren();
    }
    public void ResetPattren()
    {
        Debug.Log("ResetPattren ����");

        JellyPos JellyComp = currentPattern.GetComponent<JellyPos>();
        
        if (currentPattern.transform.childCount != JellyComp.jellys.Count
            || JellyComp.jellys.Count != JellyComp.jellyPos.Count)
        {
            Debug.LogError($"���ϼ��� ��ġ���� �ʴ´�{currentPattern.transform.childCount},{currentPattern.GetComponent<JellyPos>().jellys.Count} Ȥ�� ���������� ������ġ���� ��ġ���� �ʴ´�{currentPattern.GetComponent<JellyPos>().jellys.Count},{currentPattern.GetComponent<JellyPos>().jellyPos.Count}");
            return;
        }
        
        currentPattern.SetActive(false);
        for (int i = 0; i < JellyComp.jellys.Count; i++)
        {
            
            JellyComp.jellys[i].transform.position = JellyComp.jellyPos[i];
        }
        Debug.Log("�ʱ�ȭ �Ϸ�");
        SelectPattren();
    }

    public void SelectPattren()
    {
        currentPattern = patterns[Random.Range(0, patterns.Count)];
        currentPattern.SetActive(true);

    }


}
