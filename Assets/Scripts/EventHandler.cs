using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //Variables
    public bool IsCharacterSelecting;

    //References
    public PlayerMovement Move;

    void Update()
    {

        //CHARACTER SELECTION MENU
        if (Input.GetButton("Character Select") && Input.GetButton("Character Select Up"))
        {
            //UP
            print("Character Select Up");
            IsCharacterSelecting = true;
        }
        else if (Input.GetButton("Character Select") && Input.GetButton("Character Select Right"))
        {
            //RIGHT
            print("Character Select Right");
            IsCharacterSelecting = true;
        }
        else if (Input.GetButton("Character Select") && Input.GetButton("Character Select Down"))
        {
            //DOWN
            print("Character Select Down");
            IsCharacterSelecting = true;
        }
        else if (Input.GetButton("Character Select") && Input.GetButton("Character Select Left"))
        {
            //LEFT
            print("Character Select Left");
            IsCharacterSelecting = true;
        }
        else if(Input.GetButton("Character Select"))
        {
            //NONE
            print("Character Select Menu");
            IsCharacterSelecting = true;
        }
        else
        {
            //DESELECTING
            IsCharacterSelecting = false;
        }

        //NONE CHARACTER SELECTION MENU
        if (IsCharacterSelecting == false)
        {
            //MOVE LEFT
            if (Input.GetAxis("Horizontal") < 0)
            {
                print("left");
                Move.Player_MoveLeft();
            }

            //MOVE RIGHT
            if (Input.GetAxis("Horizontal") > 0)
            {
                print("right");
                Move.Player_MoveRight();
            }

            //JUMP
            if (Input.GetButton("Jump") && Move.JumpAmount > 0)
            {
                print("jump");
                Move.Player_Jump();
            }

            //USE ATTACK
            if (Input.GetButton("Attack"))
            {
                print("attack");
            }

            //USE CHARACTER ABILITY
            if (Input.GetButton("Ability"))
            {
                print("ability");
            }
        }
    }
}
