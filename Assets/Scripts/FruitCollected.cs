using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{   //si se colisiona con una caja de colision de una fruta estonces 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;         //Esta desaparece
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //Esto provoca que se active la animacion de cojer fruta
            Destroy(gameObject, 0.5f);                              //Esto provoca que se destruya la animacion al pasar 0.5 segundos
        }
    }

}
