using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public MistralChatBot chatBot;  // Ссылка на MistralChatBot
    public Button sendButton;  // Ссылка на кнопку отправки
    public InputField userInput;  // Ссылка на поле ввода
   

    void Start()
    {
        sendButton.onClick.AddListener(OnSendButtonClick);  // Привязка метода к кнопке
    }

    // Метод, который срабатывает при нажатии на кнопку
    public void OnSendButtonClick()
    {
        string userMessage = userInput.text;  // Получаем текст из поля ввода
        if (!string.IsNullOrEmpty(userMessage))
        {
            StartCoroutine(chatBot.GetChatResponse(userMessage));  // Отправляем запрос
        }
    }
}

