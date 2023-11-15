using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public string ANIM_MINING { get; private set; } = "Mining";
    public string ANIM_MINING_SPEED { get; private set; } = "MiningSpeed";

    [Header("Programmatic Components (Don't manually set)")]
    public Interactable InteractableTarget;
    public bool IsMining = false;
    public OreVein MiningTarget;

    [Header("Serialized Components")]
    [SerializeField] public Animator PlayerAnimator;
    [SerializeField] public StatusBar UIStatusBar;
    [SerializeField] public float BaseMiningSpeed = 0.5f;
    [SerializeField] public float SuccessMiningSpeed = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
