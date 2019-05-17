using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteManager : MonoBehaviour
{
    public GameObject votePanel, textObject;

    List<string> memberList = new List<string>();

    public void ShowMemberList ()
    {
        for(int i = 0; i < memberList.Count; i++)
        {
            GameObject newText = Instantiate(textObject, votePanel.transform);
            newText.GetComponent<Text>().text = memberList[i];
            //newText.transform.parent = votePanel.transform;
            //newText.transform.localScale = Vector3.one;

        }
    }
        

    void Start()
    {
        memberList.Add("Alireza");
        memberList.Add("Hooshang");
        memberList.Add("Farzin");
        memberList.Add("Amirmohammad");
        memberList.Add("Mehdi");
        memberList.Add("Rustin");

        ShowMemberList();
    }

    void Update()
    {
        
    }

}
