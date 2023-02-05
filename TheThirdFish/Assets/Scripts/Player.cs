using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ReplacementShaderEffect shaderEffect;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            shaderEffect.enabled = true;
        }
        else
        {
            shaderEffect.enabled = false;
            shaderEffect.reset = true;
        }
    }
}
