using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundController : MonoBehaviour
{

    void Start()
    {

    }

    public bool isMove = true;

    void Update()
    {
        float speed = GameDataManager.Instance.speed;

        if (isMove)
        {
            transform.Translate(new Vector2(-Time.deltaTime * speed, 0));
        }

    }
}
