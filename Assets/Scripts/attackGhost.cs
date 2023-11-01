using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class attackGhost : MonoBehaviour
{
    public Animator ghostAnimator;
    public UnityEvent isAttacking;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("ataca!!");
            ghostAnimator.SetBool("attack", true);
            isAttacking.Invoke();
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
