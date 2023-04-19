using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //Variables
    public bool IsCharacterSelecting;
    public Sprite CharacterIdleSprite;
    public float JumpTimer;
    public float AttackActiveTimer;
    public float AttackCooldownTimer;
    public int CharacterIndex = 1;
    public CharacterData[] CharacterData;

    //References
    public PlayerMovement Move;
    public SpriteRenderer CharacterSprite;
    public PlayerAbilityDash Dash;
    public PlayerAbilityGrab Grab;
    public PlayerAbilityHeavyAttack HeavyAttack;
    public GameObject PlayerAttack;

    void FixedUpdate()
    {
        //sets the data for the active character
        GetData();

        CharacterSprite.sprite = CharacterIdleSprite; //PLACEHOLDER

        //Counting down the Jump timer
        JumpTimer -= Time.deltaTime;
        if(JumpTimer < 0)
        {
            JumpTimer = 0;
        }

        //Counting down how long an attack has been out for
        AttackActiveTimer -= Time.deltaTime;
        if (AttackActiveTimer < 0)
        {
            AttackActiveTimer = 0;
            PlayerAttack.SetActive(false);
        }

        //Counting down until the next attack
        AttackCooldownTimer -= Time.deltaTime;
        if (AttackCooldownTimer < 0)
        {
            AttackCooldownTimer = 0;
        }

        //CHARACTER SELECTION MENU
        if (Input.GetButton("Character Select") && Input.GetButton("Character Select Up"))
        {
            //UP
            //print("Character Select Up");
            IsCharacterSelecting = true;
            CharacterIndex = 0;
        }
        else if (Input.GetButton("Character Select") && Input.GetButton("Character Select Right"))
        {
            //RIGHT
            //print("Character Select Right");
            IsCharacterSelecting = true;
            CharacterIndex = 1;
        }
        else if (Input.GetButton("Character Select") && Input.GetButton("Character Select Down"))
        {
            //DOWN
            //print("Character Select Down");
            IsCharacterSelecting = true;
            CharacterIndex = 2;
        }
        else if (Input.GetButton("Character Select") && Input.GetButton("Character Select Left"))
        {
            //LEFT
            //print("Character Select Left");
            IsCharacterSelecting = true;
            CharacterIndex = 3;
        }
        else if(Input.GetButton("Character Select"))
        {
            //NONE
            //print("Character Select Menu");
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
                //print("left");
                Move.Player_MoveLeft();
            }

            //MOVE RIGHT
            if (Input.GetAxis("Horizontal") > 0)
            {
                //print("right");
                Move.Player_MoveRight();
            }

            //JUMP
            if (Input.GetButton("Jump") && Move.JumpAmount > 0 && JumpTimer == 0)
            {
                Move.Player_Jump();
                JumpTimer = 0.4f;
            }

            //USE ATTACK
            if (Input.GetButton("Attack") && AttackCooldownTimer == 0)
            {
                PlayerAttack.SetActive(true);
                AttackActiveTimer = 0.4f;
                AttackCooldownTimer = 0.8f;
            }

            //USE CHARACTER ABILITY
            if (Input.GetButton("Ability"))
            {
                //print("ability");
                if (CharacterIndex == 1)
                {
                    Dash.PlayerAbility_Dash();
                }else if (CharacterIndex == 2)
                {
                    HeavyAttack.PlayerAbility_HeavyAttack();
                }else if (CharacterIndex == 3)
                {
                    Grab.PlayerAbility_Grab();
                }
                else
                {
                    //print("No ability");
                }
            }
        }
    }
    
    //Gets the references to the character data
    void GetData()
    {
        CharacterIdleSprite = CharacterData[CharacterIndex].IdleSprite;
        Move.MaxJumpAmount = CharacterData[CharacterIndex].MaxJumps;
        if(Move.IsGrounded == true)
        {
            Move.JumpAmount = Move.MaxJumpAmount;
        }
    }
}
