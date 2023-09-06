using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class ProgressBar : MonoBehaviour
{
    //LOL
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

#endif

    //private BaseBuilding baseBuilding;
    public int minimum = 0;
    public float maximum = 1;
    public float current = 0.05f;
    public bool isIdle = true;
    public Color color;
    [SerializeField] private Image mask;
    [SerializeField] private Image fill;


    void Start()
    {
      //  baseBuilding.OnBarProgressChanged += BaseBuilding_OnBarProgressChanged;
    }

    void Update()
    {
        if (!isIdle)
        GetCurrentFill();

        //current = baseBuilding.GetProgress();
        mask.fillAmount = current;
        current += 0.05f * Time.deltaTime;
        GetCurrentFill();
    }

    private void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = (float)currentOffset / (float)maximumOffset;
        if (fillAmount > 1) current = 0;
        mask.fillAmount = fillAmount;

        //fill.color = color;
    }

   // public void SetBaseBuilding(BaseBuilding baseBuildingLocal)
   // {
    //    baseBuilding = baseBuildingLocal;
   // }

    private void BaseBuilding_OnBarProgressChanged(object sender, EventArgs e)
    {
        //current = baseBuilding.GetProgress();
        mask.fillAmount = current;
    }
}
