using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     //사용시 꼭 작성

public class animalAnimationControll : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Death", false);
    }


    public void animateAnimalDeath()
    {
        Debug.Log("된다");
        animator.SetBool("Death", true);
    }

}
