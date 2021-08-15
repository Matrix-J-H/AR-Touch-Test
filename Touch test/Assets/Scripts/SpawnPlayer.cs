using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;

    public void Start() 
    {   
        Instantiate(playerPrefab, transform.position + Vector3.up, Quaternion.identity);
    }
}
