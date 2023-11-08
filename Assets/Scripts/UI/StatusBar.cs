using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    private float timeElapsed = 0f;
    [SerializeField] private float lerpDuration = 1.2f;
    private float amount = 0f;
    private float amountToLerp = 0f;
    private float maxAmount = 1f;
    private float minTargetPosX;
    public float maxTargetPosX; // divide the current position of the indicator by the max to get between 0 and 1, indicatorPos / maxTargetPosX
    private bool isInitialised = false;
    public bool DidHitTarget = false;

    public Image frontBar;
    public RectTransform targetRect;
    [SerializeField] private RectTransform targetCollider;

    void OnEnable()
    {
        ResetValues();

        if (!isInitialised) {
            Vector3[] worldCorners = new Vector3[4];
            frontBar.rectTransform.GetWorldCorners(worldCorners);
            minTargetPosX = worldCorners[0].x + 100;
            maxTargetPosX = worldCorners[2].x - 60;
            isInitialised = true;
        }
        
        float randPos = Random.Range(minTargetPosX, maxTargetPosX);
        targetRect.transform.position = new Vector3(randPos, targetRect.transform.position.y, targetRect.transform.position.z);
    }

    private void ResetValues()
    {
        amount = 0f;
        frontBar.fillAmount = amount;
        timeElapsed = 0f;
        amountToLerp = 0f;
        DidHitTarget = false;
    }

    void Update()
    {
        if (timeElapsed < lerpDuration) {
            amountToLerp = Mathf.Lerp(amount, maxAmount, timeElapsed / lerpDuration);
            frontBar.fillAmount = amountToLerp;
            timeElapsed += Time.deltaTime;
            float width = frontBar.rectTransform.rect.width;
            Vector3 tempV = targetCollider.anchoredPosition;
            tempV.x = -width/2;
            tempV.x += width * frontBar.fillAmount;
            targetCollider.anchoredPosition = tempV;

            DidHitTarget = targetCollider.anchoredPosition.x > targetRect.anchoredPosition.x - 30 && targetCollider.anchoredPosition.x < targetRect.anchoredPosition.x + 30;
        }

        if (frontBar.fillAmount > 0.95) {
            gameObject.SetActive(false);
        }
    }
}
