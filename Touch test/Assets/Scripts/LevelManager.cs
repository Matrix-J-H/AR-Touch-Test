using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Trap":
                StartFailSequence();
                break;
        }
    }

    void StartFailSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
}

