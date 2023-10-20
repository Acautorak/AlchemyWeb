using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AlphaTestBuildingsSO", menuName = "Test")]
public class AlphaTestBuildingsSO : ScriptableObject
{
    [SerializeField] List<Building> buildings;
    // ok

    public List<Building> GetBuildings()
    {
        return buildings;
    }
}
