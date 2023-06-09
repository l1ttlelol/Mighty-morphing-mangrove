using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //Variables
    public bool IsCharacterSelecting;
    public Sprite CharacterIdleSprite;
    public Sprite CharacterJumpSprite;
    public Sprite CharacterRun1Sprite;
    public Sprite CharacterRun2Sprite;
    public Sprite SpearSprite;
    public Sprite SwordSprite;
    public float JumpTimer;
    public float AttackActiveTimer;
    public float AttackCooldownTimer;
    public float AbilityTimer;
    public float RunAnimationTimer;
    public bool IsRunAnimation1;
    public int CharacterIndex = 1;
    public CharacterData[] CharacterData;
    public bool IsMoving;

    //References
    public PlayerMovement Move;
    public SpriteRenderer CharacterSprite;
    public SpriteRenderer WeaponSprite;
    public PlayerAbilityDash Dash;
    public PlayerAbilityGrab Grab;
    public PlayerAbilityHeavyAttack HeavyAttack;
    public GameObject PlayerAttack;
    public GameObject PlayerHeavyAttack;
    public GameObject PlayerGrabAttack;
    public Transform AttackCounterWeight;
    public AudioHandler AudioHandler;
    public PlayerManager PlayerManager;
    public PlayerMovement PlayerMovement;


    public SpriteRenderer CharacterSelectSprite;
    public GameObject CharacterSelect;
    public Sprite CharacterSelectSprite1;
    public Sprite CharacterSelectSprite2;
    public Sprite CharacterSelectSprite3;
    public Sprite CharacterSelectSprite4;


    void FixedUpdate()
    {
        //sets the data for the active character
        GetData();

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
            PlayerHeavyAttack.SetActive(false);
            PlayerGrabAttack.SetActive(false);

            if(CharacterIndex != 3)
            {
                AttackCounterWeight.eulerAngles = new Vector3(0, 0, 32.902f);
            }
            else
            {
                AttackCounterWeight.eulerAngles = new Vector3(0, 0, 0);
            }
            
        }
        else if(CharacterIndex != 3)
        {
            if(PlayerMovement.PlayerDirection == -1)
            {
                AttackCounterWeight.eulerAngles = new Vector3(0, 180, AttackCounterWeight.eulerAngles.z - 7f);
            }
            else
            {
                AttackCounterWeight.eulerAngles = new Vector3(0, 0, AttackCounterWeight.eulerAngles.z - 7f);
            }
        }
        else
        {
            if (CharacterIndex == 3)
            {
                if (PlayerMovement.PlayerDirection == -1)
                {
                    AttackCounterWeight.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    AttackCounterWeight.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else
            {
                if (PlayerMovement.PlayerDirection == -1)
                {
                    AttackCounterWeight.eulerAngles = new Vector3(0, 180, AttackCounterWeight.eulerAngles.z - 7f);
                }
                else
                {
                    AttackCounterWeight.eulerAngles = new Vector3(0, 0, AttackCounterWeight.eulerAngles.z - 7f);
                }
            }
        }

        //Counting down until the next attack
        AttackCooldownTimer -= Time.deltaTime;
        if (AttackCooldownTimer < 0)
        {
            AttackCooldownTimer = 0;
        }

        AbilityTimer -= Time.deltaTime;
        if (AbilityTimer < 0)
        {
            AbilityTimer = 0;
        }

        //===========================================================
        if (PlayerManager.CurrentHealth != 0)
        {


            //CHARACTER SELECTION MENU
            if ((Input.GetButton("Character Select") || Input.GetButton("Character Select 2")) && Input.GetButton("Character Select Up"))
            {
                //UP
                //print("Character Select Up");
                IsCharacterSelecting = true;
                CharacterIndex = 2;
                CharacterSelect.SetActive(true);
                CharacterSelectSprite.sprite = CharacterSelectSprite3;
            }
            else if ((Input.GetButton("Character Select") || Input.GetButton("Character Select 2")) && Input.GetButton("Character Select Right"))
            {
                //RIGHT
                //print("Character Select Right");
                IsCharacterSelecting = true;
                CharacterIndex = 0;
                CharacterSelect.SetActive(true);
                CharacterSelectSprite.sprite = CharacterSelectSprite1;
            }
            else if ((Input.GetButton("Character Select") || Input.GetButton("Character Select 2")) && Input.GetButton("Character Select Down"))
            {
                //DOWN
                //print("Character Select Down");
                IsCharacterSelecting = true;
                CharacterIndex = 1;
                CharacterSelect.SetActive(true);
                CharacterSelectSprite.sprite = CharacterSelectSprite2;
            }
            else if ((Input.GetButton("Character Select") || Input.GetButton("Character Select 2")) && Input.GetButton("Character Select Left"))
            {
                //LEFT
                //print("Character Select Left");
                IsCharacterSelecting = true;
                CharacterIndex = 3;
                CharacterSelect.SetActive(true);
                CharacterSelectSprite.sprite = CharacterSelectSprite4;
            }
            else if (Input.GetButton("Character Select") || Input.GetButton("Character Select 2"))
            {
                //NONE
                //print("Character Select Menu");
                IsCharacterSelecting = true;
                CharacterSelect.SetActive(true);
            }
            else
            {
                //DESELECTING
                IsCharacterSelecting = false;
                CharacterSelect.SetActive(false);
            }

            //============================================================

            //NONE CHARACTER SELECTION MENU
            if (IsCharacterSelecting == false)
            {
                //MOVE LEFT
                if (Input.GetAxis("Horizontal") < 0 || Input.GetButton("Left")) 
                {
                    //print("left");
                    Move.Player_MoveLeft();
                }

                //MOVE RIGHT
                if (Input.GetAxis("Horizontal") > 0 || Input.GetButton("Right"))
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
                if ((Input.GetButton("Attack") || Input.GetButton("Attack 2")) && AttackCooldownTimer == 0)
                {
                    AudioHandler.AttackAudio();
                    if (CharacterIndex != 2 && CharacterIndex != 3)
                    {
                        PlayerAttack.SetActive(true);

                        if (CharacterIndex == 1)
                        {
                            Dash.PlayerAbility_Dash();
                            AudioHandler.DashAudio();
                            WeaponSprite.sprite = SpearSprite;
                        }
                        else
                        {
                            WeaponSprite.sprite = SwordSprite;
                        }
                    }
                    else if (CharacterIndex == 2)
                    {
                        PlayerHeavyAttack.SetActive(true);
                    }
                    else
                    {
                        PlayerGrabAttack.SetActive(true);
                        Grab.PlayerAbility_Grab();
                    }
                    
                    if(CharacterIndex != 3)
                    {
                        AttackActiveTimer = 0.4f;
                        AttackCooldownTimer = 1f;
                    }
                    else
                    {
                        AttackActiveTimer = 0.3f;
                        AttackCooldownTimer = 1f;
                    }
                }
            }
        }

        //============================================================

        //Handling run animation timing
        RunAnimationTimer -= Time.deltaTime;
        if (RunAnimationTimer < 0)
        {
            RunAnimationTimer = 0;
        }

        //HANDLING ANIMATION
        if (Input.GetAxis("Horizontal") != 0 || Input.GetButton("Left") || Input.GetButton("Right"))
        {
            IsMoving = true;
            //IsRunAnimation1 = true;
            //RunAnimationTimer = 0.2f;
        }
        else
        {
            IsMoving = false;
        }

        //Idle animation
        if (IsMoving == false && Move.IsGrounded == true)
        {
            CharacterSprite.sprite = CharacterIdleSprite;
        }
        else if (Move.IsGrounded == false)      //Airborne animation
        {
            CharacterSprite.sprite = CharacterJumpSprite;
        }
        else if (IsMoving == true)              //Running Animation
        {
            if(IsRunAnimation1 == true)
            {
                CharacterSprite.sprite = CharacterRun1Sprite;

                if (RunAnimationTimer <= 0)
                {
                    RunAnimationTimer = 0.15f;
                    IsRunAnimation1 = false;
                }
            }
            else
            {
                CharacterSprite.sprite = CharacterRun2Sprite;

                if (RunAnimationTimer <= 0)
                {
                    RunAnimationTimer = 0.15f;
                    IsRunAnimation1 = true;
                }
            }
        }
    }
    
    //Gets the references to the character data
    void GetData()
    {
        CharacterIdleSprite = CharacterData[CharacterIndex].IdleSprite;
        CharacterJumpSprite = CharacterData[CharacterIndex].JumpSprite;
        CharacterRun1Sprite = CharacterData[CharacterIndex].Run1;
        CharacterRun2Sprite = CharacterData[CharacterIndex].Run2;
        Move.MaxJumpAmount = CharacterData[CharacterIndex].MaxJumps;
        if(Move.IsGrounded == true)
        {
            Move.JumpAmount = Move.MaxJumpAmount;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage source" && Dash.DashActiveTimer <= -0.2f)
        {
            PlayerManager.RecoverableDamage();
            AudioHandler.HitAudio();
        }

        if (collision.gameObject.tag == "UnrecoverableDamage")
        {
            PlayerManager.NonRecoverableDamage();
            AudioHandler.HitAudio();
            AudioHandler.SplashAudio();
        }
    }
}
