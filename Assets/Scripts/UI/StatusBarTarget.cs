using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarTarget : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision!");
    }
}
