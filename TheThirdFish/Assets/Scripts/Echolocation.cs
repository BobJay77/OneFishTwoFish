using UnityEngine;

public class Echolocation : MonoBehaviour
{
    public float revealSpeed = 0.1f;
    private float revealAmount = 0f;

    public Material invisibleMaterial;
    public Material visibleMaterial;

    private Renderer[] objectsToReveal;

    void Start()
    {
        objectsToReveal = FindObjectsOfType<Renderer>();

        foreach (Renderer rend in objectsToReveal)
        {
            rend.material = invisibleMaterial;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartReveal();
        }

        if (revealAmount < 1f)
        {
            revealAmount = Mathf.Min(revealAmount + Time.deltaTime * revealSpeed, 1f);

            foreach (Renderer rend in objectsToReveal)
            {
                if (rend.gameObject == this.gameObject)
                {
                    continue;
                }

                Material mat = new Material(Shader.Find("Custom/Reveal"));
                mat.SetFloat("_RevealAmount", revealAmount);
                rend.material = mat;
            }
        }
    }

    private void StartReveal()
    {
        revealAmount = 0f;
    }
}
