using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Info")]
    public string playerName = "Hero";
    public int playerLevel = 1;
    public string playerClass = "Warrior";
    public string race = "Human";           
    public int age = 20;                    

    [Header("Core Stats")]
    public int health = 100;
    public int mana = 50;
    public int stamina = 75;
    public int endurance = 80;              
    public int luck = 5;                     

    [Header("Combat Stats")]
    public int strength = 15;
    public int defense = 10;
    public int intelligence = 12;
    public int agility = 14;
    public int criticalChance = 10;          
    public int attackSpeed = 5;              

    [Header("Progression")]
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public int skillPoints = 0;               
    public int achievements = 0;              

    void Start()
    {
        ShowStats();
    }

    void Update()
    {
        // I-toets toont stats
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowStats();
        }

        // L-toets voegt XP toe
        if (Input.GetKeyDown(KeyCode.L))
        {
            GainExperience(50);
        }

        // R-toets reset alle stats
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetStats();
        }
    }

    public void ShowStats()
    {
        Debug.Log("=== PLAYER STATS ===");
        Debug.Log("Name: " + playerName);
        Debug.Log("Class: " + playerClass + " | Level: " + playerLevel);
        Debug.Log("Race: " + race + " | Age: " + age);
        Debug.Log("Health: " + health + " | Mana: " + mana + " | Stamina: " + stamina);
        Debug.Log("Endurance: " + endurance + " | Luck: " + luck);
        Debug.Log("Strength: " + strength + " | Defense: " + defense + " | Intelligence: " + intelligence + " | Agility: " + agility);
        Debug.Log("Critical Chance: " + criticalChance + " | Attack Speed: " + attackSpeed);
        Debug.Log("Experience: " + experience + "/" + experienceToNextLevel);
        Debug.Log("Skill Points: " + skillPoints + " | Achievements: " + achievements);
        Debug.Log("=====================");
    }

    public void GainExperience(int xp)
    {
        experience += xp;
        Debug.Log(playerName + " gained " + xp + " XP!");

        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        playerLevel++;
        experience -= experienceToNextLevel;
        experienceToNextLevel += 50;

        health += 10;
        mana += 5;
        stamina += 5;
        endurance += 5;
        luck += 1;

        strength += 2;
        defense += 2;
        intelligence += 2;
        agility += 2;
        criticalChance += 1;
        attackSpeed += 1;

        skillPoints += 1;

        Debug.Log(playerName + " leveled up! Now level " + playerLevel);
        ShowStats();
    }

    // RESET FUNCTIE
    void ResetStats()
    {
        // Zet alle variabelen terug naar 0 of lege waarde
        playerName = "Noob";
        playerLevel = 0;
        playerClass = "";
        race = "";
        age = 0;

        health = 0;
        mana = 0;
        stamina = 0;
        endurance = 0;
        luck = 0;

        strength = 0;
        defense = 0;
        intelligence = 0;
        agility = 0;
        criticalChance = 0;
        attackSpeed = 0;

        experience = 0;
        experienceToNextLevel = 0;
        skillPoints = 0;
        achievements = 0;

        Debug.Log("All stats have been reset!");
        ShowStats();
    }
}
