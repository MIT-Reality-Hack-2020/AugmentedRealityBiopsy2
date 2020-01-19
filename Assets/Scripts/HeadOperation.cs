using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadOperation : Head
{

    void Update()
    {
        if (Program.instance.interactionManager.currentPhase == Phase.far)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            if (overlay.currentStyle == OperationOverlayStyle.skinned)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().material = materialSkin;

            }
            else if (overlay.currentStyle == OperationOverlayStyle.mri)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else if (overlay.currentStyle == OperationOverlayStyle.mesh)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().material = materialInside;
            }
        }
    }
}
