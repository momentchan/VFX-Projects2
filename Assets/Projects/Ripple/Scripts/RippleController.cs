using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class RippleController : MonoBehaviour
{
    [SerializeField] private Color backgroundColor;
    [SerializeField] private HDAdditionalCameraData data;
    [SerializeField] private List<VisualEffect> effects;

    void Start()
    {

    }

    void Update()
    {
        data.backgroundColorHDR = backgroundColor;
        foreach (var effect in effects)
        {
            var wipeout = effect.GetBool("Wipeout");
            if (wipeout)
            {
                effect.SetVector4("Color", new Vector4(backgroundColor.r, backgroundColor.g, backgroundColor.b));
            }
        }
    }
}
