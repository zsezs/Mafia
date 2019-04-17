using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleManager : MonoBehaviour
{
    public Text rollName ;
    public GameObject rollPanel;

    public void Awake()
    {
       // rollPanel = new GameObject();
        rollPanel.SetActive(false);

    }
    public void Start()
    {
      
    }

    public void Update()
    {
        rollName.text = "Mafia";
    }

    public void onClick()
    {
        rollPanel.SetActive(true);
    }

}
