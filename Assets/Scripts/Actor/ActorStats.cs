using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    IUpdateExperienceUI updateUI;

    public UnityEvent onChangeStats;

    void Start()
    {
        if(onChangeStats == null)
            onChangeStats = new UnityEvent();
        updateUI = GetComponent<IUpdateExperienceUI>();
        onChangeStats.Invoke();
    }

    void OnValidate()
    {
        onChangeStats.Invoke();
    }

    public void SetState(int level, int dexterity, int strength, int intelligence, int defense, int speed, int experience)
    {
        this.level = level;
        this.dexterity = dexterity;
        this.strength = strength;
        this.intelligence = intelligence;
        this.defense = defense;
        this.speed = speed;
        this.experience = experience;
        onChangeStats.Invoke();
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
        onChangeStats.Invoke();
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
        onChangeStats.Invoke();
    }

}
