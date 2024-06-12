using mj.gist;
using UnityEngine;

[ExecuteInEditMode]
public class Ripple : MonoBehaviour
{
    
    private Block block;
    private float seed;
    private RippleGenerator generator;  

    private void Awake()
    {
        block = new Block(GetComponent<Renderer>());
        seed = Random.value;
        block.SetFloat("_Seed", seed);
    }

    public void Setup(RippleGenerator generator)
    {
        this.generator = generator;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generator == null) return;

        block.SetFloat("_Width", generator.width.Lerp(seed));
        block.SetColor("_Color", generator.color);

        if (generator.type == RippleType.Wipeout)
        {
            block.SetVector("_Hue", Vector4.zero);
            block.SetVector("_Saturation", Vector4.zero);
            block.SetVector("_Value", Vector4.zero);
        }

        block.Apply();
    }

    public enum RippleType
    {
        Normal, Wipeout
    }
}
