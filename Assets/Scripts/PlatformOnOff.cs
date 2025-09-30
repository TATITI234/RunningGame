using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
플레이어의 Y좌표를 가져와서 자기자신(플랫폼)보다 높이 있으면
 콜라이더를 활성화시켜서 올라탈 수 있게 만들기
 */
public class PlatformOnOff : MonoBehaviour
{
    // 플레이어 높이를 가져올 플레이어 트랜스폼
    public Transform Player;

    private bool falling;
    void Start()
    {
        // Player태그인 오브젝트를 찾아서 트랜스폼 할당(FindWithFag : 모든 오브젝트를 검사함)
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {


    }
    void Update()
    {
        if(Player.GetComponent<Rigidbody2D>().velocity.y < 0.01f)
        {
            falling = true;
            Debug.Log(falling);
        }
        else
        {
            falling = false;
            Debug.Log(falling);

        }
        // 플레이어의 발바닥 위치가 플랫폼보다 높으면 콜라이더를 활성화시키기
        if (Player.position.y - (Player.transform.GetComponent<BoxCollider2D>().size.y / 2)
            + 0.1f >= transform.position.y// + (transform.localScale.y / 2) // 빠른 속도로 떨어질 때 순간적으로 오브젝트를 뚫어서 보정값을 줌
            && falling)
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            transform.GetComponent<Collider2D>().enabled = false;

        }
    }

}
