using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    float fMinX = -8.5f;
    float fMaxX = 8.5f;

    bool isMovingLeft = true;

    private Rigidbody2D rBody;


    

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(isMovingLeft == true)
        {
            //Change Direction
            if (rBody.position.x < fMinX)
            {
                isMovingLeft = false;
            }
        }
        else
        {
            // Change Direction
            if (rBody.position.x > fMaxX)
            {
                isMovingLeft = true;
            }
        }

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
}
