using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,0f,-10f);// nueva posición de la camara.
    private Vector3 velocidad = Vector3.zero;//velocidad a la que se mueve la camara
    private float cameraMovementSmooth = 0.25f; //Variación de velocidad 
    

    [SerializeField] private Transform target;//El transform del personaje

    private void FixedUpdate()
    {
        Vector3 posicionObjetivo = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, posicionObjetivo, ref velocidad, cameraMovementSmooth);
    }

}
