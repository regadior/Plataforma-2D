using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawm : MonoBehaviour
{       //Se crea una variable float que se de en forma de nº decimal porque no se puede leer vectores
    private float checkPointPositionX, changePositionY;
        //Se crea un nuevo nombre para referirse
    public Animator animator;


    void Start()
    {       
       if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
       {
           transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),PlayerPrefs.GetFloat("checkPointPositionY")));
       } 
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY",y);
    }
        //Si el player sufre un Daño este inicia una animacion
    public void PlayerDamage()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }

}
