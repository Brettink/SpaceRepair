using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class MG3 : MonoBehaviour
{

    public GameObject panel;
    // Start is called before the first frame update
    public Text lineup;
    string[] cons = new string[4];
    string selectedChar = "";
    int selectedInt = 0;
    public LineRenderer[] rends;
    public Transform[] rendT;
    int correct = 0;
    void Awake()
    {
        panel.SetActive(true);
        List<string> aps = new List<string>();
        aps.Add("a"); aps.Add("b"); aps.Add("c"); aps.Add("d");
        for (int i = 0; i < 4; i++)
        {
            int ranI = Random.Range(0, aps.Count);
            cons[i] = aps.ToArray()[ranI];
            aps.RemoveAt(ranI);
            panel.SetActive(true);
        }

        lineup.text = "";
        string lineupNew = "";
        for (int i = 0; i < 4; i++)
        {
            
            lineupNew += cons[i] + "------->" + (i+1) + "\n";
        }
        lineup.text = lineupNew;
    }

    public void butClick(string name)
    {
        selectedChar = name;
        checkCon();
    }

    public void butClickN(int num)
    {
        selectedInt = num;
        checkCon();
    }

    public void checkCon()
    {
        if (selectedInt != 0 && selectedChar != "")
        {
            if (cons[selectedInt-1].Equals(selectedChar))
            {
                int chartoInt = System.Array.IndexOf(cons, selectedChar);
                Vector3 g = rendT[chartoInt].position;
                g.z = -50;
                rends[chartoInt].SetPosition(1, g);
                rends[chartoInt].enabled = true;
                correct += 1;
                if (correct > 3)
                {
                    panel.SetActive(false);
                    GMan.curMiniWin = true;
                }
            } else
            {
                print("Try again");
                selectedChar = "";
                selectedInt = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
