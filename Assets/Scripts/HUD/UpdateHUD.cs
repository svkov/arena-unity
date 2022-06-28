using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHUD : MonoBehaviour
{
    public GameObject experiencePanelGameObject;
    public GameObject statsPanel;
    ExperiencePanel experiencePanel;
    HUDStatsPanel hudStatsPanel;
    ActorStats actorStats;

    void Awake()
    {
        experiencePanel = experiencePanelGameObject.GetComponent<ExperiencePanel>();
    }

    void Start()
    {
        hudStatsPanel = statsPanel.GetComponent<HUDStatsPanel>();
        actorStats = GetComponent<ActorStats>();
        actorStats.onChangeStats.AddListener(UpdateUI);
        UpdateUI();
    }

    void UpdateUI()
    {
        experiencePanel.UpdateUI(actorStats);
        hudStatsPanel.UpdateUI(actorStats);
    }
}
