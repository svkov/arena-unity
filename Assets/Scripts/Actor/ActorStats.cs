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

    public UnityEvent onChangeStats;

    [SerializeField]private float hp = 1;
    [SerializeField]private float maxHp = 1;

    void Awake()
    {
        SetMaxHp();
        if(onChangeStats == null)
            onChangeStats = new UnityEvent();
    }
    void Start()
    {
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

    #region hp
    public float GetHp()
    {
        return hp;
    }

    void UpdateMaxHp()
    {
        maxHp = GetMaxHp();
    }

    void SetMaxHp()
    {
        UpdateMaxHp();
        hp = maxHp;
    }

    public void LoadHealth(float hp)
    {
        if(hp == -1){
            SetMaxHp();
        }
        else
        {
            this.hp = hp;
        }
        onChangeStats.Invoke();
    }

    public void TakeDamage(GameObject owner)
    {
        if (owner.TryGetComponent(out ActorStats stats))
        {
            CalculateDamage(stats);
        }
    }

    void CalculateDamage(ActorStats enemyStats)
    {
        hp = Mathf.Clamp(hp - enemyStats.GetDamage(), 0, hp);
        onChangeStats.Invoke();
        if (hp == 0)
        {
            enemyStats.IncreaseExp(GetComponent<ActorStats>().ExperienceOnDeath());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 3.0f);
        }
    }

    #endregion hp

}
