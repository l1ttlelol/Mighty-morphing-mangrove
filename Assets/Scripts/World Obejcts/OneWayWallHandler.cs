using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayWallHandler : MonoBehaviour
{
    public GameObject PhysicalWall;
    public OneWayBottomCollider Inside;

    bool IsActive = false;

    void Update()
    {
        //DEACTIVATING PHYSICALS IF SOMETHING IS NOT IN THE NEGATIVE DETECTOR
        if (IsActive == false)
        {
            PhysicalWall.SetActive(false);
        }
        else        //ACTIVATING PHYSICALS IF SOMETHING IS IN THE NEGATIVE DETECTOR
        {   
            PhysicalWall.SetActive(true);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag == "Player" && Inside.IsInside == false)
        {
            IsActive = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IsActive = false;
        }
    }
}
