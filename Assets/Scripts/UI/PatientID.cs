using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientID : UIObject
{
    public InteractionManager manager;
    public AROverlay overlay;


    public bool outOfTheWay;

    public override void UpdateInterface()
    {
        base.UpdateInterface();
        if (manager.currentPhase == Phase.far)
        {
            enabled = false;
        }
        else if (manager.currentPhase == Phase.identification)
        {
            enabled = true;
            outOfTheWay = false;
        }
        else if (manager.currentPhase == Phase.close)
        {
            enabled = true;
            outOfTheWay = true;
        }
    }

    public void OnEnable()
    {
        Debug.Log("Fade In");
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnDisable()
    {
        Debug.Log("Fade Out");
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // public IEnumerator FadeIn()
    // {

    // }

    // public IEnumerator FadeOut()
    // {

    // }
}
