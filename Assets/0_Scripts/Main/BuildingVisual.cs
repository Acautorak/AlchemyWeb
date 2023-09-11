using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingVisual : MonoBehaviour
{
    public Building building;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Image artworkImage;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button specialButton;

    private void Start()
    {
        upgradeButton.onClick.AddListener( () => Debug.LogWarning(building.maximum));
        
    }

    private void Update()
    {
        progressBar.GetCurrentFill();
    }
}

