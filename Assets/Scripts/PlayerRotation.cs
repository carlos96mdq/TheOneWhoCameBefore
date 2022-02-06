using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;     // Velocidad de rotación
    public Transform player;                // Transform del player alque la camara sigue
    float x_rotation = 0f;                  // Rotacion inicial (la rotación respecto al eje x es hecha de esta manera)
                                            // para poder en un futuro limitarla
    System.Random randomNumber;            // La variableque alamacenará los valores pseudo-aleatorios
                                            // Se debe destacar que se utilizarán las librerías del sistema de C# 
                                            // (System) y no las integradas dentro de Unity (UnityEngine)
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                           // Esconder el mouse
        randomNumber = new System.Random((int)DateTime.Now.Ticks);         // Inicializo una nueva instancia de Random
                                                                            // con un seed dependiente de la fecha y hora actual
        player.transform.localRotation = Quaternion.Euler(0f, randomNumber.Next(360), 0f); // Devuelve un angulo random        
        //UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }

    void Update()
    {
        Rotation(); // Rotación de la camara
    }

    void Rotation() {
        // Tomo el valor demovimiento tanto en el eje x como en el eje y del mouse
        float vertical_mouse = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float horizontal_mouse = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Almaceno el valor de y en una variable aparte para poderlo clampear entre -70° y +70°
        // Tener en cuenta que tengo que pasarlo a una segunda variable para incrementar o disminuir ese valor, 
        // y no igualarlo
        x_rotation -= vertical_mouse;
        x_rotation = Mathf.Clamp(x_rotation, -70f, 70f);
        
        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f); // Rotación en vetical
        player.Rotate(new Vector3(0f, horizontal_mouse, 0f));           // Rotación en horizontal
    }
}
