using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float speed;
    public bool isMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (transform.position.x < -18)
        {
            transform.position = new Vector2(18, transform.position.y);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMove)
        {
            transform.Translate(new Vector2(-0.1f * speed, 0));
        }

    }
}
