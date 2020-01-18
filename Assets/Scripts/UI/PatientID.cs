using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientID : MonoBehaviour
{
    public InteractionManager manager;
    public AROverlay overlay;

    public void OnEnable()
    {
        Debug.Log("Fade In");
    }

    public void OnDisable()
    {
        Debug.Log("Fade Out");
    }

    // public IEnumerator FadeIn()
    // {

    // }

    // public IEnumerator FadeOut()
    // {

    // }
}
