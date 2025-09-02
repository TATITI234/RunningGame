using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundController : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    public bool isMove = true;

    void Start()
    {

    }
    private void Update()
    {
        /*
        if (transform.position.x < -18)
        {
            transform.position = new Vector2(18, transform.position.y);
        }*/

    }
    void FixedUpdate()
    {
        if (isMove)
        {
            transform.Translate(new Vector2(-0.1f * speed, 0));
        }

    }
}
