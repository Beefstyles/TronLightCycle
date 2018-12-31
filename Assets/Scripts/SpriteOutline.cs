using UnityEngine;

public class SpriteOutline : MonoBehaviour {

    public Color color = Color.white;
    private SpriteRenderer sr;

    void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateOutline(true);
    }

    void OnDisable()
    {
        UpdateOutline(false);
    }

    void Update()
    {
        UpdateOutline(true);
    }

    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        sr.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1F : 0);
        mpb.SetColor("_OutlineColor", color);
        sr.SetPropertyBlock(mpb);
    }
}
