using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    List<GameObject> Areas;
    public Vector2 targetPos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenerateArea()
    {
        Instantiate(Areas[Random.Range(0, Areas.Count)], targetPos, Quaternion.identity);
        
    }
}
