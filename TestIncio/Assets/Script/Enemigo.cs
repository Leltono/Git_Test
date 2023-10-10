using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform pointA; //los puntos en el mapa hasta los que se mueve mi personaje y luego gira
    [SerializeField] Transform pointB;

    bool estaMirandoDerecha;

    [SerializeField] float velocidadMovimiento; // velocidad a la que se mueve el enemigo

    Rigidbody2D rb;  //referencia del rigidbody del enemigo

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }
    
    private void Flip()
    {
        if (estaMirandoDerecha  || !estaMirandoDerecha )
        {// codigo que voltea el sprite del  personaje escalando en negativo

            
            estaMirandoDerecha = !estaMirandoDerecha;
            Vector2 escalaLocal = transform.localScale;
            escalaLocal.x *= -1f;
            transform.localScale = escalaLocal;

            velocidadMovimiento = velocidadMovimiento * -1f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= pointA.position.x  ) 
        {
            Flip();
        }
        if (transform.position.x <= pointB.position.x)
        {
            Flip();
        }
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(velocidadMovimiento, 0f) );
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.position, 0.5f);
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
