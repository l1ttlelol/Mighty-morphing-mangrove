using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable_block : MonoBehaviour
{
    //public BoxCollider2D Collider;
    public GameObject Self;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Attack")
        {
            //print("test");
            Self.SetActive(false);
        }
    }
}
