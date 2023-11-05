using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscena : MonoBehaviour
{
    //En esta clase no hay necesidad de FixedUpadate, este es un método para el cambio de escena, entre la segunda y la tercera
    //si esta en la primera va a la segunda y si estás en la segunda vas a la tercera
    // Lo he hecho por niveles, los niveles se meten y se ordenan en build settings, hay te pone el número que es cada uno.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name.Equals("SegundaEscena"))
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }
}
