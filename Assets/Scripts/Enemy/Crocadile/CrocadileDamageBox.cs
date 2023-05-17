using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocadileDamageBox : MonoBehaviour
{
    public Crocadile Crocadile;
    public AudioHandler AudioHandler;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            AudioHandler.HitAudio();
            Crocadile.Health = 0;
        }
    }
}
