using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speedGhost;

    private bool ghostAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followingPlayer();
    }
    public void attack()
    {
        ghostAttacking = true;
    }

    private void followingPlayer()
    {
        if (ghostAttacking)
        {
            rb.velocity = new Vector2((-1f)*speedGhost, 0);
        }

    }

    public void direction()
    {
        if (player.transform.position.x>0f)
        {

            //transform.position = ;
        }
    }

}
