using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour

    
{
    [SerializeField] private GameObject saltoPlayer;


    public Rigidbody2D rb;
    public float speedMove;
    public float speedUp;
    public float jumpingPower;
    public SpriteRenderer sprtRnd;
    public Animator animPlayer;
    public Transform transformPlayer;
    public GameObject axePrefab;
    public float waitShootTime;
    public GameObject axeOut;
    public AudioSource soundEfectJump;
    public UnityEvent loadNewScene;

    private float horizontal;
    private bool isFacingRight = true;
    private Vector2 directionAxe;
    private float lastShoot;

    private float xinicial, Yinicial;

    // Start is called before the first frame update
    void Start()
    {
        xinicial = transform.position.x;
        Yinicial = transform.position.y;
        AudioSource audioSource = saltoPlayer.GetComponent<AudioSource>();
        //AudioSource audioSource = audioSource1;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkMovement(); 
    }

    public void Move(InputAction.CallbackContext context)
    {
      
        horizontal = context.ReadValue<Vector2>().x;
        Debug.Log(horizontal);

    }

    public void recolocar()
    {
        transform.position = new Vector2(xinicial, Yinicial);
    }

    private void checkMovement()
    {
        if (checkGround.isGrounded)
        {
            animPlayer.SetBool("isGrounded", true);
        }
        else
        {
            animPlayer.SetBool("isGrounded", false);
        }

        if (Mathf.Abs(horizontal) != 0f)
        {
            animPlayer.SetBool("isRunning", true);
        }
        else
        {
            animPlayer.SetBool("isRunning", false);
        }
        rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            //girar derecha
            isFacingRight = true;
            sprtRnd.flipX = false;
        }
        else if (isFacingRight && horizontal < 0f)
        {
            //hacia la izquierda
            isFacingRight = false;
            sprtRnd.flipX = true;
        }

    }

    public void Jump()
    {

        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            soundEfectJump.Play();
        }
        
    }

    public void shootAnimation()
    {
        if (Time.time > lastShoot + waitShootTime)
        {
            animPlayer.SetTrigger("shoot");
            lastShoot = Time.time;
        }
        
    }
    public void Shoot()
    {

        //Debug.Log("disparo");
        GameObject axe = Instantiate(axePrefab, axeOut.transform.position, Quaternion.identity);

        if (sprtRnd.flipX)
        {
            directionAxe = Vector2.left;
        }
        else
        {
            directionAxe = Vector2.right;
        }
        axe.GetComponent<AxeController>().setDirection(directionAxe);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Respawn") || other.gameObject.CompareTag("colisionInferior") ||other.gameObject.CompareTag("pinchos"))
        {
            animPlayer.SetTrigger("death");
        }
    }

    public void ldScene()
    {
        loadNewScene.Invoke();
    }

    public void cambiardeEscena()
    {
        SceneManager.LoadScene(1);
    }

    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
