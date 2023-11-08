using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string prompt)
    {
        promptText.text = prompt;
    }
}
