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
            grandChild = this.gameObject.transform.GetChild(0).GetChild(0).gameObject; //get the child of the child gameObject of the attached object
            
            RandomDrop();
            hasCalled = true;
        }
        
    }

    private void RandomDrop()
    {
        foreach(Transform planeTransform in grandChild.transform) //iterate through each plane in the grand child
        {
            int randomNum = random.Next(0,3); //generate random integer
            
            if(randomNum == 2) //2 over 3 chance of having a Pickup Rewards on the plane
            {   
                Instantiate(Rewards, planeTransform.position + Vector3.up * 0.02f, Rewards.transform.rotation);
            }
        }
    }

}
