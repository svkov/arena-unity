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
}
