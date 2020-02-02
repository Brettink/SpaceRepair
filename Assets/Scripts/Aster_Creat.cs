using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aster_Creat : MonoBehaviour
{
    Vector2 dir = Vector2.down * 2;
    public float max_deviation = 20f;
    public Rigidbody2D bod;
    public GameObject BrokenPrefab;
    // Start is called before the first frame update

    public Vector2 DegToVec2(float rad)
    {
        return new Vector2(Mathf.Cos(rad) * Mathf.Rad2Deg, Mathf.Sin(rad) * Mathf.Rad2Deg);
    }
    void Start()
    {
        int rInt = (int)Random.Range(0, 3);
        float size = Random.Range(.25f, .75f);
        transform.localScale = Vector2.one * size;
        GetComponent<SpriteRenderer>().sprite = GMan.asters[rInt];
        dir.x = Random.Range(-max_deviation, max_deviation);
        bod.velocity = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.name.Contains("Astr"))
        {
            int ranNum = Random.Range(1, 3);
            for (int i = 0; i < ranNum; i++)
            {
                print(collision.gameObject.name);
                int startEnd = (collision.gameObject.tag == "Player") ? 8 : 12;
                SpriteRenderer rd = Instantiate(BrokenPrefab).GetComponent<SpriteRenderer>();
                rd.transform.position = transform.position;
                int angle = Random.Range(0, 360);
                rd.GetComponent<Rigidbody2D>().velocity = DegToVec2(angle)*.025f;
                int rdIn = Random.Range(4, startEnd);
                rd.sprite = GMan.asters[rdIn];
            }
            Destroy(this.gameObject);
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
