using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class ChatManager : MonoBehaviour {

    public string username;
    public string room;
    public int maxMessages = 25;
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public GameObject go;
	public SocketIOComponent socket;
    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    public void Awake(){

        go = LevelManager.go;

        socket = go.GetComponent<SocketIOComponent>();

        DontDestroyOnLoad(go);
        DontDestroyOnLoad(socket);

        LevelManager.socket.On("message_r", (SocketIOEvent e) => {

			JSONObject j = new JSONObject(e.data.ToString());

			string name = j.GetField("name").ToString();

			string message = j.GetField("message").ToString();

            ShowMessage(name, message);             
		});

        LevelManager.socket.On("itsCourt", (SocketIOEvent e)=>{

            SceneManager.LoadScene("Court");
        });
	}

    public void start(){

        

        //this.socket = LevelManager.socket;

            this.room = LevelManager.room;

            /*LevelManager.socket.On("message_r", (SocketIOEvent e) => {

                Debug.Log("message_r");

                JSONObject j = new JSONObject(e.data.ToString());

                string name = j.GetField("name").ToString();

                string message = j.GetField("message").ToString();

                Debug.Log(message);

                ShowMessage(name, message);
            });*/

            

            /* LevelManager.socket.On("itsCourt", (SocketIOEvent e)=>{

                SceneManager.LoadScene("Court");
            });*/
    }
    
    public void SendMessageToChat(string text, string room){

        Dictionary<string, string> data = new Dictionary<string, string>();

        
		data["name"] = username;
        
		data["message"] = text;

        data["room"] = LevelManager.room;

		LevelManager.socket.Emit("send_message", new JSONObject(data));
    }

	public void ShowMessage(string name, string text){

		if (messageList.Count >= maxMessages){
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message(name , text);

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.name+" : "+newMessage.text;

        newMessage.textObject.color = MessageTypeColor(Message.MessageType.playerMessage);

        messageList.Add(newMessage);
	}

	void Update () {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return)){

                SendMessageToChat(chatBox.text, this.room);
                GameObject.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition = 0.0f;
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return)){
                
                GameObject.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition = 0.0f;
                chatBox.ActivateInputField();
            }
        }
        
	}


    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;

            case Message.MessageType.lootInfo:
                break;
        }

        return color;
    }

    [System.Serializable]
    public class Message
    {
        public Message(string name, string text){
            this.name = name;
            this.text = text;
        }
        public string name;
        public string text;
        public Text textObject;
        public MessageType messageType;

        public enum MessageType
        {
            playerMessage,
            info,
            lootInfo
        }
    }
}
