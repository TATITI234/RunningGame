using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyPos : MonoBehaviour
{
    public List<GameObject> jellys = new();     // 젤리들(패턴이 뽑힐 때 마다 초기화됨)
    public List<Vector3> jellyPos = new();   // 젤리 초기 위치값들(패턴이 뽑힐 때 마다 초기화됨)
    /*
    public static JellyPos instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }*/

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform Child = transform.GetChild(i);
            jellys.Add(Child.gameObject);
            jellyPos.Add(Child.position);
        }
    }

}
