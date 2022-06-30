using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strikeanim : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("strike");
        }
    }
}
