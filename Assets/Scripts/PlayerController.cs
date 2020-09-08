using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    private PlayerBaseState currentState;

    public Text gameOverText;
    public RectTransform gameOverPanel;


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
        if (collision.gameObject.tag == "Ground")
        {
            currentState.OnCollisionEnter2D(this);
        }
        else if (collision.gameObject.tag == "Weapon" || collision.gameObject.tag == "Enemy")
        {
            Kill();
        }
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * runningSpeed;
            horizontalMovement += transform.position.x;

            float limit =
                Mathf.Clamp(horizontalMovement, ScreenBounds.left(), ScreenBounds.right());

            transform.position = new Vector2(limit, transform.position.y);
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
        //Enable Text
        gameOverPanel.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
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
