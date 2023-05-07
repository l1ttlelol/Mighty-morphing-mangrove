using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemyFloorHandler : MonoBehaviour
{
    public CrabEnemy CrabEnemy;
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (CrabEnemy.IsDirectionRight == true)
        {
            CrabEnemy.IsDirectionRight = false;
        }
        else
        {
            CrabEnemy.IsDirectionRight = true;
        }
    }
}
