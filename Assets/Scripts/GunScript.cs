using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletSpawner;
    [SerializeField] private GameObject bullet;
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
        

    }
    public void Shoot()
    {
        if (delayTime < 0)
        {
            GameObject bulletInstantiated = Instantiate(bullet, BulletSpawner.transform.position, gameObject.transform.rotation);
            delayTime = 0.3f;
            bulletInstantiated.GetComponent<BulletScript>().SetBulletRotationDir(gameObject.transform.forward);
        }
    }
}
