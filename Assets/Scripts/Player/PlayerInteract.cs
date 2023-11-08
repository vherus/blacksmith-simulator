using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rayDistance = 1f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Material outlineMaterial;
    private PlayerUI playerUI;
    private InputManager inputManager;

    private Interactable previousInteractableTarget;

    public bool IsMining { get => isMining; }
    private bool isMining = false;

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    public void FinishMining()
    {
        isMining = false;
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, layerMask)) {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            if (interactable != null) {
                if (interactable != previousInteractableTarget && previousInteractableTarget != null) {
                    previousInteractableTarget.IsHighlighted = false;
                }

                interactable.IsHighlighted = true;
                previousInteractableTarget = interactable;

                playerUI.UpdateText(interactable.PromptMessage);

                PlayerManager.Instance.InteractableTarget = interactable;

                // if (inputManager.PlayerActions.Interact.triggered) {
                //     interactable.BaseInteract();
                // }
            } else {
                PlayerManager.Instance.InteractableTarget = null;
            }
        } else {
            if (previousInteractableTarget != null) {
                previousInteractableTarget.IsHighlighted = false;
                previousInteractableTarget = null;
            }

            PlayerManager.Instance.InteractableTarget = null;
        }
    }
}
