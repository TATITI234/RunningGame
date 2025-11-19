using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private float speed;
    private float startHp;
    private float score;
    public Text speedText;
    public Text scoreText;

    public Scrollbar hpBar;
    
    public Animator animator;


    void Start()
    {
        startHp = GameDataManager.Instance.hp;
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        // 스피드, 점수 업데이트
        speed = GameDataManager.Instance.speed;
        speedText.text = speed.ToString();

        score = GameDataManager.Instance.score;
        scoreText.text = String.Format("{0:#,0}", score);


        if (GameStateManager.Instance.currentState == GameStateManager.GameState.GameOver)
        {
            
            animator.Play("Shock");
            Debug.Log("게임오버 재생");

        }

        hpBar.size = GameDataManager.Instance.hp / startHp;
    }
}
