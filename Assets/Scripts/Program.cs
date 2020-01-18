using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    public static Program instance;
    public ImportManager importManager;
    public BiopsyManager biopsyManager;
    public TransferFunctionManager transferFunctionManager;
    public VolumeRenderedObject volumeRenderedObject;

    public void Awake()
    {
        instance = this;
    }
}
