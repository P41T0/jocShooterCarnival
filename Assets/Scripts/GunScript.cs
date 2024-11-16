using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletSpawner;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject hand;
    private float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        delayTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTime >= 0)
        {
            delayTime -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, BulletSpawner.transform.position, hand.transform.rotation);
            }
        }

    }
}
