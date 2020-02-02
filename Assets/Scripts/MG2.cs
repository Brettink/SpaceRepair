using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2 : MonoBehaviour
{
    float angleTo = 0f;
    float angleLast = 0;
    float totalAng = 0;
    Vector2 mStart;
    public GameObject roter;
    // Start is called before the first frame update
    void Awake()
    {
        print(GMan.difficulty);
        angleTo = 360f * GMan.difficulty * 5f;
        print(angleTo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mCur = Input.mousePosition;
            float anEr = Vector2.SignedAngle(new Vector2(279.8f, 526.6f), mCur) - angleLast;
            if (anEr != 0)
            {
                angleLast = anEr;
                totalAng -= anEr;
                print(totalAng);
                roter.transform.Rotate(anEr * Vector3.forward);
            }
            if (totalAng > angleTo)
            {
                GMan.curMiniWin = true;
            }
        } else
        {
            angleTo = 0;
        }
    }
}
