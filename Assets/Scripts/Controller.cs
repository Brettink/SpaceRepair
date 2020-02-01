using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Zoom in camera size = .35
    // Start is called before the first frame update
    public Rigidbody2D body;
    void Start()
    {
        
    }

    Vector2 getKeyAxis(KeyCode e, Vector2 axis)
    {
        if (Input.GetKey(e))
        {
            return axis*3;
        }
        else
        {
            return Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        {
            float mx = Input.GetAxis("Horizontal");
            float my = Input.GetAxis("Vertical");
            Vector2 move_more = new Vector2(mx, my);

            body.AddForce(move_more/10f, ForceMode2D.Impulse);
        }
    }
}
