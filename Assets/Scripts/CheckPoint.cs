using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
        //Esto hace que si se colisiona con la caja de los checkpoints estes guarden la posicion en forma de float y activen la animacion de el checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawm>().ReachedCheckPoint(transform.position.x,transform.position.y);
            GetComponent<Animator>().enabled = true;
        }

    }




}
