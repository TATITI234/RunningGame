using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public List<GameObject> Areas;
    public Vector2 targetPos;

    GameObject area;


    void Start()
    {
        GenerateArea();
    }

    void Update()
    {
        if (area.transform.position.x <= 0)
        {
            GenerateArea();
        }
    }

    public void GenerateArea()
    {
        area = Instantiate(Areas[Random.Range(0, Areas.Count)], targetPos, Quaternion.identity);
        
    }
}
