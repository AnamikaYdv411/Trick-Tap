using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCard : MonoBehaviour
{
    public int levelNumber = 1;
    public TMP_Text numberText;
    public Button playButton;
    public LevelSelect levelSelect;

    void Start()
    {
        if (numberText) numberText.text = levelNumber.ToString();
        playButton.onClick.AddListener(() => levelSelect.LoadLevel(levelNumber));
    }
}