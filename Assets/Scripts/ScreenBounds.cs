using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private static Vector2 bounds;
    public static float spriteHeight;
    public static float spriteWidth;

    public static float left() { return -bounds.x + spriteWidth; }
    public static float right() { return bounds.x - spriteWidth; }

    public static float up() { return bounds.y + spriteHeight; }
    public static float down() { return -bounds.y - spriteHeight; }


    // Start is called before the first frame update
    void Start()
    {
        spriteHeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        spriteWidth = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        Vector3 screenVector = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        bounds = Camera.main.ScreenToWorldPoint(screenVector);
    }

    private void LateUpdate()
    {
       
    }

}
