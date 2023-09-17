using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BuildingVisual : MonoBehaviour
{

#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Building Visual")]
    public static void AddBuildingVisual()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

#endif

    public Building building;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Image artworkImage;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button specialButton;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI nameText;


    private void Start()
    {
        upgradeButton.onClick.AddListener(() => building.Upgrade());
    }

    private void Update()
    {
        progressBar.GetCurrentFill();
    }
}

