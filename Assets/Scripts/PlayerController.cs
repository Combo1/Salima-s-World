using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    private PlayerBaseState currentState;

    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerJumpingState jumpingState = new PlayerJumpingState();


    public int jumpForce = 100;
    public int runningSpeed = 10;

    public Rigidbody2D GetRigidbody()
    {
        return rBody;
    }

    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this);
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * runningSpeed;
            horizontalMovement += transform.position.x;

            float limit =
                Mathf.Clamp(horizontalMovement, ScreenBounds.left, ScreenBounds.right);

            transform.position = new Vector2(limit, transform.position.y);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        currentState.Update(this);
    }
}
