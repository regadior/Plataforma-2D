using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Se le da valor a una variable 
    public float runSpeed = 2;

    //Se le da valor a una variable
    public float jumpSpeed = 3;

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
            //Si se pulsa el espacio se chequea si la caja de colisiones esta tocando el suelo, si es asi salta, si no es asi no se acciona
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
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
