using UnityEngine;

public class EcholocationController : MonoBehaviour
{
    public Material echolocationMaterial;
    public float radius = 1.0f;
    public float fade = 0.5f;

    private void Update()
    {
        echolocationMaterial.SetVector("_PlayerPos", transform.position);
        echolocationMaterial.SetFloat("_Radius", radius);
        echolocationMaterial.SetFloat("_Fade", fade);
    }
}
