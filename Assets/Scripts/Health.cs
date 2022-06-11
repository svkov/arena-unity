using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
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

    public void TakeDamage(float damage)
    {
        hp = Mathf.Clamp(hp - damage, 0, hp);
        UpdateHp();
    }
}
