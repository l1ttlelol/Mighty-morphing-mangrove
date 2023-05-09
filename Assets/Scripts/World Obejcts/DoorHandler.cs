using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public BoxCollider2D SwitchCollider;
    public GameObject Door;
    public bool DoorStartState;
    public bool DoorCurrentState;

    //SETTING THE INITIAL STATE OF THE DOOR
    void Start()
    {
        DoorCurrentState = DoorStartState;
    }

    //UPDATING THE DOORS CURRENT STATE
    void Update()
    {
        Door.SetActive(DoorCurrentState);
    }

    //ACTIVATING THE SWITCH AND ALTERNATING THE DOORS STATE
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Attack")
        {
            if (DoorCurrentState == true) { DoorCurrentState = false; }
            else { DoorCurrentState = true; }
        }
    }
}
