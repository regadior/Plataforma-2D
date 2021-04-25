using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour

{   

    
    
    //Si se toca la caja de colision de el objeto con el Player, provoca que se cambie a una nueva escena
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2",LoadSceneMode.Single);
        }
    }
}
