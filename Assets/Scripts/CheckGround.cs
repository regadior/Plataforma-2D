using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{   //Se crea una caja de colisiones que chequea si esta esta tocando el suelo
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) //Si estamos tocando el Ground=tilemap sea true
        {
            isGrounded = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) //Si estamos tocando el Ground=tilemap sea true
        {
            isGrounded = false;
        }
    }


}
