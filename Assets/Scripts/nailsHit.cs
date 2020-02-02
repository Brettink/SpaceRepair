using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailsHit : MonoBehaviour
{
    public static bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        transform.parent = null;
        transform.position.Set(0, -400, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
