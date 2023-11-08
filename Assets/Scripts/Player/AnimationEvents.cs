using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
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
    }
}
