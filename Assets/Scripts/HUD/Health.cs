using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HpBar hpBar;
    public float maxHp;
    public float hp;
    void Start()
    {
        if (TryGetComponent<ActorStats>(out var actorStats))
        {
            maxHp = actorStats.GetMaxHp();
        }
        hpBar.SetMaxHealth(maxHp);
        hp = maxHp;
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
            Destroy(gameObject, 0);
        }
    }
}
