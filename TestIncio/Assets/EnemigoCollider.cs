using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCollider : MonoBehaviour
{
    float velocidadMovimiento;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (estaMirandoDerecha())
        {
            rb.velocity = new Vector2(velocidadMovimiento, 0f);
        }
        else 
        {
            rb.velocity = new Vector2(-velocidadMovimiento, 0f);
        }
    }
    bool estaMirandoDerecha()
    {

        return transform.localScale.x > 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        transform.localScale = new Vector2((transform.localScale.x)*-1f, transform.localScale.y);
    }
}
