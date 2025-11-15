using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPage2Animation : MonoBehaviour
{
    
        public CanvasGroup xosgeldin, namestart, category, kapital, ilkay, eventsystem, investor, ustmenu;
        public CanvasGroup robot, aid1, aid2;
        public InputField inputField, Pul;
        public Text textDisplay, PulText;

        void Start()
        {
            StartCoroutine(FadeIn(xosgeldin));
            inputField.onValueChanged.AddListener(UpdateText);
            Pul.onValueChanged.AddListener(PulUpdate);
        }

        void UpdateText(string newText)
        {
            textDisplay.text = newText;
        }

        void PulUpdate(string newText)
        {
            PulText.text = newText + "$";
        }

        public void davamet()
        {
            StartCoroutine(FadeOut(xosgeldin));
            StartCoroutine(FadeIn(namestart));
        }

        public void davamet1()
        {
            StartCoroutine(FadeOut(namestart));
            StartCoroutine(FadeIn(category));
        }

        public void davamet2()
        {
            StartCoroutine(FadeOut(category));
            StartCoroutine(FadeIn(kapital));
        }

        public void davamet3()
        {
            StartCoroutine(FadeOut(kapital));
            StartCoroutine(FadeIn(ustmenu));
            StartCoroutine(FadeIn(robot));
            StartCoroutine(FadeIn(aid1));
        }

        public void davamet4()
        {
            StartCoroutine(FadeOut(aid1));
            StartCoroutine(FadeIn(aid2));
        }

        IEnumerator FadeIn(CanvasGroup canvas, float duration = 0.5f)
        {
            canvas.gameObject.SetActive(true);
            canvas.alpha = 0;
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                canvas.alpha = Mathf.Lerp(0, 1, t / duration);
                yield return null;
            }
            canvas.alpha = 1;
        }

        IEnumerator FadeOut(CanvasGroup canvas, float duration = 0.5f)
        {
            canvas.alpha = 1;
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                canvas.alpha = Mathf.Lerp(1, 0, t / duration);
                yield return null;
            }
            canvas.alpha = 0;
            canvas.gameObject.SetActive(false);
        }
    }

