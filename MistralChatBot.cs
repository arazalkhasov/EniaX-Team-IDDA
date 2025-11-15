using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using TMPro;
using Newtonsoft.Json.Linq;


public class MistralChatBot : MonoBehaviour
{
    private string apiKey = "LXNiqmkTYG1bLjemOzAxUD6NENWKjsdZ"; 
    private string apiUrl = "https://api.mistral.ai/v1/chat/completions";
    public TMP_Text responseText;
    public void SendMessageToMistral(string userMessage)
    {
       
        string prompt = "Lütfen aşağıdaki soruya sadece 1 çok kısa yanıt ver:\n" + userMessage;

        StartCoroutine(GetChatResponse(prompt));
    }

    public IEnumerator GetChatResponse(string userMessage)
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            Debug.LogError("API anahtarı belirtilmedi!");
            yield break;
        }

        string jsonPayload = "{\"model\":\"mistral-tiny\",\"max_tokens\":60,\"messages\":[{\"role\":\"user\",\"content\":\"" + userMessage + "\"}]}";

        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + apiKey);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Hata: " + request.error);
                responseText.text = "Hata: " + request.error;
            }
            else
            {
                string response = request.downloadHandler.text;

               
                string assistantMessage = ExtractMessageFromJson(response);
                responseText.text = assistantMessage;
            }
        }
    }

    private string ExtractMessageFromJson(string jsonResponse)
    {
        try
        {
            JObject json = JObject.Parse(jsonResponse);
            return json["choices"][0]["message"]["content"].ToString();
        }
        catch
        {
            return "Yanıt işlenemedi.";
        }
    }
    private string EnsureEndingPeriod(string response)
    {
        response = response.Trim(); 
        if (response.EndsWith("."))
        {
            response += "."; 
        }
        return response;
    }

}

