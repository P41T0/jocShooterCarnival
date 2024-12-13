using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("bullet") && !isDead)
        {
            isDead = true; 
            animator.SetBool("dead", true);
        }
    }
}
