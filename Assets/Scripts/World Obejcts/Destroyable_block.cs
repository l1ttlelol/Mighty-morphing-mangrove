using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable_block : MonoBehaviour
{
    //public BoxCollider2D Collider;
    public GameObject PlayerAttack;
    public GameObject Self;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerAttack)
        {
            //print("test");
            Self.SetActive(false);
        }
    }
}
