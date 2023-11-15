using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public UnityEvent OreMined;

    private ThirdPersonController pController;
    [SerializeField] private GameObject statusBar;

    void Start()
    {
        pController = gameObject.GetComponent<ThirdPersonController>();
    }

    public void MiningFinished()
    {
        pController.CanMove = true;
        PlayerManager.Instance.IsMining = false;
        Debug.Log("Mining some " + PlayerManager.Instance.MiningTarget.oreResource.OreType);
    }
}
