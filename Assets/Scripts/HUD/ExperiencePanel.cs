using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExperiencePanel : SliderPanel
{

    public override void UpdateUI(ActorStats actorStats)
    {
        SetTextOnHover("LVL: " + actorStats.level.ToString());
        maxSliderValue = actorStats.experienceToLevelUp;
        SetSliderValue(actorStats.experience);
    }

}
