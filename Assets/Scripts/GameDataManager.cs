using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance = null;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public float speed = 2;   // ��� ���ǵ�
<<<<<<< Updated upstream
    public GameObject Jellys;
=======
    public float blockSize = 18;    // ����� ũ��
>>>>>>> Stashed changes

    public List<GameObject> jellyObj = new List<GameObject>();
    private void Start()
    {/*
        for (int i = 0; i < Jellys.transform.childCount; i++)
        {
            
            jellyObj.Add(Jellys.transform.GetChild(i).gameObject);
        }*/
        /* foreach �� ����ϸ�? */
        foreach (Transform child in Jellys.transform)
        {
            // ��ġ�� ������Ʈ �迭�� �����ϱ�
            jellyObj.Add(child.gameObject);
        }
       

    }
}
