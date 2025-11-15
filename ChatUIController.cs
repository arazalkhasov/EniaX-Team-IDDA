using UnityEngine;
using UnityEngine.UI;

public class ChatUIController : MonoBehaviour
{
    public Text responseText;  

    
    public void UpdateResponseText(string response)
    {
        responseText.text = response;  
    }
}

