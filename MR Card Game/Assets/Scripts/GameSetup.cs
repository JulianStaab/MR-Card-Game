using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// The class of the castle game object
static class GameAdvancement
{
    // The maximum and current health point of the castle
    public static int castleMaxHP;
    public static int castlecurrentHP;

    // The current armor points of the castle
    public static int castleCurrentAP;

    // The amount of currency the player has right now
    public static int currencyPoints;

    // The current wave
    public static int currentWave;

    // The currency display button for the player
    public static Button currencyDisplay;

    // The health bar slider of the castle
    public static Slider castleHealthBar;
    
    // The health counter C / M displayed on the health bar
    public static TMP_Text castleHealthCounter;

    // The status of the game, if it should be paused or not
    public static bool gamePaused = false;
}

// The class of the castle game object
static class Buildings
{
    // The number of buildings buit in this round
    public static int numberOfBuildings;

    // The array that binds the image target to the building
    public static GameObject[] imageTargetToBuilding;

    // Define the first building
    public static GameObject firstBuilding;

    // Define the second building
    public static GameObject secondBuilding;
    
    // Define the third building
    public static GameObject thirdBuilding;
    
    // Define the fourth building
    public static GameObject fourthBuilding;
    
    // Define the fifth building
    public static GameObject fifthBuilding;
    
    // Define the sixth building
    public static GameObject sixthBuilding;
    
    // Define the seventh building
    public static GameObject seventhBuilding;
    
    // Define the eighth building
    public static GameObject eighthBuilding;
    
    // Define the ninth building
    public static GameObject ninthBuilding;
    
    // Define the tenth building
    public static GameObject tenthBuilding;
}
   
public class GameSetup : MonoBehaviour
{
    // The health points the castle has. Can be changed in the inspector.
    [SerializeField]
    private int castleHP;

    // The currency the player should have at the beginning. Can be changed in the inspector.
    [SerializeField]
    private int beginingCurrency;

    // The button, not interactable, on which the current wave is displayed
    [SerializeField]
    private Button waveDisplay;

    // The button, not interactable, on which the current currency is displayed
    [SerializeField]
    private Button currencyDisplay;

    // The health bar slider of the castle
    [SerializeField]
    private Slider castleHealthBar;

    // The health bar slider of the castle
    [SerializeField]
    private TMP_Text castleHealthCounter;

    // Start is called before the first frame update
    void Start()
    {
        // Set the number of buildings built in this round to zero
        Buildings.numberOfBuildings = 0;

        // Initialize the array of image targets
        Buildings.imageTargetToBuilding = new GameObject[10];

        // Set the castle max and current hp to the hp given in the inspector
        GameAdvancement.castleMaxHP = castleHP;
        GameAdvancement.castlecurrentHP = castleHP;

        // Set the currency points to the amount the player should have in the begining
        GameAdvancement.currencyPoints = beginingCurrency;

        // Set the wave counter to wave 1
        GameAdvancement.currentWave = 1;

        // Set the currency display button
        GameAdvancement.currencyDisplay = currencyDisplay;

        // Set the castle health bar slider
        GameAdvancement.castleHealthBar = castleHealthBar;

        // Set the castle health counter
        GameAdvancement.castleHealthCounter = castleHealthCounter;

        // Set the text of the wave button to wave 1
        waveDisplay.GetComponentInChildren<TMP_Text>().text = "Wave: 1";

        // Set the text of the wave button to wave 1
        ActualizeCurrencyDisplay(currencyDisplay);

        ActualizeCastleHealthPoints(castleHealthBar, castleHealthCounter, castleHP, castleHP);
    }

    // Update is called once per frame
    void Update()
    {
        // Display currency points
    }

    // Method used to actualize the current currency display of the player
    public static void ActualizeCurrencyDisplay(Button currencyDisplay)
    {
        // Actualize the currency currently owned
        currencyDisplay.GetComponentInChildren<TMP_Text>().text = "Currency: " + GameAdvancement.currencyPoints;
    }

    // Method used to actualize the current health points of the castle
    public static void ActualizeCastleHealthPoints(Slider castleHBar, TMP_Text counter, int currentHP, int maxHP)
    {
        // Actualize the value of the castle health bar
        castleHBar.value = (float)currentHP / (float)maxHP;

        Debug.Log("The castle health bar value is currently: " + castleHBar.value);

        // Change the text field that displayed current HP / max HP
        counter.text = currentHP + " / " + maxHP;
    }
}
