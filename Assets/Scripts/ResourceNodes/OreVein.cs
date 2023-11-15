using UnityEngine;

public class OreVein : Interactable
{
    [SerializeField] public OreResource oreResource;

    protected override void Interact()
    {
        PlayerManager.Instance.IsMining = true;
        PlayerManager.Instance.MiningTarget = this;
        PlayerManager.Instance.PlayerAnimator.SetFloat(PlayerManager.Instance.ANIM_MINING_SPEED, PlayerManager.Instance.BaseMiningSpeed);
        PlayerManager.Instance.PlayerAnimator.SetTrigger(PlayerManager.Instance.ANIM_MINING);
        PlayerManager.Instance.UIStatusBar.gameObject.SetActive(true);
    }
}
