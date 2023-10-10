using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool estaMirandoDerecha;//isFacingRight

    private float movimientoHorizontal;
    private float movimientoVertical;
    
    [SerializeField] int movementSpeed;
    [SerializeField] int fuerzaSalto;

    [SerializeField] private Transform groundCheck;
    [SerializeField] LayerMask layerSuelo;


    void Awake()// Aqui si podemos inicializar (:
    {
        rb = GetComponent<Rigidbody2D>();
        estaMirandoDerecha = true;
    }

    // Start is called before the first frame update
    void Start()// es mejor que aqui NO
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        movimientoVertical = Input.GetAxisRaw("Vertical");
        Flip();
        //estaEnElSuelo();
        if (movimientoVertical > 0f && estaEnElSuelo())
            rb.AddForce(new Vector2( 0,fuerzaSalto ));
      
    }

    private void FixedUpdate() // Se llama si o si 100 veces por segundo se llama tambien a las funciones de la fisica
    {
        rb.AddForce(new Vector2(movimientoHorizontal, 0) * movementSpeed);
    }

    private void Flip()
    {
        if (estaMirandoDerecha && movimientoHorizontal < 0f || !estaMirandoDerecha && movimientoHorizontal > 0f)
        {// codigo que voltea el sprite del  personaje escalando en negativo

            estaMirandoDerecha = !estaMirandoDerecha;
            Vector2 escalaLocal = transform.localScale;
            escalaLocal.x *= -1f;
            transform.localScale = escalaLocal;
        }
    }

    private bool estaEnElSuelo()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, layerSuelo);
    }
}
   
