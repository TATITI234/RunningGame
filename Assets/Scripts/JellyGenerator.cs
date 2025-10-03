using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ��ġ�� ��Ÿ���� �� ������Ʈ�� ��ġ[�迭] �޾ƿ´�.
// ������Ʈ�� Ȱ��ȭ ���� ��, �޾ƿ� ��ġ�鿡 ���� ������Ʈ[�迭]�� �̵������ش�.
// (��ġ�� ������Ʈ �迭 ���̰� ���� ������Ʈ �迭 ���̺��� ���ٸ� ��ġ�� ������Ʈ ���� ������ �����´�)
// Area�� �ʱ�ȭ�� �� �����鵵 ���ڸ��� �������´�.
// �����⼭ ������ �߻�(���ư��� Area�� �� ���ε� �޾ƿ� �������� ���� ������ �����Ϸ���
//    ���� ������ ������ ȸ���ؾ���. �ٵ� �װ� �ȸ������ �ù� ������ �Ա� ���� �����.
public class JellyGenerator : MonoBehaviour
{
    public List<GameObject> jellyPos = new List<GameObject>();
    public List<GameObject> jellyObj = new List<GameObject>();

    private GameObject Area;
    private GameObject jellys;

    void Start()
    {
        // ��ġ�� ������Ʈ �迭�� �����ϱ�
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
        // ��ġ�� ������Ʈ ��ġ�� ���� ������Ʈ�� ��ġ�ϱ�
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
            Debug.LogError($"{jellyObj}�� ����ֽ��ϴ�!");
            return;
        }
        //  ���� ������Ʈ�� �ʱ�ȭ�ϱ�
        for (int i = 0; i < jellyPos.Count; i++)
        {
            GameDataManager.Instance.jellyObj[i].transform.position = Vector3.zero;
            GameDataManager.Instance.jellyObj[i].SetActive(false);
            GameDataManager.Instance.jellyObj[i].transform.SetParent(jellys.transform);
        }

    }
}
