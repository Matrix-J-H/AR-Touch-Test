using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thePlayer;

    private void Start() 
    {   
        firstSpawn();
    }

    public void firstSpawn()
    {
        Transform playerTransform = thePlayer.GetComponent<Transform>();
        playerTransform.position = transform.position + Vector3.up * 0.02f;
    }
}
