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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 15f;
        rb.velocity = Vector3.forward * speed;
        timeSpawn = 5.0f;
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
        Debug.Log("colisio");
    }
}
