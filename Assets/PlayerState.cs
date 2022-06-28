using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    ActorStats actorStats;
    Health health;
    Inventory inventory;
    DrawInventoryToHUD inventoryToHUD;

    void Start()
    {
        actorStats = GetComponent<ActorStats>();
        health = GetComponent<Health>();
        inventory = GetComponent<Inventory>();
        inventoryToHUD = GetComponent<DrawInventoryToHUD>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            SaveData();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            LoadData();
        }
    }

    void SaveData()
    {
        
        SaveStats();
        SaveHealth();
        SaveInventory();
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
    }

    void SaveHealth()
    {
        PlayerPrefs.SetFloat("health", health.hp);
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
        int defense = PlayerPrefs.GetInt("stats_defense");
        int dexterity = PlayerPrefs.GetInt("stats_dexterity");
        int strength = PlayerPrefs.GetInt("stats_strength");
        int speed = PlayerPrefs.GetInt("stats_speed");
        int intelligence = PlayerPrefs.GetInt("stats_intelligence");
        int experience = PlayerPrefs.GetInt("stats_experience");
        int level = PlayerPrefs.GetInt("stats_level");
        actorStats.SetState(level, dexterity, strength, intelligence, defense, speed, experience);
    }

    void LoadHealth()
    {
        float hp = PlayerPrefs.GetFloat("health");
        health.hp = hp;
        health.UpdateHp();
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

    void DeleteData()
    {
        //TODO: Delete irrelevant data
    }
}
