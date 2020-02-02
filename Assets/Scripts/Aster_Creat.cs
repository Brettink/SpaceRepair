using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aster_Creat : MonoBehaviour
{
    Vector2 dir = Vector2.down * 2;
    public float max_deviation = 20f;
    public Rigidbody2D bod;
    // Start is called before the first frame update
    void Start()
    {
        int rInt = (int)Random.Range(0, 3);
        float size = Random.Range(.25f, .75f);
        transform.localScale = Vector2.one * size;
        GetComponent<SpriteRenderer>().sprite = GMan.asters[rInt];
        dir.x = Random.Range(-max_deviation, max_deviation);
        bod.velocity = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
