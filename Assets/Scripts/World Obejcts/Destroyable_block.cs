using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable_block : MonoBehaviour
{
    public GameObject Self;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Attack")
        {
            Self.SetActive(false);
        }
    }
}
