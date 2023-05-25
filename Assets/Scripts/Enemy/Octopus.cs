using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    //References

    public BoxCollider2D Hitbox;
    public LinearTriggerHandler TriggerHandler;
    public Transform SelfTransform;
    public Transform TriggerBoxTransform;
    public Transform DamageBoxTransform;
    public Rigidbody2D EnemyRigidBody;
    public GameObject Self;
    public AudioHandler AudioHandler;
    public PlayerMovement PlayerMovement;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public SpriteRenderer SpriteRenderer;

    //Variables
    public bool IsDirectionRight;
    public float Direction;
    public float Velocity;
    public bool IsColliding;
    public bool IsHanging;
    public int Health;
    public int MaxHealth;
    public float ImmunityTimer;

    void Start()
    {
        Health = MaxHealth;
        IsHanging = true;
        SpriteRenderer.sprite = Sprite1;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerBoxTransform.position = SelfTransform.position;
        DamageBoxTransform.position = SelfTransform.position;

        ImmunityTimer -= Time.deltaTime;

        if (TriggerHandler.IsTriggered == true)
        {

            if (IsHanging == true)
            {
                IsHanging = false;
                EnemyRigidBody.bodyType = RigidbodyType2D.Dynamic;
                EnemyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                EnemyRigidBody.AddForce(transform.up * 300);
                AudioHandler.JumpAudio();
                SpriteRenderer.sprite = Sprite2;
                SpriteRenderer.flipY = true;
            }
        }

        if (Health <= 0)
        {
            Self.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = true;
        }
        if (collision.gameObject.tag == "Player Attack" && ImmunityTimer <= 0)
        {
            AudioHandler.HitAudio();
            Health -= 1;
            ImmunityTimer = 0.4f;
        }
        if (collision.gameObject.tag == "Player HeavyAttack" && ImmunityTimer <= 0)
        {
            AudioHandler.HitAudio();
            Health -= 2;
            ImmunityTimer = 0.4f;
        }
        if (collision.gameObject.tag == "Whip" && ImmunityTimer <= 0)
        {
            AudioHandler.HitAudio();
            Health -= 1;
            ImmunityTimer = 0.4f;
            EnemyRigidBody.bodyType = RigidbodyType2D.Dynamic;
            EnemyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            EnemyRigidBody.AddForce(new Vector2(PlayerMovement.PlayerDirectionInverse * 100, 0));
        }

        //HANDLES LANDING
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Player Attack" && collision.gameObject.tag != "Player HeavyAttack" && collision.gameObject.tag != "Whip")
        {
            Self.SetActive(false);
            //SpriteRenderer.flipY = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = false;
        }
    }
}
