using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Se le da valor a una variable 
    public float runSpeed = 2;

    //Se le da valor a una variable
    public float jumpSpeed = 3;
    //Se le da valor a una variable
    public float doubleJumpSpeed = 2.5f;
    //Variable para ver si podemos hacer un segundo salto
    private bool canDoubleJump;

    //Se crea un nuevo nombre para referirse a Rigidbody2D
    Rigidbody2D rb2D;

    //
    public bool betterJump = false;

    //Se le da valor a una variable
    public float fallMultiplier = 0.5f;

    //Se le da valor a una variable
    public float lowJumpMultiplier = 1f; 

    //Se crea un nuevo nombre para referirse
    public SpriteRenderer spriteRenderer;

    //Se crea un nuevo nombre para referirse
    public Animator animator;
    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
            //Si se pulsa el espacio se chequea si la caja de colisiones esta tocando el suelo, si es asi salta, si no es asi no se acciona
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;   //si es true entonces 
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                animator.SetBool("Run", false);
            }
            else
            {
                if (Input.GetKeyDown("space")) //Hace que cuando saltemos y volvamos a pulsar espacio se ejequte el doble salto
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump",true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed); // Igual que es salto normal pero con la velocidad de ptra var
                        canDoubleJump = false; //una vez echo se desactiva el doble salto

                    }
                }
            }
        }

        if (CheckGround.isGrounded==false)
        {
             animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            
         }
        if (CheckGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
         }
           
           if (rb2D.velocity.y<0)
           {
               animator.SetBool("Falling",true);
           }
           else if (rb2D.velocity.y>0)
           {
               animator.SetBool("Falling",false);
           }
        


     

    }


    void FixedUpdate()
    {      //Si se pulsa la d se mueve en sentido positivo del eje x
        if (Input.GetKey("d"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }   //Si se pulsa la d se mueve en sentido negativo del eje x
        else if (Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }   //Si no se pulsa nada no se mueve en ninguna dirección
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
        
        //Se crea una opción para poder modificar los valores de el salto y poder hacer medio y salto completo
        if (betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity +=Vector2.up*Physics2D.gravity.y*(fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity +=Vector2.up*Physics2D.gravity.y*(lowJumpMultiplier) * Time.deltaTime;
            }
        } 



    }

}
