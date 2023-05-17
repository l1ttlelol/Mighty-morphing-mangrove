using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableEnemy : MonoBehaviour
{
    public Rigidbody2D BlockPhysics;
    public bool IsGrounded;
    public AudioHandler AudioHandler;

    public PlayerMovement PlayerMovement;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player HeavyAttack")
        {
            AudioHandler.HitAudio();
            BlockPhysics.bodyType = RigidbodyType2D.Dynamic;
            BlockPhysics.constraints = RigidbodyConstraints2D.FreezeRotation;
            BlockPhysics.AddForce(transform.up * 150);
            BlockPhysics.AddForce(new Vector2(PlayerMovement.PlayerDirection * 200, 0));
        }

        if (collision.gameObject.tag == "UnrecoverableDamage") 
        { 
            AudioHandler.SplashAudio(); 
        }

        if (collision.gameObject.tag == "Whip")
        {
            AudioHandler.HitAudio();
            BlockPhysics.bodyType = RigidbodyType2D.Dynamic;
            BlockPhysics.constraints = RigidbodyConstraints2D.FreezeRotation;
            BlockPhysics.AddForce(transform.up * 200);
            BlockPhysics.AddForce(new Vector2(PlayerMovement.PlayerDirectionInverse * 100, 0));
        }
    }
}
