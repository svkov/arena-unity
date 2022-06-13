using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateExperiencePanel : MonoBehaviour, IUpdateUI
{
    public GameObject experiencePanelGameObject;
    ExperiencePanel experiencePanel;
    ActorStats actorStats;

    void Start()
    {
        experiencePanel = experiencePanelGameObject.GetComponent<ExperiencePanel>();
        actorStats = GetComponent<ActorStats>();
    }

    void IUpdateUI.UpdateUI()
    {
        experiencePanel.SetLevel(actorStats.level);
        experiencePanel.maxExperience = actorStats.experienceToLevelUp;
        experiencePanel.SetExp(actorStats.experience);
    }
}
