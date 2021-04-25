using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{       //Si se colisiona con la caja de colision de un Enemigo:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");        //Esto carga el damege player
            collision.transform.GetComponent<PlayerRespawm>().PlayerDamage();   //Esto hace que el player respwne donde esta su checkpoint
        }


    }

}
