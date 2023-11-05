using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class attackGhost : MonoBehaviour
{
    public Animator ghostAnimator;
    public UnityEvent isAttacking;

    //Funciónm para llamar al ataque del fantasma, activando la variable attack y llamando a la función isAttacking 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("ataca!!");
            ghostAnimator.SetBool("attack", true);
            isAttacking.Invoke();

        }
    }
    

}
