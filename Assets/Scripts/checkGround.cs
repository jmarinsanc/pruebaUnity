using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta es la clase para ver si está tocando el suelo y que solo salte si lo está tocando
public class checkGround : MonoBehaviour
{
    public static bool isGrounded;

    // Funciones para cuando el boxCollider del personaje toque el suelo y para cuando no.
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.GetComponent<CompositeCollider2D>())
        {
            isGrounded = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CompositeCollider2D>())
        {
            isGrounded = false;
        }
        //isGrounded = false;
    }

}
