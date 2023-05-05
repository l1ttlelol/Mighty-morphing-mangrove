using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftCheckpoint : MonoBehaviour
{
    public Transform self;
    public PlayerManager PlayerManager;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.LastSoftCheckpoint = self.position;
        }
    }
}
