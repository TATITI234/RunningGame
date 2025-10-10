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

    public float speed = 2;   // 블록 스피드
<<<<<<< Updated upstream
    public GameObject Jellys;
=======
    public float blockSize = 18;    // 블록의 크기
>>>>>>> Stashed changes

    public List<GameObject> jellyObj = new List<GameObject>();
    private void Start()
    {/*
        for (int i = 0; i < Jellys.transform.childCount; i++)
        {
            
            jellyObj.Add(Jellys.transform.GetChild(i).gameObject);
        }*/
        /* foreach 를 사용하면? */
        foreach (Transform child in Jellys.transform)
        {
            // 위치값 오브젝트 배열에 저장하기
            jellyObj.Add(child.gameObject);
        }
       

    }
}
