using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemyWallHandler : MonoBehaviour
{
    public CrabEnemy CrabEnemy;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
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
}
