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
    public void SetBulletRotationDir(Vector3 forwardDir)
    {
        rb = GetComponent<Rigidbody>();
        speed = 15f;
        timeSpawn = 5.0f;
        rb.velocity = forwardDir * speed;
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
    private void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            sCScript.IncreaseScore();
        }
        if (!other.CompareTag("BulletCanPass"))
        {
            Destroy(gameObject);
        }
    }   
}
