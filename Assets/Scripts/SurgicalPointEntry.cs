using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgicalPointEntry : SurgicalPoint
{
    public void Update()
    {
        if(manager.ToolInReach())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
             GetComponent<MeshRenderer>().enabled = true;
        }

    }

   
}
