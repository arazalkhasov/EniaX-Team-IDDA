using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public MistralChatBot chatBot;  
    public Button sendButton;  
    public InputField userInput;  
   

    void Start()
    {
        sendButton.onClick.AddListener(OnSendButtonClick);  
    }

   
    public void OnSendButtonClick()
    {
        string userMessage = userInput.text;  
        if (!string.IsNullOrEmpty(userMessage))
        {
            StartCoroutine(chatBot.GetChatResponse(userMessage)); 
        }
    }
}


