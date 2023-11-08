using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputs playerInputs;
    public PlayerInputs.PlayerActions PlayerActions;

    void Awake()
    {
        playerInputs = new PlayerInputs();
        PlayerActions = playerInputs.Player;
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
