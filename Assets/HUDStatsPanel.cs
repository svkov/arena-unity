using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDStatsPanel : MonoBehaviour
{
    public Text strength;
    public Text dexterity;
    public Text defense;
    public Text speed;
    public Text intelligence;

    public void UpdateUI(ActorStats actorStats)
    {
        strength.text = "STR: " + actorStats.strength.ToString();
        dexterity.text = "DEX: " + actorStats.dexterity.ToString();
        defense.text = "DEF: " + actorStats.defense.ToString();
        speed.text = "SPD: " + actorStats.speed.ToString();
        intelligence.text = "INT: " + actorStats.intelligence.ToString();
    }
}
