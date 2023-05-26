using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    //References

    public BoxCollider2D Hitbox;
    public TriggerHandler TriggerHandler;
    public Transform PlayerTransform;
    public Transform SelfTransform;
    public Transform WallBoxTransform;
    public Transform FloorBoxTransform;
    public Rigidbody2D EnemyRigidBody;
    public GameObject Self;
    public AudioHandler AudioHandler;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public bool IsSprite1;
    public SpriteRenderer SpriteRenderer;

    //Variables
    public bool IsDirectionRight;
    public float Velocity;
    public bool IsColliding;
    public int Health;
    public int MaxHealth;
    public float ImmunityTimer;
    public float SpriteTimer;

    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        FloorBoxTransform.position = SelfTransform.position;
        WallBoxTransform.position = SelfTransform.position;

        ImmunityTimer -= Time.deltaTime;

        SpriteTimer -= Time.deltaTime;
        if(SpriteTimer < 0)
        {
            if(IsSprite1 == true)
            {
                //SpriteRenderer.flipX = false;
                SpriteRenderer.sprite = Sprite2;
                IsSprite1 = false;
                SpriteTimer = 0.2f;
            }
            else
            {
                //SpriteRenderer.flipX = true;
                SpriteRenderer.sprite = Sprite1;
                IsSprite1 = true;
                SpriteTimer = 0.2f;
            }
        }

        if (IsDirectionRight == true)
        {
            SelfTransform.eulerAngles = new Vector3(0, 0, 0);
            WallBoxTransform.eulerAngles = new Vector3(0, 0, 0);
            FloorBoxTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            SelfTransform.eulerAngles = new Vector3(0, 180, 0);
            WallBoxTransform.eulerAngles = new Vector3(0, 180, 0);
            FloorBoxTransform.eulerAngles = new Vector3(0, 180, 0);
        }

        SelfTransform.Translate(Vector3.right * Velocity * Time.deltaTime);

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
