using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRewards : MonoBehaviour
{   
    private int planeCount;
    public GameObject Rewards;
    private GameObject grandChild;
    private System.Random random = new System.Random();
    private bool hasCalled = false;

    // Start is called before the first frame update
    void Update()
    {   
        if(!hasCalled)
        {
            grandChild = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
            //planeCount = transform.childCount;
            RandomDrop();
            hasCalled = true;
        }
        
    }

    private void RandomDrop()
    {
        foreach(Transform planeTransform in grandChild.transform)
        {
            int randomNum = random.Next(0,3);
            
            if(randomNum == 2)
            {
                Instantiate(Rewards, planeTransform.position + Vector3.up * 0.02f, Rewards.transform.rotation);
            }
        }
    }

}
