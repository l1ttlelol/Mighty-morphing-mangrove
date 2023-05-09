using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable_block_Collider : MonoBehaviour
{
    public Rigidbody2D BlockPhysics;
    public PlayerMovement PlayerMovement;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player HeavyAttack")
        {
            BlockPhysics.bodyType = RigidbodyType2D.Dynamic;
            BlockPhysics.constraints = RigidbodyConstraints2D.FreezeRotation;
            BlockPhysics.AddForce(transform.up * 150);
            BlockPhysics.AddForce(new Vector2(PlayerMovement.PlayerDirection * 200, 0));
        }
    }
}
