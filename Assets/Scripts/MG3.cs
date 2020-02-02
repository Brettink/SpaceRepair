using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MG3 : MonoBehaviour
{

    public GameObject panel;
    // Start is called before the first frame update
    public Text lineup;
    string[] cons = new string[4];
    void Awake()
    {
        List<string> aps = new List<string>();
        aps.Add("a"); aps.Add("b"); aps.Add("c"); aps.Add("d");
        for (int i = 0; i < 4; i++)
        {
            int ranI = Random.Range(0, aps.Count);
            cons[i] = aps.ToArray()[ranI];
            aps.RemoveAt(ranI);
        }
        
    }

    public void butClick(string name)
    {
        print("HI");
    }

    public void butClickN(int num)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
