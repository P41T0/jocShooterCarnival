using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public float speed = 5f;
    public GameObject rider;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void KillPassenger()
    {
        if (rider.GetComponent<enemyScript>().GetIsDead())
        {
            rider.GetComponent<enemyScript>().EnemyDead();
        }
    }
}

