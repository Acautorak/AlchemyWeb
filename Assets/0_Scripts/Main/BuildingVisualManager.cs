using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingVisualManager : MonoSingletone<BuildingVisualManager>
{
    [SerializeField] AlphaTestBuildingsSO alphaTestBuildingsSO;
    public List<Building> buildings;


    private void Start()
    {
        buildings = alphaTestBuildingsSO.GetBuildings();

    }

    void Update()
    {
        foreach (Building b in buildings)
        {
            b.Update();
        }
    }
}
