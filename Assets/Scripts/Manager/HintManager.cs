using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class HintManager : MonoBehaviour
{
    public static HintManager Instance;
    public TMP_Text hintPanelText;
    public CanvasGroup hintPanelGroup;
    public float showDuration = 1.5f;
    public float fadeDuration = 0.5f;

    [Header("Freeze Popup")]
    public GameObject hintPopupPanel;
    public TMP_Text hintPopupText;
    public TMP_Text hintPopupTimerText;
    public float freezeDuration = 2f;

    [HideInInspector] public string currentHintValue;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Correct envelope: updates currentHintValue AND shows popup
    public void SetHint(string value, string displayText, Action onComplete = null)
    {
        currentHintValue = value;
        StopAllCoroutines();
        StartCoroutine(FreezeAndShowPopup(displayText, onComplete));
    }

    // Wrong envelope: shows the SAME popup, but does not touch currentHintValue
    public void ShowMisleadingHint(string displayText, Action onComplete = null)
    {
        StopAllCoroutines();
        StartCoroutine(FreezeAndShowPopup(displayText, onComplete));
    }

    IEnumerator FreezeAndShowPopup(string text, Action onComplete)
    {
        hintPopupText.text = text;
        hintPopupPanel.SetActive(true);
        Time.timeScale = 0f;

        float remaining = freezeDuration;
        while (remaining > 0f)
        {
            hintPopupTimerText.text = Mathf.Ceil(remaining).ToString();
            yield return new WaitForSecondsRealtime(Mathf.Min(0.1f, remaining));
            remaining -= 0.1f;
        }
        hintPopupTimerText.text = "0";

        hintPopupPanel.SetActive(false);
        Time.timeScale = 1f;

        onComplete?.Invoke();
    }
}