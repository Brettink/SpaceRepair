using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Zoom in camera size = .35
    // Start is called before the first frame update
    public Rigidbody2D body, bodyChar;
    private Rigidbody2D bodyToMove;
    public GameObject pewGo;
    public Transform pewL, pewR;
    public Sprite shipOn, shipOff;
    public SpriteRenderer[] shipBooster;
    public bool isBurn = false;
    public float lastTime;
    void Start()
    {
        lastTime = Time.realtimeSinceStartup;
        GMan.charBod = bodyChar;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - lastTime > 1f)
        {
            if (Input.GetButton("Jump") && GMan.viewMode == 0)
            {
                lastTime = Time.realtimeSinceStartup;
                Instantiate(pewGo, pewL);
                Instantiate(pewGo, pewR);
            }
        }
        if (!GMan.isChange){
            float mx = Input.GetAxis("Horizontal");
            float my = Input.GetAxis("Vertical");
            if (mx != 0 || my != 0)
            {
                if (!isBurn)
                {
                    shipBooster[0].sprite = shipOn;
                    shipBooster[1].sprite = shipOn;
                    isBurn = true;
                }
                Vector2 move_more = new Vector2(mx, my) * GMan.gameStats.engine;

                bodyToMove = (GMan.viewMode == 0) ? body : bodyChar;
                bodyToMove.AddForce(move_more * ((GMan.viewMode == 1) ? .5f : (GMan.shipStatus["engine"])?1:0));
                if (GMan.viewMode == 1)
                {
                    bodyToMove.velocity = Vector2.ClampMagnitude(bodyToMove.velocity, .5f);

                }
            }
            else
            {
                if (isBurn && GMan.shipStatus["engine"])
                {
                    shipBooster[0].sprite = shipOff;
                    shipBooster[1].sprite = shipOff;
                    isBurn = false;
                }
            }
        }
    }

}
