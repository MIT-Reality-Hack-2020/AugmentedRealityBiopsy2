using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BiopsyManager : MonoBehaviour
{
    public BiopsyTool biopsyTool;
    
    public BiopsyPath biopsyPath;

    public GameObject biopsyPoint;
    public SurgicalPointEntry entryPoint;

    public bool biopsyCollected;
    
    public AudioSource audioSource;

    public void Update()
    {
        if(!biopsyCollected)
        {
            if(Vector3.Distance(
                biopsyPoint.transform.position,
                biopsyTool.toolTip
            ) < 0.02f)
            {
                PerformBiopsy();
            }
        }
    }
    public void PerformBiopsy()
    {
        biopsyCollected = true;
        audioSource.Play();
    }
}
