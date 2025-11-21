using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Horses")]
    [SerializeField] private GameObject blueHorse;
    [SerializeField] private GameObject greenHorse;
    [SerializeField] private GameObject yellowHorse;

    [Header("Panels")]
    [SerializeField] private GameObject bluePanel;
    [SerializeField] private GameObject greenPanel;
    [SerializeField] private GameObject yellowPanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject blueWinPanel;
    [SerializeField] private GameObject greenWinPanel;
    [SerializeField] private GameObject yellowWinPanel;

    [Header("Power Buttons")]
    [SerializeField] private GameObject bluePowerButtons;
    [SerializeField] private GameObject greenPowerButtons;
    [SerializeField] private GameObject yellowPowerButtons;

    [Header("Dices")]
    [SerializeField] private GameObject blueDice;
    [SerializeField] private GameObject greenDice;
    [SerializeField] private GameObject yellowDice;

    [Header("NextHuds")]
    [SerializeField] private GameObject blueNextHud;
    [SerializeField] private GameObject greenNextHud;
    [SerializeField] private GameObject yellowNextHud;

    [Header("Dice Texts")]
    [SerializeField] private TextMeshProUGUI blueDiceText;
    [SerializeField] private TextMeshProUGUI greenDiceText;
    [SerializeField] private TextMeshProUGUI yellowDiceText;

    void Start()
    {
        bluePanel.SetActive(true);
        greenPanel.SetActive(false);
        yellowPanel.SetActive(false);
        finalPanel.SetActive(false);
    }

    void Update()
    {
        if (blueHorse.GetComponent<HorseMovement>().GetCurrentIndex() >= blueHorse.GetComponent<HorseMovement>().GetApplesCount() - 1)
        {
            bluePanel.SetActive(false);
            blueWinPanel.SetActive(true);
        }

        if (greenHorse.GetComponent<HorseMovement>().GetCurrentIndex() >= greenHorse.GetComponent<HorseMovement>().GetApplesCount() - 1)
        {
            bluePanel.SetActive(false);
            greenWinPanel.SetActive(true);
        }

        if (yellowHorse.GetComponent<HorseMovement>().GetCurrentIndex() >= yellowHorse.GetComponent<HorseMovement>().GetApplesCount() - 1)
        {
            bluePanel.SetActive(false);
            yellowWinPanel.SetActive(true);
        }
    }

    public void OnBluePowerButtonClicked()
    {
        bluePowerButtons.SetActive(false);
        blueDice.SetActive(true);
    }

    public void OnBlueDiceClicked()
    {
        blueDice.SetActive(false);
        blueNextHud.SetActive(true);
    }

    public void OnBlueNextButtonClicked()
    {
        bluePanel.SetActive(false);
        greenPanel.SetActive(true);
        blueNextHud.SetActive(false);
        bluePowerButtons.SetActive(true);
    }

    public void OnGreenPowerButtonClicked()
    {
        greenPowerButtons.SetActive(false);
        greenDice.SetActive(true);
    }

    public void OnGreenDiceClicked()
    {
        greenDice.SetActive(false);
        greenNextHud.SetActive(true);
    }

    public void OnGreenNextButtonClicked()
    {
        greenPanel.SetActive(false);
        yellowPanel.SetActive(true);
        greenNextHud.SetActive(false);
        greenPowerButtons.SetActive(true);
    }

    public void OnYellowPowerButtonClicked()
    {
        yellowPowerButtons.SetActive(false);
        yellowDice.SetActive(true);
    }

    public void OnYellowDiceClicked()
    {
        yellowDice.SetActive(false);
        yellowNextHud.SetActive(true);
    }
    
    public void OnYellowNextButtonClicked()
    {
        yellowPanel.SetActive(false);
        finalPanel.SetActive(true);
        yellowNextHud.SetActive(false);
        yellowPowerButtons.SetActive(true);
    }

    public void OnFinalButtonClicked()
    {
        finalPanel.SetActive(false);
        bluePanel.SetActive(true);
    }

    public void SetBlueDiceText()
    {
        blueDiceText.text = blueDice.GetComponent<RollDice>().GetLastRoll().ToString();
    }

    public void SetGreenDiceText()
    {
        greenDiceText.text = greenDice.GetComponent<RollDice>().GetLastRoll().ToString();
    }

    public void SetYellowDiceText()
    {
        yellowDiceText.text = yellowDice.GetComponent<RollDice>().GetLastRoll().ToString();
    }
}