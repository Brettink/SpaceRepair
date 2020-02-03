using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GMan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _aster_imgs_pref;
    public GameObject Character;
    public static Rigidbody2D charBod;
    public static GMan gMan;
    public static int sideV = 0;
    public static int scoreV = 0;
    public Image oxy;
    float timeOxy = 0f;
    public static List<int> rGames = new List<int>();
    public static int score
    {
        get
        {
            return scoreV;
        }
        set
        {
            scoreV = value;
            gMan.scr.text = "" + scoreV;
        }
    }
    public static float damageV = 0f;
    //public 
    public static float damage
    {
        get
        {
            return damageV;
        }
        set
        {
            damageV = value;
            if (damageV > 99)
            {
                Application.Quit();
            }
            gMan.dmg.text = damageV + "%";
                sideV = 0;
                rGames.Add(Random.Range(0, 3));
                int fix = Random.Range(0, 5);
            string name = "";
            switch (fix)
            {
                case 0: gMan.o2R.sprite = gMan.o2[1]; name = "O2"; break;
                case 1: gMan.navR.sprite = gMan.nav[1]; name = "vs"; break;
                case 2: gMan.radR.sprite = gMan.rad[1]; name = "rad"; break;
                case 3: gMan.gunR.sprite = gMan.gun[1]; name = "weap"; break;
                case 4: gMan.engR.sprite = gMan.eng[1]; name = "engine"; break;
            }
            if (fix == 0 && shipStatus["O2"])
            {
                gMan.timeOxy = Time.realtimeSinceStartup;
            }
            shipStatus[name] = false;
        }
    }
    public GameObject curGame;
    public static float difficulty = 1.35f;
    public const float VOOMIN = .35f;
    public int halfW = 50;
    public int backDist = 50;
    public Camera main;
    public Controller con;
    public static Sprite[] asters;
    public static bool curWinV = false;
    public static bool curMiniWin
    {
        get
        {
            return curWinV;
        }
        set
        {
            if (value)
            {
                gMan.miniShow.SetActive(false);
                gMan.curGame.SetActive(false);
                shipStatus[gMan.fixWhat] = true;
                int strGame = 0;
                switch (gMan.fixWhat)
                {
                    case "O2": strGame = 0; break;
                    case "vs": strGame = 1; break;
                    case "rad": strGame = 2; break;
                    case "weap": strGame = 3; break;
                    case "engine": strGame = 4; break;
                }
                switch (strGame)
                {
                    case 0: gMan.o2R.sprite = gMan.o2[0]; break;
                    case 1: gMan.navR.sprite = gMan.nav[0]; break;
                    case 2: gMan.radR.sprite = gMan.rad[0]; break;
                    case 3: gMan.gunR.sprite = gMan.gun[0]; break;
                    case 4: gMan.engR.sprite = gMan.eng[0]; break;
                }
                damage -= 2f;
                viewMode = 1;
            }
        }
    }
    public Text dmg, scr;

    public Sprite[] o2, nav, rad, gun, eng;
    public SpriteRenderer o2R, navR, radR, gunR, engR;
    public GameObject[] miniGames;
    public GameObject miniShow;
    public string fixWhat = "";

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


    public static void showMini(string name)
    {
        gMan.curGame = gMan.miniGames[rGames[0]];
        gMan.curGame.SetActive(true);
        rGames.Remove(0);
        curMiniWin = false;
        gMan.fixWhat = name;
        gMan.miniShow.SetActive(true);
        viewMode = 2;
    }
    private void Awake()
    {
        gMan = this;
        shipStatus.Add("engine", true);
        shipStatus.Add("vs", true);
        shipStatus.Add("weap", true);
        shipStatus.Add("rad", true);
        shipStatus.Add("O2", true);
        camTrans = Camera.main.transform;
        asters = Resources.LoadAll<Sprite>("astroid") as Sprite[];
    }


    // Update is called once per frame
    void Update()
    {
        if (!shipStatus["O2"])
        {
            float alpha = oxy.color.a;
            print(oxy.color);
            if (Time.realtimeSinceStartup - timeOxy > 20f)
            {
                Application.Quit();
            } else
            {
                alpha = (Time.realtimeSinceStartup - timeOxy) / 20f;
            }
            oxy.color = new Color(oxy.color.r, oxy.color.g, oxy.color.b, alpha);
        } else
        {
            oxy.color = new Color(0, 0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.E) && ! isChange)
        {
            switch (viewMode)
            {
                case 0:
                    {
                        Camera.main.transform.parent = Character.transform;
                        isChange = true;
                        viewMode = 1;
                        con.body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY |
                                                RigidbodyConstraints2D.FreezeRotation;
                        charBod.isKinematic = false;
                        break;
                    }
                case 1:
                    {
                        Camera.main.transform.parent = null;
                        isChange = true;
                        viewMode = 0;
                        con.body.constraints = RigidbodyConstraints2D.FreezeRotation;
                        charBod.isKinematic = true;
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
