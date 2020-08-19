using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("Entered Jumping State!");
    }

    public override void OnCollisionEnter2D(PlayerController player)
    {
        player.TransitionToState(player.idleState);
    }

    public override void Update(PlayerController player)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
