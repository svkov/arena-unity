using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public HpBar hpBar;
    public float maxHp;
    public float hp;

    ActorStats actorStats;
    void Start()
    {
        actorStats = GetComponent<ActorStats>();
        SetMaxHp();

        actorStats.onChangeStats.AddListener(UpdateMaxHp);
    }

    void SetMaxHp()
    {
        UpdateMaxHp();
        hp = maxHp;
    }

    void UpdateMaxHp()
    {
        if (TryGetComponent<ActorStats>(out var actorStats))
        {
            maxHp = actorStats.GetMaxHp();
        }
        hpBar.SetMaxHealth(maxHp);
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
        UpdateHp();
    }

    public void UpdateHp()
    {
        hpBar.SetHealth(hp);
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
        UpdateHp();
        if (hp == 0)
        {
            enemyStats.IncreaseExp(GetComponent<ActorStats>().ExperienceOnDeath());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 3.0f);
        }
    }
}
