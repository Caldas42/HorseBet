using UnityEngine;

public class AppleHistogram : MonoBehaviour
{
    [Header("Horses")]
    [SerializeField] private HorseMovement whiteHorse;
    [SerializeField] private HorseMovement goldenHorse;
    [SerializeField] private HorseMovement blackHorse;

    [Header("UI Bars")]
    [SerializeField] private RectTransform whiteBar;
    [SerializeField] private RectTransform goldenBar;
    [SerializeField] private RectTransform blackBar;

    [Header("Number Texts")]
    [SerializeField] private TMPro.TextMeshProUGUI whiteNumberText;
    [SerializeField] private TMPro.TextMeshProUGUI goldenNumberText;
    [SerializeField] private TMPro.TextMeshProUGUI blackNumberText;

    [Header("Max Height of Bar")]
    [SerializeField] private float maxBarHeight = 200f;

    void Start()
    {
        UpdateHistogram();
    }

    public void UpdateHistogram()
    {
        int maxApples = whiteHorse.GetApplesCount() - 1;

        int whiteEaten = whiteHorse.GetCurrentIndex();
        int goldenEaten = goldenHorse.GetCurrentIndex();
        int blackEaten = blackHorse.GetCurrentIndex();

        whiteNumberText.text = whiteEaten.ToString();
        goldenNumberText.text = goldenEaten.ToString();     
        blackNumberText.text = blackEaten.ToString();

        float whiteHeight = (float)whiteEaten / maxApples * maxBarHeight;
        float goldenHeight = (float)goldenEaten / maxApples * maxBarHeight;
        float blackHeight = (float)blackEaten / maxApples * maxBarHeight;

        whiteBar.sizeDelta = new Vector2(whiteBar.sizeDelta.x, whiteHeight);
        goldenBar.sizeDelta = new Vector2(goldenBar.sizeDelta.x, goldenHeight);
        blackBar.sizeDelta = new Vector2(blackBar.sizeDelta.x, blackHeight);
    }
}
