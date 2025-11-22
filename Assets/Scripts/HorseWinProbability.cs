using UnityEngine;
using TMPro;

public class HorseWinProbability : MonoBehaviour
{
    [Header("Horse Movement Scripts")]
    [SerializeField] private HorseMovement whiteHorse;
    [SerializeField] private HorseMovement goldenHorse;
    [SerializeField] private HorseMovement blackHorse;

    [Header("Probability Texts")]
    [SerializeField] private TextMeshProUGUI whiteProbabilityText;
    [SerializeField] private TextMeshProUGUI goldenProbabilityText;
    [SerializeField] private TextMeshProUGUI blackProbabilityText;

    void Update()
    {
        UpdateProbabilities();
    }

    void UpdateProbabilities()
    {
        int whiteRemaining = whiteHorse.GetApplesCount() - 1 - whiteHorse.GetCurrentIndex();
        int goldenRemaining = goldenHorse.GetApplesCount() - 1 - goldenHorse.GetCurrentIndex();
        int blackRemaining = blackHorse.GetApplesCount() - 1 - blackHorse.GetCurrentIndex();

        if (whiteRemaining <= 0)
        {
            whiteProbabilityText.text = "Probabilidade: 100%";
            goldenProbabilityText.text = "Probabilidade: 0%";
            blackProbabilityText.text = "Probabilidade: 0%";
            return;
        }
        if (goldenRemaining <= 0)
        {
            whiteProbabilityText.text = "Probabilidade: 0%";
            goldenProbabilityText.text = "Probabilidade: 100%";
            blackProbabilityText.text = "Probabilidade: 0%";
            return;
        }
        if (blackRemaining <= 0)
        {
            whiteProbabilityText.text = "Probabilidade: 0%";
            goldenProbabilityText.text = "Probabilidade: 0%";
            blackProbabilityText.text = "Probabilidade: 100%";
            return;
        }

        whiteRemaining = Mathf.Max(whiteRemaining, 1);
        goldenRemaining = Mathf.Max(goldenRemaining, 1);
        blackRemaining = Mathf.Max(blackRemaining, 1);

        int minRemaining = Mathf.Min(whiteRemaining, goldenRemaining, blackRemaining);

        float whiteAdv = (float)minRemaining / whiteRemaining;
        float goldenAdv = (float)minRemaining / goldenRemaining;
        float blackAdv = (float)minRemaining / blackRemaining;

        float totalAdv = whiteAdv + goldenAdv + blackAdv;

        float whiteProb = (whiteAdv / totalAdv) * 100f;
        float goldenProb = (goldenAdv / totalAdv) * 100f;
        float blackProb = (blackAdv / totalAdv) * 100f;

        whiteProbabilityText.text = $"Probabilidade: {whiteProb:F1}%";
        goldenProbabilityText.text = $"Probabilidade: {goldenProb:F1}%";
        blackProbabilityText.text = $"Probabilidade: {blackProb:F1}%";
    }
}