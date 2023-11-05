using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speedGhost;
    private float ghostDirection;

    private bool ghostAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame, se llama por cada frame a followingPlayer.
    void FixedUpdate()
    {
        followingPlayer();
    }
    public void attack()
    {
        ghostAttacking = true;
    }
    //Esta es la función para que mi fantasma siga a mi personaje, he intentado hacerlo de varias formas
    // Como esatá comentado más abajo, lo intenté también usando la variable horizontal, por eso está como static 
    // en la clase playerController, puse que fuera playerController.horizontal*(-1) pero tampoco ha funcionado.
    private void followingPlayer()
    {
        if (ghostAttacking)
        {
            //if(transform.position.x < player.transform.position.x)
            //{
                //ghosDirection = 1f;
            //}
            //else
            //{
                //ghost
                //ghostirection = -1f;
            //}
            rb.velocity = new Vector2((-1f)*speedGhost, 0);
        }

    }
    //Función para que al morir desaparezca mi fastasma, el objeto se destruye
    public void death()
    {
        Destroy(gameObject);
    }
}
