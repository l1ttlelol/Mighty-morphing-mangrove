using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRiseCheckpoint : MonoBehaviour
{
    public Transform self;
    public PlayerManager PlayerManager;
    public WaterHegiht WaterHeight;
    public int HeightID;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.LastSoftCheckpoint = self.position;
            WaterHeight.CurrentHeight = HeightID;
        }
    }
}
