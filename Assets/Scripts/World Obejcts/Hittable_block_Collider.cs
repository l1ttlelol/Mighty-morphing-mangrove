using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable_block_Collider : MonoBehaviour
{
    public Rigidbody2D BlockPhysics;
    public PlayerMovement PlayerMovement;
    public AudioHandler AudioHandler;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player HeavyAttack")
        {
            AudioHandler.HitAudio();
            BlockPhysics.bodyType = RigidbodyType2D.Dynamic;
            BlockPhysics.constraints = RigidbodyConstraints2D.FreezeRotation;
            BlockPhysics.AddForce(transform.up * 150);
            BlockPhysics.AddForce(new Vector2(PlayerMovement.PlayerDirection * 200, 0));
        }
    }
}
