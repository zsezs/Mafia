using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodManager : MonoBehaviour
{
    public GameObject godPanel;
    public GameObject textPanel;

    public Text title;
    public Text body;
    public Text date;


    void Start()
    {
        godPanel.SetActive(false);
    }
    void Update()
    {
        
    }

    public void onClickToShow()
    {
        textManager("Kill:", "       Mafia Killed Alireza", "Day 1");
        //ScrollSnapRect ssr = godPanel.GetComponentsInChildren<ScrollSnapRect>()[0];
        //GameObject go = new GameObject("text Maker");
        //go.transform.SetParent(godPanel.transform.GetChild(0).transform.GetChild(0).transform);
        //Text t = go.AddComponent<Text>();
        //t.text = "fasdkfjaslkfdjaslkdfjlaskdfjlaksjflkasjflkas";
        //ssr._pageCount++;
        //ssr.SetPagePositions();
        godPanel.SetActive(true);
    }
    public void onClickToInvisible()
    {
        godPanel.SetActive(false);
    }

    public void textManager(string title, string body, string date)
    {
        this.title.text = title;
        this.body.text = body;
        this.date.text = date;

        ScrollSnapRect ssr = godPanel.GetComponentsInChildren<ScrollSnapRect>()[0];
        GameObject go = GameObject.Instantiate(textPanel, new Vector3(0,0,0), Quaternion.identity);
        
        go.transform.SetParent(godPanel.transform.GetChild(0).transform.GetChild(0).transform);

        go.transform.localScale = new Vector3(1, 1, 1);

        ssr._pageCount++;
        ssr.SetPagePositions();
      }
}
