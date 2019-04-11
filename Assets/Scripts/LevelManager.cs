using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SocketIO;

public class LevelManager : MonoBehaviour {

	public SocketIOComponent socket;

	public string room;

	public void Start(){

		GameObject go = GameObject.Find("SocketIO");
    	
		socket = go.GetComponent<SocketIOComponent>();
		
		socket.On("join_r", (SocketIOEvent e) => {
			
			room = e.room;

			SceneManager.LoadScene("Chat");
		});

		socket.On("message_r", (SocketIOEvent e) => {

			ShowMessage(e.name, e.message);
		});
	}

	public void LoadLevel(string name){

		JoinRoom(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit();
	}

	public void JoinRoom(string name){

		Dictionary<string, string> data = new Dictionary<string, string>();
       	
		data["name"] = name;

       	socket.Emit("join", new JSONObject(data));
	}

	public void SendMessage(string name, string message, string room){

		Dictionary<string, string> data = new Dictionary<string, string>();
       	
		data["name"] = name;
		data["room"] = room;
		data["message"] = message;

		socket.Emit("message", new JSONObject(data));
	}

	public void ShowMessage(string name, string message){

		//create new message card


	}
}
