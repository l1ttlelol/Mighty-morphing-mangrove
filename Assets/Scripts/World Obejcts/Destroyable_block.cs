using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable_block : MonoBehaviour
{
    public GameObject Self;
    public AudioHandler AudioHandler;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Attack")
        {
            AudioHandler.HitAudio();
            Self.SetActive(false);
        }
    }
}
