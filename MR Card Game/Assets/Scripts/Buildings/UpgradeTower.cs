using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeTower : MonoBehaviour
{
    // The instance of this script
    public static UpgradeTower instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //--------------------------------------------------------------------------------------
    // Upgrading towers
    //--------------------------------------------------------------------------------------
    
    // Define the updrage tower menu
    [SerializeField]
    private GameObject upgradeTowerMenu;

    // The method used to access to the upgrade tower menu as a static object
    public static GameObject getUpgradeTowerMenu
    {
        get { return instance.upgradeTowerMenu; }
    }

    // Define all the text fields of the build tower menu
    [SerializeField]
    private TMP_Text towerTypeField;

    // The method used to access to the tower type field as a static object
    public static TMP_Text getTowerTypeField
    {
        get { return instance.towerTypeField; }
    }

    [SerializeField]
    private TMP_Text towerDamageField;

    // The method used to access to the tower damage field as a static object
    public static TMP_Text getTowerDamageField
    {
        get { return instance.towerDamageField; }
    }

    [SerializeField]
    private TMP_Text towerAttackCooldownField;

    // The method used to access to the tower attack cooldown field as a static object
    public static TMP_Text getTowerAttackCooldownField
    {
        get { return instance.towerAttackCooldownField; }
    }

    [SerializeField]
    private TMP_Text towerRangeField;

    // The method used to access to the tower range field as a static object
    public static TMP_Text getTowerRangeField
    {
        get { return instance.towerRangeField; }
    }

    [SerializeField]
    private TMP_Text additionalField1;

    // The method used to access to the additional field 1 as a static object
    public static TMP_Text getAdditionalField1
    {
        get { return instance.additionalField1; }
    }

    [SerializeField]
    private TMP_Text additionalField2;

    // The method used to access to the additional field 2 as a static object
    public static TMP_Text getAdditionalField2
    {
        get { return instance.additionalField2; }
    }

    [SerializeField]
    private TMP_Text upgradeCostField;

    // The method used to access to the upgrade cost field as a static object
    public static TMP_Text getUpgradeCostField
    {
        get { return instance.upgradeCostField; }
    }

    // The upgrade tower button
    [SerializeField]
    private Button upgradeTowerButton;

    // The method used to access to the upgrade tower button as a static object
    public static Button getUpgradeTowerButton
    {
        get { return instance.upgradeTowerButton; }
    }

    // The level up multiplicators
    private static float lightningDamageEnhancer = 1.1f;
    private static float lightningJumpRangeEnhancer = 1.4f;
    private static float earthDamageEnhancer = 1.6f;
    private static float earthSizeEnhancer = 1.2f;
    private static float windAttackCooldownEnhancer = 0.9f;
    private static float windDropBackEnhancer = 1.2f;
    private static float arrowDamageEnhancer = 1.2f;
    private static float arrowAttackCooldownEnhancer = 0.85f;
    private static float arrowRangeEnhancer = 1.1f;
    private static float fireDamageEnhancer = 1.4f;
    private static float fireAttackCooldownEnhancer = 0.85f;

    // The basic cost for tower upgrade
    private static float archerTowerUpgradeBaseCost = 70f;
    private static float fireTowerUpgradeBaseCost = 90f;
    private static float earthTowerUpgradeBaseCost = 120f;
    private static float lightningTowerUpgradeBaseCost = 105f;
    private static float windTowerUpgradeBaseCost = 65f;

    // The upgrade cost multiplicator for upgrading towers
    private static float archerTowerUpgradeCostMultiplicator = 1.5f;
    private static float fireTowerUpgradeCostMultiplicator = 1.7f;
    private static float earthTowerUpgradeCostMultiplicator = 2f;
    private static float lightningTowerUpgradeCostMultiplicator = 1.85f;
    private static float windTowerUpgradeCostMultiplicator = 1.4f;


    // Method used to open the upgrade menu
    public static void OpenUpgradeTowerMenu(Tower tower)
    {
        // Save the tower that opened the upgrade menu
        TowerEnhancer.currentlyEnhancedTower = tower;

        // Pause the game
        GameAdvancement.gamePaused = true;

        // Set the upgrade tower menu as active
        getUpgradeTowerMenu.SetActive(true);

        // Write the right tower type as heading
        getTowerTypeField.text = tower.getTowerType;

        // Initialize the upgrade cost integer
        int upgradeCost = 0;

        // Check the tower type and fill the stats window accordingly
        switch(tower.getTowerType)
        {
            case "Lightning Tower":
                // Enable the two additional fields for the lightning tower
                getAdditionalField1.gameObject.SetActive(true);
                getAdditionalField2.gameObject.SetActive(true);

                // Actualize the standard fields
                getTowerDamageField.text = "Damage " + (tower.getDamage * Mathf.Pow(lightningDamageEnhancer, tower.getLevel)) + " > " + (tower.getDamage * Mathf.Pow(lightningDamageEnhancer, tower.getLevel));
                getTowerAttackCooldownField.text = "Attack cooldown " + tower.getAttackCooldown;
                getTowerRangeField.text = "Range " + tower.getAttackRange;

                // Fill the aditional fields
                getAdditionalField1.text = "Number of jumps: " + (tower.getNumberOfEffect + (1 * (tower.getLevel - 1))) + " > " + (tower.getNumberOfEffect + (1 * tower.getLevel));
                getAdditionalField2.text = "Jump range: " + (tower.getEffectRange * Mathf.Pow(lightningJumpRangeEnhancer, tower.getLevel)) + " > " + (tower.getEffectRange * Mathf.Pow(lightningJumpRangeEnhancer, tower.getLevel));
                
                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(lightningTowerUpgradeBaseCost * Mathf.Pow(lightningTowerUpgradeCostMultiplicator, tower.getLevel - 1));

                // Write this cost in the upgrade cost field
                getUpgradeCostField.text = "Upgrade cost: " + upgradeCost;

                // Disable or enable the upgrade button depending on if the player has enough currency for it
                if(GameAdvancement.currencyPoints >= upgradeCost)
                {
                    // Can upgrade, so enable the button
                    getUpgradeTowerButton.gameObject.SetActive(true);
                    
                } else {
                    
                    // Cannot upgrade, so disable the button
                    getUpgradeTowerButton.gameObject.SetActive(false);
                }
            
            break;

            case "Earth Tower":
                // Enable one of the additional fields for the earth tower
                getAdditionalField1.gameObject.SetActive(true);
                getAdditionalField2.gameObject.SetActive(false);

                // Actualize the standard fields
                getTowerDamageField.text = "Damage " + (tower.getDamage * Mathf.Pow(earthDamageEnhancer, tower.getLevel)) + " > " + (tower.getDamage * Mathf.Pow(earthDamageEnhancer, tower.getLevel + 1));
                getTowerAttackCooldownField.text = "Attack cooldown " + tower.getAttackCooldown;
                getTowerRangeField.text = "Range " + tower.getAttackRange;

                // Fill the aditional field
                getAdditionalField1.text = "Projectile size: " + (tower.getEffectRange * Mathf.Pow(earthSizeEnhancer, tower.getLevel - 1)) + " > " + (tower.getEffectRange * Mathf.Pow(earthSizeEnhancer, tower.getLevel + 1));
            
                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(earthTowerUpgradeBaseCost * Mathf.Pow(earthTowerUpgradeCostMultiplicator, tower.getLevel - 1));

                // Write this cost in the upgrade cost field
                getUpgradeCostField.text = "Upgrade cost: " + upgradeCost;

                // Disable or enable the upgrade button depending on if the player has enough currency for it
                if(GameAdvancement.currencyPoints >= upgradeCost)
                {
                    // Can upgrade, so enable the button
                    getUpgradeTowerButton.gameObject.SetActive(true);
                    
                } else {
                    
                    // Cannot upgrade, so disable the button
                    getUpgradeTowerButton.gameObject.SetActive(false);
                }
            
            break;

            case "Wind Tower":
                // Enable one of the additional fields for the wind tower
                getAdditionalField1.gameObject.SetActive(true);
                getAdditionalField2.gameObject.SetActive(false);

                // Actualize the standard fields
                getTowerAttackCooldownField.text = "Attack cooldown " + (tower.getAttackCooldown * Mathf.Pow(windAttackCooldownEnhancer, tower.getLevel)) + " > " + (tower.getAttackCooldown * Mathf.Pow(windAttackCooldownEnhancer, tower.getLevel + 1));
                getTowerDamageField.text = "Damage " + tower.getDamage;
                getTowerRangeField.text = "Range " + tower.getAttackRange;

                // Fill the aditional fields
                getAdditionalField1.text = "Drop back distance: " + (tower.getEffectRange * Mathf.Pow(windDropBackEnhancer, tower.getLevel)) + " > " + (tower.getEffectRange * Mathf.Pow(windDropBackEnhancer, tower.getLevel + 1));
                
                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(windTowerUpgradeBaseCost * Mathf.Pow(windTowerUpgradeCostMultiplicator, tower.getLevel - 1));

                // Write this cost in the upgrade cost field
                getUpgradeCostField.text = "Upgrade cost: " + upgradeCost;

                // Disable or enable the upgrade button depending on if the player has enough currency for it
                if(GameAdvancement.currencyPoints >= upgradeCost)
                {
                    // Can upgrade, so enable the button
                    getUpgradeTowerButton.gameObject.SetActive(true);
                    
                } else {
                    
                    // Cannot upgrade, so disable the button
                    getUpgradeTowerButton.gameObject.SetActive(false);
                }
            
            break;

            case "Archer Tower":
                // Disable the two additinal fields for the archer tower
                getAdditionalField1.gameObject.SetActive(false);
                getAdditionalField2.gameObject.SetActive(false);

                // Actualize all standard fields
                getTowerDamageField.text = "Damage " + (tower.getDamage * Mathf.Pow(arrowDamageEnhancer, tower.getLevel)) + " > " + (tower.getDamage * Mathf.Pow(arrowDamageEnhancer, tower.getLevel + 1));
                getTowerAttackCooldownField.text = "Attack cooldown " + (tower.getAttackCooldown * Mathf.Pow(arrowAttackCooldownEnhancer, tower.getLevel - 1)) + " > " + (tower.getAttackCooldown * Mathf.Pow(arrowAttackCooldownEnhancer, tower.getLevel + 1));
                getTowerRangeField.text = "Range " + (tower.getAttackRange * Mathf.Pow(arrowRangeEnhancer, tower.getLevel)) + " > " + (tower.getAttackRange * Mathf.Pow(arrowRangeEnhancer, tower.getLevel + 1));
            
                Debug.Log("The damage on level 1 is multiplied with: " + (Mathf.Pow(arrowDamageEnhancer, tower.getLevel)));

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(archerTowerUpgradeBaseCost * Mathf.Pow(archerTowerUpgradeCostMultiplicator, tower.getLevel - 1));

                // Write this cost in the upgrade cost field
                getUpgradeCostField.text = "Upgrade cost: " + upgradeCost;

                // Disable or enable the upgrade button depending on if the player has enough currency for it
                if(GameAdvancement.currencyPoints >= upgradeCost)
                {
                    // Can upgrade, so enable the button
                    getUpgradeTowerButton.gameObject.SetActive(true);
                    
                } else {
                    
                    // Cannot upgrade, so disable the button
                    getUpgradeTowerButton.gameObject.SetActive(false);
                }

            break;

            case "Fire Tower":
                // Disable the two additinal fields for the fire tower
                getAdditionalField1.gameObject.SetActive(false);
                getAdditionalField2.gameObject.SetActive(false);

                // Actualize all standard fields
                getTowerDamageField.text = "Damage " + (tower.getDamage * Mathf.Pow(fireDamageEnhancer, tower.getLevel)) + " > " + (tower.getDamage * Mathf.Pow(fireDamageEnhancer, tower.getLevel + 1));
                getTowerAttackCooldownField.text = "Attack cooldown " + (tower.getAttackCooldown * Mathf.Pow(fireAttackCooldownEnhancer, tower.getLevel - 1)) + " > " + (tower.getAttackCooldown * Mathf.Pow(fireAttackCooldownEnhancer, tower.getLevel + 1));
                getTowerRangeField.text = "Range " + tower.getAttackRange;

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(fireTowerUpgradeBaseCost * Mathf.Pow(fireTowerUpgradeCostMultiplicator, tower.getLevel - 1));

                // Write this cost in the upgrade cost field
                getUpgradeCostField.text = "Upgrade cost: " + upgradeCost;

                // Disable or enable the upgrade button depending on if the player has enough currency for it
                if(GameAdvancement.currencyPoints >= upgradeCost)
                {
                    // Can upgrade, so enable the button
                    getUpgradeTowerButton.gameObject.SetActive(true);
                    
                } else {
                    
                    // Cannot upgrade, so disable the button
                    getUpgradeTowerButton.gameObject.SetActive(false);
                }

            break;
        }
    }

    // Method used to close the upgrade tower menu
    public void CloseUpgradeTowerMenu()
    {
        // Set the upgrade tower menu as inactive
        getUpgradeTowerMenu.SetActive(false);

        // Unpause the game
        GameAdvancement.gamePaused = false;
    }

    // Method used to upgrade a tower
    public void UpgradeTowerMethod()
    {
        // Initialize the upgrade cost integer
        int upgradeCost = 0;

        // Check what is written in the tower type field and call the right upgrade function
        switch(getTowerTypeField.text)
        {
            case "Archer Tower":

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(archerTowerUpgradeBaseCost * Mathf.Pow(archerTowerUpgradeCostMultiplicator, TowerEnhancer.currentlyEnhancedTower.getLevel - 1));

                Debug.Log("The upgrade cost is: " + upgradeCost);

                // Remove the upgrade cost from the currency points of the player
                GameAdvancement.currencyPoints = GameAdvancement.currencyPoints - upgradeCost;

                // Actualize the currency display
                GameSetup.ActualizeCurrencyDisplay();

                // Upgrade the tower
                TowerEnhancer.currentlyEnhancedTower.UpgradeArcherTower(arrowDamageEnhancer, arrowAttackCooldownEnhancer, arrowRangeEnhancer);

            break;

            case "Fire Tower":

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(fireTowerUpgradeBaseCost * Mathf.Pow(fireTowerUpgradeCostMultiplicator, TowerEnhancer.currentlyEnhancedTower.getLevel - 1));

                // Remove the upgrade cost from the currency points of the player
                GameAdvancement.currencyPoints = GameAdvancement.currencyPoints - upgradeCost;

                // Actualize the currency display
                GameSetup.ActualizeCurrencyDisplay();

                // Upgrade the tower
                TowerEnhancer.currentlyEnhancedTower.UpgradeFireTower(fireDamageEnhancer, fireAttackCooldownEnhancer);

            break;

            case "Earth Tower":

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(earthTowerUpgradeBaseCost * Mathf.Pow(earthTowerUpgradeCostMultiplicator, TowerEnhancer.currentlyEnhancedTower.getLevel - 1));

                // Remove the upgrade cost from the currency points of the player
                GameAdvancement.currencyPoints = GameAdvancement.currencyPoints - upgradeCost;

                // Actualize the currency display
                GameSetup.ActualizeCurrencyDisplay();

                // Upgrade the tower
                TowerEnhancer.currentlyEnhancedTower.UpgradeEarthTower(earthDamageEnhancer, earthSizeEnhancer);

            break;

            case "Lightning Tower":

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(lightningTowerUpgradeBaseCost * Mathf.Pow(lightningTowerUpgradeCostMultiplicator, TowerEnhancer.currentlyEnhancedTower.getLevel - 1));

                // Remove the upgrade cost from the currency points of the player
                GameAdvancement.currencyPoints = GameAdvancement.currencyPoints - upgradeCost;

                // Actualize the currency display
                GameSetup.ActualizeCurrencyDisplay();

                // Upgrade the tower
                TowerEnhancer.currentlyEnhancedTower.UpgradeLightningTower(lightningDamageEnhancer, lightningJumpRangeEnhancer);

            break;

            case "Wind Tower":

                // Calculate the cost of upgrading this tower
                upgradeCost = (int)(windTowerUpgradeBaseCost * Mathf.Pow(windTowerUpgradeCostMultiplicator, TowerEnhancer.currentlyEnhancedTower.getLevel - 1));

                // Remove the upgrade cost from the currency points of the player
                GameAdvancement.currencyPoints = GameAdvancement.currencyPoints - upgradeCost;

                // Actualize the currency display
                GameSetup.ActualizeCurrencyDisplay();

                // Upgrade the tower
                TowerEnhancer.currentlyEnhancedTower.UpgradeWindTower(windAttackCooldownEnhancer, windDropBackEnhancer);

            break;
        }

        // Set the upgrade tower menu as inactive
        getUpgradeTowerMenu.SetActive(false);

        // Unpause the game
        GameAdvancement.gamePaused = false;
    }
}
