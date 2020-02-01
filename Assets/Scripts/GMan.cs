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
    public const float VOOMIN = .35f;
    public int halfW = 50;
    public int backDist = 50;
    public Camera main;

    public class stats
    {
        public int engine = 2;
        public int viewscreen = 5;
        public int weapons = 2;
        public int health = 25;
        public int O2 = 100;
    }
    public static stats gameStats = new stats();
    public static int viewMode = 0;
    public static bool isChange = false;
    public Transform camTrans;
    Vector3 posE = Vector3.back * 10;

    public static Dictionary<string, bool> shipStatus = new Dictionary<string, bool>();
    void Start()
    {
        shipStatus.Add("engine", false);
        shipStatus.Add("vs", false);
        shipStatus.Add("weap", false);
        shipStatus.Add("hp", false);
        shipStatus.Add("O2", false);
        camTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && ! isChange)
        {
            switch (viewMode)
            {
                case 0:
                    {
                        Camera.main.transform.parent = Character.transform;
                        isChange = true;
                        viewMode = 1;
                        break;
                    }
                case 1:
                    {
                        Camera.main.transform.parent = null;
                        isChange = true;
                        viewMode = 0;
                        break;
                    }
            }
            posE = camTrans.localPosition;
            print(posE);
        }
        float canSpawn = Random.value * 10000;
        if (canSpawn < 200)
        {
            for (int i = 0; i < (difficulty * difficulty); i++)
            {
                int L_R = Random.Range(-halfW, halfW);
                GameObject aster = Instantiate(_aster_imgs_pref, Vector2.zero, Quaternion.identity);
                Vector2 pos = new Vector2(L_R, backDist);
                aster.transform.position = pos;
            }
        }
        if (isChange)
        {
            posE = camTrans.localPosition;
            if (Vector3.Distance(posE, Vector3.back*10) > 1f)
            {
                posE = Vector3.Lerp(posE, Vector3.back * 10, .1f);
                main.orthographicSize = Mathf.Lerp(main.orthographicSize, (viewMode == 0) ? gameStats.viewscreen : VOOMIN, .1f);
                camTrans.localPosition = posE;
            } else
            {
                camTrans.localPosition = Vector3.back * 10;
                main.orthographicSize = (viewMode == 0) ? gameStats.viewscreen : VOOMIN;
                isChange = false;
            }
        }
    }
}
