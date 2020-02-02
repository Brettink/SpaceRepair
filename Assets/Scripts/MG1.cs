using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1 : MonoBehaviour
{
    public Transform hammer;
    public GameObject nails;
    public SpriteRenderer hand;
    float angleRest = 45f, angleHam = 90f;
    public static int numHit = 0;
    public BoxCollider2D end;
    bool hammers = true;
    bool hamDir = false;
    private Transform curNails;
    // Start is called before the first frame update
    void Awake()
    {
        numHit = 0;
        curNails = Instantiate(nails).transform;
        curNails.parent = transform;
        curNails.localPosition = new Vector2(-10, 0);
        //curNails.GetComponent<Rigidbody2D>().velocity = Vector2.right * 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !hammers)
        {
            hammers = true;
            hamDir = false;
        }
        if (hammers)
        {
            int dir = (hamDir)?-1: 1;
            hammer.RotateAround(hammer.position, Vector3.forward, 3f*dir);
            if (Mathf.Abs(hammer.localRotation.eulerAngles.z - ((!hamDir)?angleHam:angleRest)) < 1f)
            {
                if (hamDir)
                {
                    hammers = false;
                }
                hamDir = true;
            }
        }
        Vector2 pos = curNails.localPosition;
        pos.x += .02f;
        curNails.localPosition = pos;
        if (pos.x > 6f)
        {
            if (numHit < 3)
            {
                numHit = 0;
                Destroy(curNails.gameObject);
                curNails = Instantiate(nails).transform;
                curNails.parent = transform;
                curNails.localPosition = new Vector2(-10, 0);
            } else
            {
                numHit = 0;
                GMan.curMiniWin = true;
            }
        }
    }
}
