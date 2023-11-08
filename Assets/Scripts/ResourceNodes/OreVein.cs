using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class OreVein : MonoBehaviour
{
    private const string MINING = "Mining";
    private const string MINING_SPEED = "MiningSpeed";

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ThirdPersonController playerController;
    [SerializeField] private StatusBar statusBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerMine()
    {
        // TODO subscribe to an animation event to let the player move when the mining anim finishes
        // and set the statusBar active to false
        playerController.CanMove = false;
        statusBar.gameObject.SetActive(true);
        playerAnimator.SetFloat(MINING_SPEED, 0.5f);
        playerAnimator.SetTrigger(MINING);
    }
}
