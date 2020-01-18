using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Program.instance.interactionManager.overlay.currentStyle != OverlayStyle.skinned)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
