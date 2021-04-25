using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawm : MonoBehaviour
{       
    
    public GameObject[] hearts; //Hacer referncia a los corazon
    private int life; //Referencias de nuestra vida
    
    //Se crea una variable float que se de en forma de nº decimal porque no se puede leer vectores
    private float checkPointPositionX, changePositionY;
        //Se crea un nuevo nombre para referirse
    public Animator animator;


    void Start()
    {       
        life=hearts.Length;  //la longitud de vidas que haya va a ser las totales



       if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
       {
           transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),PlayerPrefs.GetFloat("checkPointPositionY")));
       } 
    }

    private void CheckLife()   //Se comprueba el nivel de vida 
    {
        if (life < 1)   //Si es menor que uno se destruye el 3 corazon
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit"); //Si el player sufre un Daño este inicia una animacion
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // al ser el ultimo el personaje respawnea
        }
        else if (life < 2)  //Si es menor que uno se destruye el 2 corazon
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit"); //Si el player sufre un Daño este inicia una animacion
        }
        else if (life < 3)  //Si es menor que uno se destruye el 1 corazon
        {
            Destroy(hearts[2].gameObject); 
            animator.Play("Hit"); //Si el player sufre un Daño este inicia una animacion

        }

    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY",y);
    }


        
    public void PlayerDamage()
    {
        life--; //Cada vez que se daña se resta vida
        CheckLife();
    }

}
