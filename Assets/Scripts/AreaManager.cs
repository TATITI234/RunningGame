using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public List<GameObject> Areas;
    public Vector2 targetPos;

    public GameObject areas1;
    public GameObject areas2;

    [SerializeField] private float speed = 2;
    public bool isMove = true;



    private void Awake()
    {

    }
    private void Start()
    {
        GenerateArea();
    }


    void FixedUpdate()
    {
        if (isMove)
        {
            transform.Translate(new Vector2(-0.1f * speed, 0));
        }

    }
    private void Update()
    {
        if (areas1.transform.position.x <= 0)
        {
            GenerateArea(areas2);
        }
        else if(areas2.transform.position.x <= 0)
        {
            GenerateArea(areas1);
        }

    }

    public void GenerateArea(GameObject area)
    {
        area = Instantiate(Areas[Random.Range(0, Areas.Count)], targetPos, Quaternion.identity);

    }
}
