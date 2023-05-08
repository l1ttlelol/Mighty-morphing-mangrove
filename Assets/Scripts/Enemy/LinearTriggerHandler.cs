using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTriggerHandler : MonoBehaviour
{
    //references
    public BoxCollider2D TriggerBox;

    //variables
    public bool IsTriggered;
    public float TriggerTimer;
    public float TriggerTimerMax;
    bool IsTriggering;

    void Update()
    {
        if (IsTriggering != true)
        {
            TriggerTimer -= Time.deltaTime;
        }
        if (TriggerTimer <= 0) { IsTriggered = false; }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsTriggered = true;
            IsTriggering = true;
            TriggerTimer = TriggerTimerMax;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsTriggering = false;
        }
    }
}
