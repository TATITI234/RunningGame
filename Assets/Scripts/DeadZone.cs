using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        
    }

    public void Dead()
    {
        animator.Play("Dead");
        Debug.Log("DeadÀç»ý");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
