using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform jugador;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - jugador.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posicionNueva = new Vector3(transform.position.x, transform.position.y, offset.z + jugador.position.z);
        transform.position = Vector3.Lerp(transform.position, posicionNueva, 10*Time.deltaTime);
    }
}
