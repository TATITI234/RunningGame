using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPoint : MonoBehaviour
{
    private bool isCollided = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollided)
        {
            isCollided = true;
            GameDataManager.Instance.speed = 0;
        }

    }
}
