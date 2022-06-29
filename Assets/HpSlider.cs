using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSlider : SliderPanel
{
    public override void UpdateUI(ActorStats actorStats)
    {
        SetTextOnHover("HP: " + actorStats.GetHp().ToString());
        maxSliderValue = (int)actorStats.GetMaxHp();
        SetSliderValue((int)actorStats.GetHp());
    }
}
