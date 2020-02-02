using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.gameObject.name);
        if (collision.collider.gameObject.tag.Equals("Fix"))
        {
            if (!GMan.shipStatus[collision.collider.gameObject.name])
            {
                GMan.showMini(collision.collider.gameObject.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
