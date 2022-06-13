using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour
{

    public int level = 1;
    public int dexterity = 1;
    public int strength = 1;
    public int intelligence = 1;
    public int defense = 0;

    public int speed = 1;
    public int experienceToLevelUp = 100;

    public int experience = 0;

    IUpdateUI updateUI;

    void Start()
    {
        updateUI = GetComponent<IUpdateUI>();
        UpdateUI();
    }

    public float GetDamage()
    {
        return strength * 3;
    }

    public float GetAttackSpeed()
    {
        return 1.54f * Mathf.Exp(-0.035f * dexterity);
    }

    public float GetMovementSpeed()
    {
        return speed * 5;
    }

    public float GetMaxHp()
    {
        return strength * 25;
    }

    public void LevelUp()
    {
        level++;
        dexterity += Random.Range(0, 3);
        strength += Random.Range(0, 3);
        intelligence += Random.Range(0, 3);
        speed += Random.Range(0, 3);
        defense += Random.Range(0, 3);
    }

    public int ExperienceOnDeath()
    {
        return 10;
    }

    public void IncreaseExp(int newExpirience)
    {
        experience += newExpirience;
        if(experience >= experienceToLevelUp)
        {
            experience -= experienceToLevelUp;
            LevelUp();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if(updateUI != null)
            updateUI.UpdateUI();
    }
}
