using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Horses")]
    [SerializeField] private GameObject whiteHorse;
    [SerializeField] private GameObject goldenHorse;
    [SerializeField] private GameObject blackHorse;

    [Header("Panels")]
    [SerializeField] private GameObject whitePanel;
    [SerializeField] private GameObject goldenPanel;
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject whiteWinPanel;
    [SerializeField] private GameObject goldenWinPanel;
    [SerializeField] private GameObject blackWinPanel;

    [Header("Power Buttons")]
    [SerializeField] private GameObject whitePowerButtons;
    [SerializeField] private GameObject goldenPowerButtons;
    [SerializeField] private GameObject blackPowerButtons;

    [Header("Dices")]
    [SerializeField] private GameObject whiteDice;
    [SerializeField] private GameObject goldenDice;
    [SerializeField] private GameObject blackDice;

    [Header("NextHuds")]
    [SerializeField] private GameObject whiteNextHud;
    [SerializeField] private GameObject goldenNextHud;
    [SerializeField] private GameObject blackNextHud;

    [Header("Dice Texts")]
    [SerializeField] private TextMeshProUGUI whiteDiceText;
    [SerializeField] private TextMeshProUGUI goldenDiceText;
    [SerializeField] private TextMeshProUGUI blackDiceText;

    private bool gameFinished = false;

    void Start()
    {
        whitePanel.SetActive(true);
        goldenPanel.SetActive(false);
        blackPanel.SetActive(false);
        finalPanel.SetActive(false);
    }

    void Update()
{
    if (gameFinished)
        return;

    if (whiteHorse.GetComponent<HorseMovement>().GetCurrentIndex() >= whiteHorse.GetComponent<HorseMovement>().GetApplesCount() - 1)
    {
        gameFinished = true;
        whitePanel.SetActive(false);
        whiteWinPanel.SetActive(true);
        return;
    }

    if (goldenHorse.GetComponent<HorseMovement>().GetCurrentIndex() >= goldenHorse.GetComponent<HorseMovement>().GetApplesCount() - 1)
    {
        gameFinished = true;
        whitePanel.SetActive(false);
        goldenWinPanel.SetActive(true);
        return;
    }

    if (blackHorse.GetComponent<HorseMovement>().GetCurrentIndex() >= blackHorse.GetComponent<HorseMovement>().GetApplesCount() - 1)
    {
        gameFinished = true;
        whitePanel.SetActive(false);
        blackWinPanel.SetActive(true);
        return;
    }
}

    public void OnWhitePowerButtonClicked()
    {
        whitePowerButtons.SetActive(false);
        whiteDice.SetActive(true);
    }

    public void OnWhiteDiceClicked()
    {
        whiteDice.SetActive(false);
        whiteNextHud.SetActive(true);
    }

    public void OnWhiteNextButtonClicked()
    {
        whitePanel.SetActive(false);
        goldenPanel.SetActive(true);
        whiteNextHud.SetActive(false);
        whitePowerButtons.SetActive(true);
    }

    public void OnGoldenPowerButtonClicked()
    {
        goldenPowerButtons.SetActive(false);
        goldenDice.SetActive(true);
    }

    public void OnGoldenDiceClicked()
    {
        goldenDice.SetActive(false);
        goldenNextHud.SetActive(true);
    }

    public void OnGoldenNextButtonClicked()
    {
        goldenPanel.SetActive(false);
        blackPanel.SetActive(true);
        goldenNextHud.SetActive(false);
        goldenPowerButtons.SetActive(true);
    }

    public void OnBlackPowerButtonClicked()
    {
        blackPowerButtons.SetActive(false);
        blackDice.SetActive(true);
    }

    public void OnBlackDiceClicked()
    {
        blackDice.SetActive(false);
        blackNextHud.SetActive(true);
    }
    
    public void OnBlackNextButtonClicked()
    {
        blackPanel.SetActive(false);
        finalPanel.SetActive(true);
        blackNextHud.SetActive(false);
        blackPowerButtons.SetActive(true);
    }

    public void OnFinalButtonClicked()
    {
        finalPanel.SetActive(false);
        whitePanel.SetActive(true);
    }

    public void SetWhiteDiceText()
    {
        whiteDiceText.text = whiteDice.GetComponent<RollDice>().GetLastRoll().ToString();
    }

    public void SetGoldenDiceText()
    {
        goldenDiceText.text = goldenDice.GetComponent<RollDice>().GetLastRoll().ToString();
    }

    public void SetBlackDiceText()
    {
        blackDiceText.text = blackDice.GetComponent<RollDice>().GetLastRoll().ToString();
    }
}