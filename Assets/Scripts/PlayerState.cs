using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    ActorStats actorStats;
    Health health;
    Inventory inventory;
    DrawInventoryToHUD inventoryToHUD;

    [SerializeField] private int defaultSpeed;
    [SerializeField] private int defaultDexterity;
    [SerializeField] private int defaultStrength;
    [SerializeField] private int defaultIntelligence;
    [SerializeField] private int defaultDefense;

    void Start()
    {
        actorStats = GetComponent<ActorStats>();
        health = GetComponent<Health>();
        inventory = GetComponent<Inventory>();
        inventoryToHUD = GetComponent<DrawInventoryToHUD>();
        Invoke(nameof(LoadData), 0.5f);
        InvokeRepeating(nameof(SaveData), 1f, 3f);
    }

    public void SaveData()
    {
        SaveStats();
        SaveHealth();
        SaveInventory();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            LoadData();
        }
    }

    void SaveStats()
    {
        
        PlayerPrefs.SetInt("stats_defense", actorStats.defense);
        PlayerPrefs.SetInt("stats_dexterity", actorStats.dexterity);
        PlayerPrefs.SetInt("stats_strength", actorStats.strength);
        PlayerPrefs.SetInt("stats_speed", actorStats.speed);
        PlayerPrefs.SetInt("stats_intelligence", actorStats.intelligence);
        PlayerPrefs.SetInt("stats_experience", actorStats.experience);
        PlayerPrefs.SetInt("stats_level", actorStats.level);
        PlayerPrefs.SetInt("stats_score", actorStats.GetScore());
    }

    void SaveHealth()
    {
        PlayerPrefs.SetFloat("health", actorStats.GetHp());
    }

    void SaveInventory()
    {
        var itemsInInventory = inventory.inventory.Count;
        for (int i = 0; i < itemsInInventory; i++)
        {
            var item = inventory.inventory[i];
            if(item == null)
                continue;
            int id = item.id;
            PlayerPrefs.SetInt("inventory_" + i.ToString(), id);
        }

        for(int i = itemsInInventory; i < inventory.size; i++)
        {
            PlayerPrefs.DeleteKey("inventory_" + i.ToString());
        }
    }

    void LoadData()
    {
        LoadStats();
        LoadHealth();
        LoadInventory();
    }

    void LoadStats()
    {
        int defense = PlayerPrefs.GetInt("stats_defense", defaultDefense);
        int dexterity = PlayerPrefs.GetInt("stats_dexterity", defaultDexterity);
        int strength = PlayerPrefs.GetInt("stats_strength", defaultStrength);
        int speed = PlayerPrefs.GetInt("stats_speed", defaultSpeed);
        int intelligence = PlayerPrefs.GetInt("stats_intelligence", defaultIntelligence);
        int experience = PlayerPrefs.GetInt("stats_experience", 0);
        int level = PlayerPrefs.GetInt("stats_level", 1);
        int score = PlayerPrefs.GetInt("stats_score", 0);
        actorStats.SetState(level, dexterity, strength, intelligence, defense, speed, experience, score);
    }

    void LoadHealth()
    {
        float hp = PlayerPrefs.GetFloat("health", -1);
        actorStats.LoadHealth(hp);
    }

    void LoadInventory()
    {
        inventory.RemoveAll();
        for (int i = 0; i < inventory.size; i++)
        {
            int item_id = PlayerPrefs.GetInt("inventory_" + i.ToString(), 0);
            inventory.Add(item_id);
        }
        inventoryToHUD.DrawHUD();
    }

    public void NextLevel()
    {
        int level_number = PlayerPrefs.GetInt("level_number", 1);
        level_number++;
        PlayerPrefs.SetInt("level_number", level_number);
    }
}
