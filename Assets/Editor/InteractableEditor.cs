using UnityEditor;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable) target;

        if (target.GetType() == typeof(EventOnlyInteractable)) {
            interactable.PromptMessage = EditorGUILayout.TextField("Prompt Message", interactable.PromptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteractable can only use Unity Events.", MessageType.Info);

            if (interactable.GetComponent<InteractionEvent>() == null) {
                interactable.UseEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        } else {
            base.OnInspectorGUI();

            if (interactable.UseEvents) {
                if (interactable.GetComponent<InteractionEvent>() == null) {
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            } else {
                if (interactable.GetComponent<InteractionEvent>() != null) {
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
