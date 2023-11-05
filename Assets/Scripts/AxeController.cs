using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public float speedAxe;
    public Transform transformAxe;
    public float liveAxe;

    private Vector2 axeDirection;
    private float timeAlive = 0f;



    // Update is called once per frame
    void FixedUpdate()
    {
        movementAxe();
    }
    
    //Funciones para que la fecha tenga un tiempo y se gire según la dirección del personaje
    private void movementAxe()
    {
        transformAxe.Translate(axeDirection * speedAxe * Time.fixedDeltaTime);
        if (axeDirection == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {

            GetComponent<SpriteRenderer>().flipX = true;
        }

        timeAlive += Time.fixedDeltaTime;

        if(timeAlive >= liveAxe)
        {
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector2 dir)
    {
        axeDirection = dir;
    }

    //Funcion para que se muera si el fantasma toca la hacha.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<Animator>().SetTrigger("death");
        }
    }
}
