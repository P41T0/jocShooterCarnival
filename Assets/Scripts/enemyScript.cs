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
    public bool GetIsDead() { 
        return isDead;
    }

    public void EnemyDead()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetBool("dead", true);
            Invoke("moveDeath", 1.3f);
            Destroy(gameObject, 4f);
            print("mort");

        }
    }

    public void moveDeath() {
        transform.position -= new Vector3(0, 0.9f, 0);
    }
}
