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

    public void EnemyDead()
    {
        isDead = true;
        animator.SetBool("dead", true);
        Destroy(gameObject, 2f);
    }
}
