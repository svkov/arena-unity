using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHUD : MonoBehaviour
{
    public GameObject experiencePanelGameObject;
    public GameObject statsPanel;
    public GameObject hpPanelGameObject;
    ExperiencePanel experiencePanel;
    HpSlider hpSlider;
    HUDStatsPanel hudStatsPanel;
    ActorStats actorStats;

    void Awake()
    {
        experiencePanel = experiencePanelGameObject.GetComponent<ExperiencePanel>();
        hpSlider = hpPanelGameObject.GetComponent<HpSlider>();
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
        hpSlider.UpdateUI(actorStats);
    }
}
