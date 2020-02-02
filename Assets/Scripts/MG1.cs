using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1 : MonoBehaviour
{
    public Transform hammer, nails;
    public Transform[] nailArr;
    public SpriteRenderer hand;
    float angleRest = 45f, angleHam = 90f;
    bool hammers = true;
    bool hamDir = false;
    // Start is called before the first frame update
    void Start()
    {

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
        Vector2 pos = nails.localPosition;
        pos.x += .02f;
        if (pos.x > 6)
        {
            pos.x = -10;
        }
        nails.localPosition = pos;
    }
}
