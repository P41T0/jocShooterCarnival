using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletSpawner;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip gunSound;
    private AudioSource gunSource;
    private float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        gunSource = GetComponent<AudioSource>();
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
            gunSource.Stop();
            gunSource.clip = gunSound;
            gunSource.Play();
            GameObject bulletInstantiated = Instantiate(bullet, BulletSpawner.transform.position, Quaternion.identity);
            delayTime = 0.4f;
            bulletInstantiated.GetComponent<BulletScript>().SetBulletRotationDir(gameObject.transform.forward);
        }
    }
}
