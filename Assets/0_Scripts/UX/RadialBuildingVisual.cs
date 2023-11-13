using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialBuildingVisual : MonoBehaviour
{
    //morao sam da dodajm ovu klasu jer je stara k
    public Building building;
    [SerializeField] private Image fill;
    private const float  maxRadial = 360;
    private float current = 0;


    void Start()
    {
        building.OnProgressBarChanged+= Building_OnProgressBarChanged;
    }
    void Update()
    {
        UpdateFill();
    }

    private void UpdateFill()
    {
        current = building.GetProgress();
        fill.fillAmount = current;
    }

    private void Building_OnProgressBarChanged(object sender, EventArgs e)
    {
        
    }
}
