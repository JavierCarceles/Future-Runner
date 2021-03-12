using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{

    //GameObject jugador = new GameObject();
    Vector3 iniciar = new Vector3(0, 0, 0);
    private CharacterController controladorPersonaje;
    private Vector3 direccionPersonaje;
    public float velocidadPersonaje = 4;

    private int carrilActual = 1;
    public float distanciaEntreCarriles = 2.5f;

    public float FuerzaSalto;
    public float gravedad = -100;

    void Start()
    {
        //Instantiate(jugador, iniciar, Quaternion.identity);
        controladorPersonaje = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        
        direccionPersonaje.z = velocidadPersonaje;

        
        if (controladorPersonaje.isGrounded)
        {
            direccionPersonaje.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direccionPersonaje.y += gravedad * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            carrilActual++;
            if (carrilActual == 3)
            {
                carrilActual = 2;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            carrilActual--;

            if (carrilActual == -1)
            {
                carrilActual = 0;
            }

        }

        Vector3 posicionObjetivo = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (carrilActual == 0)
        {
            posicionObjetivo += Vector3.left * distanciaEntreCarriles;
        }

        else if (carrilActual == 2)
        {
            posicionObjetivo += Vector3.right * distanciaEntreCarriles;
        }

        if (transform.position == posicionObjetivo)
            return;
        Vector3 diff = posicionObjetivo - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controladorPersonaje.Move(moveDir);
        }
        else 
        {
            controladorPersonaje.Move(diff);
        }
       
        controladorPersonaje.center = controladorPersonaje.center;
        
    }

    private void FixedUpdate()
    {
        controladorPersonaje.Move(direccionPersonaje * Time.deltaTime);
    }

    private void Jump()
    {
        direccionPersonaje.y = FuerzaSalto;
    }

}
