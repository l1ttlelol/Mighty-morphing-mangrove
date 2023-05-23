using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSwitch1 : MonoBehaviour
{
    public AudioHandler AudioHandler;
    public float ImmunityTimer;
    public SpriteRenderer SwitchSprite;
    public Sprite SwitchOn;
    public Sprite SwitchOff;
    public bool HasWaterRisen = false;
    public bool IsSwitchOn = false;

    public WaterHegiht WaterHeight;
    public int HeightID;

    // Update is called once per frame
    void Update()
    {
        if (IsSwitchOn == true)
        {
            SwitchSprite.sprite = SwitchOn;
        }
        else
        {
            SwitchSprite.sprite = SwitchOff;
        }

        ImmunityTimer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player Attack" || collision.gameObject.tag == "Player HeavyAttack" || collision.gameObject.tag == "Whip") && ImmunityTimer <= 0)
        {
            //AudioHandler.HitAudio();
            ImmunityTimer = 0.4f;
            if (HasWaterRisen == false)
            {
                WaterHeight.CurrentHeight = HeightID;
                HasWaterRisen = true;
                AudioHandler.HitAudio();
                AudioHandler.ChaseAudio();
            }

            if (IsSwitchOn == false) { IsSwitchOn = true; }

            else { IsSwitchOn = false; }
        }
    }
}
