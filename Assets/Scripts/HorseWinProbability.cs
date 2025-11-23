using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HorsePieChartFixed : MonoBehaviour
{
    [Header("Horse Movement Scripts")]
    public HorseMovement whiteHorse;
    public HorseMovement goldenHorse;
    public HorseMovement blackHorse;

    [Header("UI Pie Images (each must be Image Type = Filled, Fill Method = Radial360)")]
    public Image whiteSlice;
    public Image goldenSlice;
    public Image blackSlice;

    [Header("Text Labels (opcional)")]
    public TextMeshProUGUI whiteProbText;
    public TextMeshProUGUI goldenProbText;
    public TextMeshProUGUI blackProbText;

    // Se true atualiza todo frame. Se false, chame UpdatePie() manualmente (recomendado ao clicar no botão)
    public bool updateEveryFrame = false;

    void Update()
    {
        if (updateEveryFrame) UpdatePie();
    }

    // Chame este método quando quiser atualizar o gráfico (ex: depois de andar os cavalos)
    public void UpdatePie()
    {
        // --- calcula probabilidades (mesma lógica que já vinha usando) ---
        int whiteRemaining = whiteHorse.GetApplesCount() - 1 - whiteHorse.GetCurrentIndex();
        int goldenRemaining = goldenHorse.GetApplesCount() - 1 - goldenHorse.GetCurrentIndex();
        int blackRemaining = blackHorse.GetApplesCount() - 1 - blackHorse.GetCurrentIndex();

        float pWhite = 0f, pGolden = 0f, pBlack = 0f;

        if (whiteRemaining <= 0)
        {
            pWhite = 1f; pGolden = 0f; pBlack = 0f;
        }
        else if (goldenRemaining <= 0)
        {
            pWhite = 0f; pGolden = 1f; pBlack = 0f;
        }
        else if (blackRemaining <= 0)
        {
            pWhite = 0f; pGolden = 0f; pBlack = 1f;
        }
        else
        {
            whiteRemaining = Mathf.Max(whiteRemaining, 1);
            goldenRemaining = Mathf.Max(goldenRemaining, 1);
            blackRemaining = Mathf.Max(blackRemaining, 1);

            // heurística: vantagem = 1 / remaining (mais perto => maior)
            float whiteAdv = 1f / (float)whiteRemaining;
            float goldenAdv = 1f / (float)goldenRemaining;
            float blackAdv = 1f / (float)blackRemaining;

            float total = whiteAdv + goldenAdv + blackAdv;

            pWhite = whiteAdv / total;
            pGolden = goldenAdv / total;
            pBlack = blackAdv / total;
        }

        // --- Atualiza textos, se fornecidos ---
        if (whiteProbText) whiteProbText.text = $"{pWhite * 100f:0.0}%";
        if (goldenProbText) goldenProbText.text = $"{pGolden * 100f:0.0}%";
        if (blackProbText) blackProbText.text = $"{pBlack * 100f:0.0}%";

        // --- Atualiza fatias: usamos rotação cumulativa para não sobrepor ---
        // ordem: white -> golden -> black (mas você pode alterar)
        ApplySlice(whiteSlice, pWhite, 0f);
        float startAngleGolden = pWhite * 360f;
        ApplySlice(goldenSlice, pGolden, startAngleGolden);
        float startAngleBlack = (pWhite + pGolden) * 360f;
        ApplySlice(blackSlice, pBlack, startAngleBlack);
    }

    // Ajusta fillAmount e rotaciona o RectTransform para que a fatia comece no ângulo startDegrees.
    // Observação: se o seu Fill Origin não for "Top" ou a direção ficar invertida,
    // você pode trocar o sinal (-startDegrees) para ficar correto.
    void ApplySlice(Image img, float fraction, float startDegrees)
    {
        if (img == null) return;

        // garante que o tipo está correto (apenas cheque — configure no Editor também)
        img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillClockwise = true;
        img.fillOrigin = 0; // top (recomendo deixar Top)

        // aplica quanto da fatia (0..1)
        img.fillAmount = Mathf.Clamp01(fraction);

        // rota a fatia para começar no ângulo desejado
        // usamos -startDegrees porque a rotação Z positiva é anti-horária em Unity UI
        img.rectTransform.localEulerAngles = new Vector3(0f, 0f, -startDegrees);
    }
}