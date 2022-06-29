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
        actorStats.onChangeStats.AddListener(UpdateUI);
    }

    void UpdateMaxHp()
    {
        hpBar.SetMaxHealth(actorStats.GetMaxHp());
    }

    void UpdateHp()
    {
        hpBar.SetHealth(actorStats.GetHp());
    }

    void UpdateUI()
    {
        UpdateMaxHp();
        UpdateHp();
    }
}
