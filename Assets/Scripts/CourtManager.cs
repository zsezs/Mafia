﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using SocketIO;

public class CourtManager : MonoBehaviour
{

    void Awake(){

        LevelManager.socket.On("itsNight", (SocketIOEvent e)=>{

            SceneManager.LoadScene("Night");
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
