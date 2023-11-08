using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool UseEvents;

    public string PromptMessage {
        get {
            return promptMessage;
        }

        set {
            promptMessage = value;
        }
    }

    public bool IsHighlighted {
        get {
            return isHighlighted;
        }

        set {
            if (value) {
                EnableHighlights();
            } else {
                DisableHighlights();
            }

            isHighlighted = value;
        }
    }

    [SerializeField] private string promptMessage;
    [SerializeField] private GameObject[] highlightedMeshes;
    [SerializeField] private GameObject[] unhighlightedMeshes;

    private bool isHighlighted = false;

    private void EnableHighlights()
    {
        foreach (GameObject mesh in highlightedMeshes) {
            mesh.SetActive(true);
        }

        foreach (GameObject mesh in unhighlightedMeshes) {
            mesh.SetActive(false);
        }
    }

    private void DisableHighlights()
    {
        foreach (GameObject mesh in highlightedMeshes) {
            mesh.SetActive(false);
        }

        foreach (GameObject mesh in unhighlightedMeshes) {
            mesh.SetActive(true);
        }
    }

    public void BaseInteract()
    {
        if (UseEvents) {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }

        Interact();
    }

    protected virtual void Interact() {}
}
