using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private float speed;
    public Text speedText;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameDataManager.Instance.speed;
        speedText.text = speed.ToString();
        score.text = $"{GameDataManager.Instance.score} Á¡";
    }
}
