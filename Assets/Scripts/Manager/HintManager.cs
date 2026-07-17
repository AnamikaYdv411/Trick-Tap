using UnityEngine;
using TMPro;
using System.Collections;
public class HintManager : MonoBehaviour
{
    public static HintManager Instance;
    public TMP_Text hintPanelText;
    public CanvasGroup hintPanelGroup;
    public float showDuration = 1.5f;
    public float fadeDuration = 0.5f;

    [HideInInspector] public string currentHintValue;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetHint(string value, string displayText)
    {
        currentHintValue = value;
        StopAllCoroutines();
        StartCoroutine(ShowThenFade(displayText));
    }

    IEnumerator ShowThenFade(string text)
    {
        hintPanelText.text = text;
        hintPanelGroup.alpha = 1f;
        yield return new WaitForSeconds(showDuration);
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            hintPanelGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
    }
}
