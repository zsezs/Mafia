using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using SocketIO;

public class NightManager : MonoBehaviour
{
    void Awake(){

        LevelManager.socket.On("itsDay", (SocketIOEvent e)=>{
            SceneManager.LoadScene("Chat");
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
