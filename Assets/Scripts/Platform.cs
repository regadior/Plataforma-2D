using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector; //Nombre para hacer referencia al effector


    public float startWaiTime;
    private float waitedTime;
     
  

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>(); //Se detecta el effecto dentro de nuestro objeto
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))         //se resetea el tiempo 
        {
            waitedTime = startWaiTime;
        }



        if (Input.GetKey("s"))
        {
            if (waitedTime<=0)  //Si waitedTime es menor o igual a 0cambiamos lo siguiente
            {
                effector.rotationalOffset = 180f;
                waitedTime = startWaiTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        if(Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;  //se resetea la rotacion a 0

        }




    }
}
