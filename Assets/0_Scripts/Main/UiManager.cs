using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private RectTransform blackFadePanel, buildingsPanel;

    [SerializeField] private CanvasGroup resourcePanelsCanvasGroup;

    [SerializeField] private Button buildBtn, eventBtn, settingsBtn;

    private float originalAlpha;
    private const float BLACKFADETIME =0.3f;
    

    // 680 is width of the panel winows
    private  Vector2 BUILDINGSOUTOFBOUNDS =new Vector2(-Screen.width - 680, 0f);
    private Vector2 originalBuildingsPanelPosition;

    private void Start()
    {
        buildBtn.onClick.AddListener(() => OnBuildBtnClick());
        originalAlpha = blackFadePanel.GetComponent<Image>().color.a;
        originalBuildingsPanelPosition = buildingsPanel.localPosition;
        buildingsPanel.localPosition = BUILDINGSOUTOFBOUNDS;
        buildingsPanel.gameObject.SetActive(false);
    }

    public void OnBuildBtnClick()
    {
        ToggleBlackFade();
        if(!buildingsPanel.gameObject.activeSelf)
        {
            buildingsPanel.gameObject.SetActive(true);
            //buildingsPanel.transform.localPosition = originalBuildingsPanelPosition; WE DEVIDE BY 3 FOR BETTER ANIMATION EFFECT WHG
            buildingsPanel.LeanMoveLocal(originalBuildingsPanelPosition, BLACKFADETIME/3).setEaseInBounce();
        }
        else
            buildingsPanel.LeanMoveLocal(BUILDINGSOUTOFBOUNDS, BLACKFADETIME).setEaseOutBounce().setOnComplete(() => 
            {
                buildingsPanel.gameObject.SetActive(false);
            });

    }
    private void ToggleBlackFade()
    {
        if (blackFadePanel.gameObject.activeSelf)
        {
            blackFadePanel.LeanAlpha(0, BLACKFADETIME).setOnComplete(() =>
            {
                blackFadePanel.gameObject.SetActive(false);
            });
        }
        else
        {
            blackFadePanel.gameObject.SetActive(true);
            blackFadePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);

            blackFadePanel.LeanAlpha(originalAlpha, BLACKFADETIME);
        }
    }

}
