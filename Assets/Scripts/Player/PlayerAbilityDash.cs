using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityDash : MonoBehaviour
{
    public Rigidbody2D Player;
    public PlayerMovement PlayerMovement;
    public float DashActiveTimer;
    
    void Update()
    {
        DashActiveTimer -= Time.deltaTime;
        if (DashActiveTimer <= 0) { DashActiveTimer = 0; } else                    //Moving the player via dash if the dash timer is positive
        {
            PlayerMovement.PlayerTransform.Translate(new Vector2(PlayerMovement.PlayerDirection * 0.03f, 0));
        }
    }

    //Applying a timer for how long the current dash is
    public void PlayerAbility_Dash()
    {
        DashActiveTimer = 0.4f;
    }
}
