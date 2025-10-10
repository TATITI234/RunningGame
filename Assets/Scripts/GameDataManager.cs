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
    public float blockSize = 18;    // 블록의 크기


}
