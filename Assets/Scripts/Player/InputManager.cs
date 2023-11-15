using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputs playerInputs;
    public PlayerInputs.PlayerActions PlayerActions;

    [SerializeField] private ThirdPersonController pController;
    private bool shouldLerpMiningAnim = false;
    private float miningTimeElapsed = 0f;
    private float amountToLerp = 0f;

    void Awake()
    {
        playerInputs = new PlayerInputs();
        PlayerActions = playerInputs.Player;
        PlayerActions.Fire.started += ctx => OnFireStarted();
        PlayerActions.Fire.canceled += ctx => OnFireEnded();
    }

    private void Update()
    {
        if (PlayerManager.Instance.IsMining && shouldLerpMiningAnim) {
            amountToLerp = Mathf.Lerp(PlayerManager.Instance.BaseMiningSpeed, PlayerManager.Instance.SuccessMiningSpeed, miningTimeElapsed / .75f);
            PlayerManager.Instance.PlayerAnimator.SetFloat(PlayerManager.Instance.ANIM_MINING_SPEED, amountToLerp);
            miningTimeElapsed += Time.deltaTime;
        } else {
            shouldLerpMiningAnim = false;
            miningTimeElapsed = 0f;
            amountToLerp = 0f;
        }
    }

    private void OnFireStarted()
    {
        bool isTargetingVein = PlayerManager.Instance.InteractableTarget != null && PlayerManager.Instance.InteractableTarget.gameObject.tag == "OreVein";

        if (isTargetingVein && !PlayerManager.Instance.IsMining) {
            pController.CanMove = false;
            PlayerManager.Instance.InteractableTarget.BaseInteract();
        }
    }

    private void OnFireEnded()
    {
        PlayerManager.Instance.UIStatusBar.gameObject.SetActive(false);

        if (PlayerManager.Instance.UIStatusBar.DidHitTarget) {
            shouldLerpMiningAnim = true;
        }
    }

    private void OnEnable()
    {
        PlayerActions.Enable();
    }

    private void OnDisable()
    {
        PlayerActions.Disable();
    }
}
