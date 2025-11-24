using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HorseWinProbabilityPieChart : MonoBehaviour
{
    [Header("Horses")]
    public HorseMovement whiteHorse;
    public HorseMovement goldenHorse;
    public HorseMovement blackHorse;

    [Header("UI Pie Images")]
    public Image whiteSlice;
    public Image goldenSlice;
    public Image blackSlice;

    [Header("Probability Texts")]
    public TextMeshProUGUI whiteProbText;
    public TextMeshProUGUI goldenProbText;
    public TextMeshProUGUI blackProbText;

    void Start()
    {
        UpdatePie();
    }

    public void UpdatePie()
    {
        int whiteRemaining = whiteHorse.GetApplesCount() - 1 - whiteHorse.GetCurrentIndex();
        int goldenRemaining = goldenHorse.GetApplesCount() - 1 - goldenHorse.GetCurrentIndex();
        int blackRemaining = blackHorse.GetApplesCount() - 1 - blackHorse.GetCurrentIndex();

        float pWhite, pGolden, pBlack;

        if (whiteRemaining <= 0 && goldenRemaining > 0 && blackRemaining > 0)
        {
            pWhite = 1f; pGolden = 0f; pBlack = 0f;
        }
        else if (goldenRemaining <= 0 && whiteRemaining > 0 && blackRemaining > 0)
        {
            pWhite = 0f; pGolden = 1f; pBlack = 0f;
        }
        else if (blackRemaining <= 0 && whiteRemaining > 0 && goldenRemaining > 0)
        {
            pWhite = 0f; pGolden = 0f; pBlack = 1f;
        }
        else if (whiteRemaining <= 0 && goldenRemaining <= 0 && blackRemaining > 0)
        {
            if (whiteHorse.GetLastSteps() > goldenHorse.GetLastSteps())
            {
                pWhite = 1f; pGolden = 0f; pBlack = 0f;
            }
            else if (goldenHorse.GetLastSteps() > whiteHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 1f; pBlack = 0f;
            }
            else
            {
                pWhite = 0.5f; pGolden = 0.5f; pBlack = 0f;
            }
        }
        else if (whiteRemaining <= 0 && blackRemaining <= 0 && goldenRemaining > 0)
        {
            if (whiteHorse.GetLastSteps() > blackHorse.GetLastSteps())
            {
                pWhite = 1f; pGolden = 0f; pBlack = 0f;
            }
            else if (blackHorse.GetLastSteps() > whiteHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 0f; pBlack = 1f;
            }
            else
            {
                pWhite = 0.5f; pGolden = 0f; pBlack = 0.5f;
            }
        }
        else if (goldenRemaining <= 0 && blackRemaining <= 0 && whiteRemaining > 0)
        {
            if (goldenHorse.GetLastSteps() > blackHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 1f; pBlack = 0f;
            }
            else if (blackHorse.GetLastSteps() > goldenHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 0f; pBlack = 1f;
            }
            else
            {
                pWhite = 0f; pGolden = 0.5f; pBlack = 0.5f;
            }
        } else if (whiteRemaining <= 0 && goldenRemaining <= 0 && blackRemaining <= 0)
        {
            if (whiteHorse.GetLastSteps() > goldenHorse.GetLastSteps() && whiteHorse.GetLastSteps() > blackHorse.GetLastSteps())
            {
                pWhite = 1f; pGolden = 0f; pBlack = 0f;
            }
            else if (goldenHorse.GetLastSteps() > whiteHorse.GetLastSteps() && goldenHorse.GetLastSteps() > blackHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 1f; pBlack = 0f;
            }
            else if (blackHorse.GetLastSteps() > whiteHorse.GetLastSteps() && blackHorse.GetLastSteps() > goldenHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 0f; pBlack = 1f;
            }
            else if (whiteHorse.GetLastSteps() == goldenHorse.GetLastSteps() && whiteHorse.GetLastSteps() > blackHorse.GetLastSteps())
            {
                pWhite = 0.5f; pGolden = 0.5f; pBlack = 0f;
            }
            else if (whiteHorse.GetLastSteps() == blackHorse.GetLastSteps() && whiteHorse.GetLastSteps() > goldenHorse.GetLastSteps())
            {
                pWhite = 0.5f; pGolden = 0f; pBlack = 0.5f;
            }
            else if (goldenHorse.GetLastSteps() == blackHorse.GetLastSteps() && goldenHorse.GetLastSteps() > whiteHorse.GetLastSteps())
            {
                pWhite = 0f; pGolden = 0.5f; pBlack = 0.5f;
            }
            else
            {
                pWhite = 1f / 3f; pGolden = 1f / 3f; pBlack = 1f / 3f;
            }
        }
        else
        {
            const float expectedMove = (5.5f + 3.5f + 5.166f) / 3f;

            float tWhite = whiteRemaining / expectedMove;
            float tGolden = goldenRemaining / expectedMove;
            float tBlack = blackRemaining / expectedMove;

            float wWhite = 1f / tWhite;
            float wGolden = 1f / tGolden;
            float wBlack = 1f / tBlack;

            float total = wWhite + wGolden + wBlack;

            pWhite = wWhite / total;
            pGolden = wGolden / total;
            pBlack = wBlack / total;
        }

        if (pWhite > 0) 
        {
            whiteProbText.text = $"{pWhite * 100f:0.0}%";
        } else
        {
            whiteProbText.text = "";
        }
        
        if (pGolden > 0) 
        {
            goldenProbText.text = $"{pGolden * 100f:0.0}%";
        } else
        {
            goldenProbText.text = "";
        }

        if (pBlack > 0) {
            blackProbText.text = $"{pBlack * 100f:0.0}%";
        } else
        {
            blackProbText.text = "";
        }

        ApplySlice(whiteSlice, pWhite, 0f);
        float startAngleGolden = pWhite * 360f;
        ApplySlice(goldenSlice, pGolden, startAngleGolden);
        float startAngleBlack = (pWhite + pGolden) * 360f;
        ApplySlice(blackSlice, pBlack, startAngleBlack);

        whiteProbText.rectTransform.rotation = Quaternion.identity;
        goldenProbText.rectTransform.rotation = Quaternion.identity;
        blackProbText.rectTransform.rotation = Quaternion.identity;
    }

    void ApplySlice(Image img, float fraction, float startDegrees)
    {
        if (img == null) return;

        img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillClockwise = true;
        img.fillOrigin = 0;

        img.fillAmount = Mathf.Clamp01(fraction);

        img.rectTransform.localEulerAngles = new Vector3(0f, 0f, -startDegrees);
    }
}