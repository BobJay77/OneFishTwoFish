using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ReplacementShaderEffect : MonoBehaviour
{
    public Shader ReplacementShader;
    public Color OverDrawColor;
    public float FadeFactor = 0.01f;
    public float _waveSpeed = 5;
    public float _waveFrequency = 10;
    public bool reset = false;
    public Transform player;

    void OnValidate()
    {
        Shader.SetGlobalColor("_OverDrawColor", OverDrawColor);
        Shader.SetGlobalFloat("_FadeFactor", FadeFactor);
        Shader.SetGlobalFloat("_WaveSpeed", _waveSpeed);
        Shader.SetGlobalFloat("_WaveFrequency", _waveFrequency);

    }

    private void Update()
    {
        Vector4 sourcePosition = new Vector4(player.position.x, player.position.y, 0, 0);
        Shader.SetGlobalVector("_PlayerPos", sourcePosition);
    }

    void OnEnable()
    {
        if (ReplacementShader != null)
            GetComponent<Camera>().SetReplacementShader(ReplacementShader, "");
    }

    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }
}