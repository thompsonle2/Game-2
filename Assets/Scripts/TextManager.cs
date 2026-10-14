using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public class TextManager : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI textToDisplay;
    public CanvasGroup popupCanvasGroup; // Controls alpha fade for side scene popups

    [Header("Message Settings")]
    [TextArea(2, 5)]
    public string message = "Inspect result message here";
    public float displayDuration = 3f;
    public float fadeDuration = 1f;

    private Coroutine fadeCoroutine;

    void Start()
    {
        // Auto-get CanvasGroup if not assigned manually
        if (popupCanvasGroup == null && textToDisplay != null)
        {
            popupCanvasGroup = textToDisplay.GetComponentInParent<CanvasGroup>();
        }

        if (popupCanvasGroup != null)
        {
            popupCanvasGroup.alpha = 0f;
        }
    }

    private void OnMouseDown()
    {
        RevealText();
    }

    public void RevealText()
    {
        // 1. Save new message so MainGame objective updates
        PlayerPrefs.SetString("CurrentObjective", message);
        PlayerPrefs.Save();

        // 2. Restart fade sequence
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        if (textToDisplay != null)
        {
            textToDisplay.text = message;
        }

        // Fade in (0 -> 1)
        float elapsedTime = 0f;
        while (elapsedTime < 0.3f)
        {
            elapsedTime += Time.deltaTime;
            if (popupCanvasGroup != null)
            {
                popupCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / 0.3f);
            }
            yield return null;
        }

        if (popupCanvasGroup != null) popupCanvasGroup.alpha = 1f;

        // Stay visible for duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out (1 -> 0)
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            if (popupCanvasGroup != null)
            {
                popupCanvasGroup.alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            }
            yield return null;
        }

        if (popupCanvasGroup != null)
        {
            popupCanvasGroup.alpha = 0f;
        }
    }
}