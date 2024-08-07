using UnityEngine.UI;
using UnityEngine;
using System;

[Serializable]
public class Building
{
    public static EventHandler OnAnyProgressBarComplete;
    public EventHandler OnProgressBarChanged;
    [SerializeField] private string buildingName;
    [SerializeField] private BuildingType buildingType;

    [SerializeField] private float upgradeMultiplier = 1.15f;
    [SerializeField] private float costMultiplier = 1.20f;

    [SerializeField] private int level;
    [SerializeField] private int baseCost;
    [SerializeField] private int costForNextUpgrade;
    [SerializeField] private int baseIncomeValue;
    [SerializeField] private int activeIncomeTick;
    [SerializeField] private int passiveIncomeTick;
    [SerializeField] private Image buildingImage;

    public float gps;


    private const float MAX =1f;
    private float progress=0f;
    private float startTime;
    // danas

    public float timeToCompleteTick = 3f;

    public void Update()
    {
        FillBar();
    }

    public void Upgrade()
    {
        if (GameManager.Instance.gold >= costForNextUpgrade)
        {
            GameManager.Instance.gold -= costForNextUpgrade;
            level += 1;
            costForNextUpgrade = (int)Math.Round(baseCost * Math.Pow(upgradeMultiplier, level));
            activeIncomeTick = (int)Math.Round(baseIncomeValue * Math.Pow(costMultiplier, level));

        }
        else
        {
            Debug.LogWarning("Need more gold = " + (costForNextUpgrade - GameManager.Instance.gold));
        }
    }

    private void FillBar()
    {
        if (level <= 0) return;

        float elapsedTime = Time.time - startTime;
        progress = elapsedTime / timeToCompleteTick;


        if (progress > MAX)
        {
            progress = 0f;
            ResetTimer();

            OnAnyProgressBarComplete?.Invoke(this, EventArgs.Empty);
        }
        Debug.LogWarning(progress);
    }

    private void ResetTimer()
    {
        startTime = Time.time;
    }


    #region GetSet
    public float GetProgress()
    {
        return progress;
    }


    public string GetBuidlingName()
    {
        return buildingName;
    }

    public int GetBuildingLevel()
    {
        return level;
    }

    public BuildingType GetBuildingType()
    {
        return buildingType;
    }

    public int GetBaseCost()
    {
        return baseCost;
    }

    public int GetCostForNextUpgrade()
    {
        return costForNextUpgrade;
    }

    public int GetBaseIncomeValue()
    {
        return baseIncomeValue;
    }

    public int GetActiveIncomeTick()
    {
        return activeIncomeTick;
    }

    public int GetPassiveIncomeTick()
    {
        return passiveIncomeTick;
    }

    public Image GetBuildingImage()
    {
        return buildingImage;
    }
    #endregion

}

public enum BuildingType
{
    tier1,
    tier2,
    tier3,
    tier4,
    tier5,
    tier6,
    tier7,
    tier8,
    tier9,
    tier10,
    tier11,
    tier12,
    tier13

}
