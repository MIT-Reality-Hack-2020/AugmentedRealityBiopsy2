using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public AROverlay overlay;
    public Material materialSkin;
    public Material materialInside;


    // Update is called once per frame
    void Update()
    {
        if(Program.instance.interactionManager.currentPhase == Phase.far)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            if(overlay.currentStyle == OverlayStyle.skinned)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().material = materialSkin;

            }
            else if(overlay.currentStyle == OverlayStyle.mri)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else if(overlay.currentStyle == OverlayStyle.mesh)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().material = materialInside;
            }
        }

    }
}
