using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;
    public TransferFunctionUI transferFunctionUI;
    
    public void Awake()
    {
        instance = this;
    }
}
