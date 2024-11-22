using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{ 
    public float speed = 5f; // Velocidad del personaje

    void Update()
    {
        // Mover al personaje en línea recta hacia adelante (eje Z)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
