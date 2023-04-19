using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBottomCollider : MonoBehaviour
{
    public bool IsInside;

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        IsInside = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        IsInside = false;
    }
}
