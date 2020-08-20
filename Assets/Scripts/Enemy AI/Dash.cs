using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float speed;
    public float dashSpeed;

    float leftBound = -8.5f;
    float dashLocation = -2.5f;
    float rightBound = 8.5f;

    bool isDashing = false;
    bool isMovingLeft = true;

    private Rigidbody2D rBody;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    //TODO: Add dust clouds and an animation

    // Update is called once per frame
    void Update()
    {

        

        #region Patrolling
        if (isMovingLeft == true)
        {
            //Change Direction
            if (rBody.position.x < leftBound)
            {
                isMovingLeft = false;
            }
        }
        else
        {
            // Change Direction
            if (rBody.position.x > rightBound)
            {
                isMovingLeft = true;
            }
        }
        #endregion

        #region Pullback + Dustclouds



        #endregion


        #region Dashing
        if (rBody.position.x < dashLocation && rBody.position.x > leftBound)
        {
            isDashing = true;
        }
        else
        {
            isDashing = false;
        }
        if (isDashing == false)
        {
            if (isMovingLeft == false)
            {
                rBody.transform.Translate(Vector2.right * speed);
                rBody.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                rBody.transform.Translate(Vector2.left * speed);
                rBody.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            if (isMovingLeft == false)
            {
                rBody.transform.Translate(Vector2.right * dashSpeed);
                rBody.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                rBody.transform.Translate(Vector2.left * dashSpeed);
                rBody.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        #endregion

    }
}
