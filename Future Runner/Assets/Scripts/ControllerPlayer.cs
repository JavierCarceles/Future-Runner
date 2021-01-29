using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{

    private CharacterController controladorPersonaje;
    private Vector3 direccionPersonaje;
    public float velocidadPersonaje = 4;

    private int carrilActual = 1;
    public float distanciaEntreCarriles=2;

    void Start()
    {
        controladorPersonaje = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        direccionPersonaje.z = velocidadPersonaje;

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            carrilActual++;
            if (carrilActual == 3)
            {
                carrilActual = 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
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

        transform.position = posicionObjetivo;

    }

    private void FixedUpdate()
    {
        controladorPersonaje.Move(direccionPersonaje * Time.fixedDeltaTime);
    }

}
