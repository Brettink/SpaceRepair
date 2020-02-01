using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _aster_imgs_pref;
    public GameObject Character;
    public static int score = 0;
    public static float damage = 0f;
    public static float difficulty = 1.25f;
    public int halfW = 50;
    public int backDist = 50;

    public class stats
    {
        public int engine = 2;
        public int viewscreen = 5;
        public int weapons = 2;
        public int health = 25;
        public int O2 = 100;
    }
    public static stats gameStats = new stats();

    public static Dictionary<string, bool> shipStatus = new Dictionary<string, bool>();
    void Start()
    {
        shipStatus.Add("engine", false);
        shipStatus.Add("vs", false);
        shipStatus.Add("weap", false);
        shipStatus.Add("hp", false);
        shipStatus.Add("O2", false);
        print(difficulty * Mathf.Pow(Mathf.PI, difficulty));
    }

    // Update is called once per frame
    void Update()
    {
        float canSpawn = Random.value * 10000;
        if (canSpawn < 200)
        {
            print((difficulty * Mathf.Log(difficulty)));
            for (int i = 0; i < (difficulty * difficulty); i++)
            {
                int L_R = Random.Range(-halfW, halfW);
                GameObject aster = Instantiate(_aster_imgs_pref, Vector2.zero, Quaternion.identity);
                Vector2 pos = new Vector2(L_R, backDist);
                aster.transform.position = pos;
            }
        }
    }
}
