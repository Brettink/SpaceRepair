using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Ast"))
        {
            if (collision.gameObject.transform.parent.tag.Equals("Player"))
            {
                GMan.score += 5;
                Destroy(this.gameObject);
            }
        }
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
