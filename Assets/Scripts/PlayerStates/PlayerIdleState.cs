using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("Entered Idle State");
    }

    public override void OnCollisionEnter2D(PlayerController player)
    {

        //check for projectile collisions/enemy collisions
    }

    public override void Update(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetRigidbody().AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
            player.TransitionToState(player.jumpingState);
        }
    }
}
