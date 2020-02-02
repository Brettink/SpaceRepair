using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Camera.main.transform.position) > 15)
        {
            Destroy(this.gameObject);
        }
    }
}
