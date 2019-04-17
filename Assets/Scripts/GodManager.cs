using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodManager : MonoBehaviour
{

    public GameObject godButton;
    public GameObject godPanel;
    
    void Start()
    {
        godPanel.SetActive(false);
    }
    void Update()
    {
        
    }

    public void onClick()
    {
        godPanel.SetActive(true);
    }
}
