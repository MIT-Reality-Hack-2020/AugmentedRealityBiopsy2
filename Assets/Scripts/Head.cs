using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Material materialSkin;
    public Material materialInside;

    public bool skinned;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(skinned)
        {
            GetComponent<MeshRenderer>().material = materialSkin;
        }
        else
        {
            GetComponent<MeshRenderer>().material = materialInside;
        }
    }
}
