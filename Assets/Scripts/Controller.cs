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

    // Update is called once per frame
    void Update()
    {
        {
            float mx = Input.GetAxis("Horizontal");
            float my = Input.GetAxis("Vertical");
            Vector2 move_more = new Vector2(mx, my) * GMan.gameStats.engine;

            body.AddForce(move_more);
        }
    }
}
