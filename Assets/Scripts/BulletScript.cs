using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private Rigidbody rb;
    private float timeSpawn;
    SCScript sCScript;
    void Start()
    {
        sCScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SCScript>();
    }
    public void SetBulletRotationDir(Vector3 forwardDir, Quaternion rotation)
    {
        speed = 25f;
        timeSpawn = 5f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = forwardDir * speed;
        gameObject.transform.rotation = rotation;
    }
    // Update is called once per frame
    void Update()
    {

        timeSpawn -= Time.deltaTime;
        if (timeSpawn < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<enemyScript>().GetIsDead() == false)
            {
                sCScript.IncreaseScore();
                collision.gameObject.GetComponent<enemyScript>().EnemyDead();
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Cart"))
        {
            collision.gameObject.GetComponent<TrainScript>().KillPassenger();
        }
    } 
}
