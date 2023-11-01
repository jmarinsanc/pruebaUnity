using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public static bool isGrounded;

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
