using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SocketIO;

public class LevelManager : MonoBehaviour {

	static public GameObject go;
	static public SocketIOComponent socket;

	static public string room;

	public void Awake(){

		go = GameObject.Find("SocketIO");
    	
		socket = go.GetComponent<SocketIOComponent>();

		//DontDestroyOnLoad(go);
		DontDestroyOnLoad(socket);
	}

	public void Start(){

		socket.On("join_r", (SocketIOEvent e) => {

			JSONObject j = new JSONObject(e.data.ToString());

			room = j.GetField("room").ToString();
			room = room.Substring(1,room.Length-2);

			SceneManager.LoadScene("Chat");
		});

		socket.On("message_r", (SocketIOEvent e) => {

			Debug.Log("got message");

			JSONObject j = new JSONObject(e.data.ToString());

			string name = j.GetField("name").ToString();

			string message = j.GetField("message").ToString();

			Debug.Log(message);
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
}
