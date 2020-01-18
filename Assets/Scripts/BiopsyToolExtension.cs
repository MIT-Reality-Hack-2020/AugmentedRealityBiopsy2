using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiopsyToolExtension : MonoBehaviour
{
    public BiopsyTool tool;
    public MeshRenderer meshRenderer;


    public void Update()
    {
        if(tool.manager.ToolInReach())
        {
            meshRenderer.enabled = true;
            
        }
        else
        {
            meshRenderer.enabled = false;
        }

    }
}
