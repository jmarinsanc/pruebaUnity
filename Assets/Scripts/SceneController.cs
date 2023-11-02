using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCointroller : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadscene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
