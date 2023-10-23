using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallJump : MonoBehaviour
{
    [SerializeField] float jumpHeight = 15f; // Adjust the jump height as needed.
    [SerializeField] float jumpDuration = 1f; // Adjust the jump duration as needed.
    [SerializeField] LeanTweenType easeType = LeanTweenType.easeOutQuad;

    private Vector3 originalScale;
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;

        // Start the animation loop.
        StartJumpAnimationLoop();

    }

    void StartJumpAnimationLoop()
    {
        // Jump up and increase scale.
        LeanTween.moveLocalY(rectTransform.gameObject, rectTransform.anchoredPosition.y + jumpHeight, jumpDuration)
            .setEase(easeType);

        LeanTween.scale(rectTransform, originalScale * 1.5f, jumpDuration)
            .setEase(easeType)
            .setOnComplete(() =>
            {
                // Go down and decrease scale.
                LeanTween.moveLocalY(rectTransform.gameObject, rectTransform.anchoredPosition.y - jumpHeight, jumpDuration)
                    .setEase(easeType);

                LeanTween.scale(rectTransform, originalScale, jumpDuration)
                    .setEase(easeType)
                    .setOnComplete(() =>
                    {
                        // Restart the animation loop.
                        StartJumpAnimationLoop();
                    });
            });
    }
}
