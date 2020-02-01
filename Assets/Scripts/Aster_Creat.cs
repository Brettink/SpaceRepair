using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aster_Creat : MonoBehaviour
{
    public PolygonCollider2D pl;
    public float max_deviation = 2f;
    // Start is called before the first frame update
    void Start()
    {
        int _num_points = Random.Range(5, 15);
        Vector2[] points = new Vector2[_num_points];
        for (int i = 0; i < _num_points; i++)
        {
            float x = Random.Range(-max_deviation, max_deviation)/10;
            float y = Random.Range(-max_deviation, max_deviation)/10;
            print(x + " " + y);
            points[i] = new Vector2(x, y);
        }
        pl.points = points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
