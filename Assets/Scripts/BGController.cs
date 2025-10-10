using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;
    public GameObject BG4;
    public GameObject BG5;

    private float speed;

    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = BG1.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameDataManager.Instance.speed;
        Scrolling(BG1, 5);
        Scrolling(BG2, 4);
        Scrolling(BG3, 3);
        Scrolling(BG4, 1);
        Scrolling(BG5, 0.5f);
    }

    private void Scrolling(GameObject BG, float moveSpeed)
    {
        if(BG.transform.localPosition.x <= -1672)
        {
            BG.transform.localPosition = defaultPos;
        }
        BG.transform.Translate(-0.01f * speed * moveSpeed * 50 * Time.deltaTime, 0, 0);
    }
}
