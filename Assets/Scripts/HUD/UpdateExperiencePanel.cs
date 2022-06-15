using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateExperiencePanel : MonoBehaviour, IUpdateExperienceUI
{
    public GameObject experiencePanelGameObject;
    ExperiencePanel experiencePanel;

    void Awake()
    {
        experiencePanel = experiencePanelGameObject.GetComponent<ExperiencePanel>();
    }

    void IUpdateExperienceUI.UpdateUI(int level, int maxExperience, int experience)
    {
        experiencePanel.SetLevel(level);
        experiencePanel.maxExperience = maxExperience;
        experiencePanel.SetExp(experience);
    }
}
