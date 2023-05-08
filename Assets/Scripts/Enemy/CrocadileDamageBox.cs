using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocadileDamageBox : MonoBehaviour
{
    public Crocadile Crocadile;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Crocadile.Health = 0;
        }
    }
}
