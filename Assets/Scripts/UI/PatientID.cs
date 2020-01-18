using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientID : UIObject
{
    public InteractionManager manager;
    public AROverlay overlay;


    public override void UpdateInterface()
    {
        if (manager.DistanceFromCamera(overlay.transform.position) > 0.7f)
        {
            enabled = false;
        }
        else
        {
            enabled = true;
        }
    }

    public void OnEnable()
    {
        Debug.Log("Fade In");
        // foreach(Transform child in transform.GetChildren)
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
