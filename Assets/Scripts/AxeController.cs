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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementAxe();
    }
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
}
