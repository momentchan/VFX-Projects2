using System.Collections.Generic;
using UnityEngine;
using static Ripple;

public class RippleGenerator : MonoBehaviour
{
    [SerializeField] public RippleType type;
    [SerializeField] private Ripple prefab;
    [SerializeField] private int count = 10;
    public Vector2 size = Vector2.one;
    public Vector2 width = Vector2.one;
    public Color color = Color.black;


    [SerializeField] private List<Ripple> ripples = new List<Ripple>();

    private void Awake()
    {
        Generate();
    }

    [ContextMenu("Generate")]
    void Generate()
    {
        foreach (var ripple in ripples)
        {
            DestroyImmediate(ripple.gameObject);
        }
        ripples.Clear();


        for (var i = 0; i < count; i++)
        {
            var ripple = Instantiate(prefab, transform);
            ripple.transform.localScale = Vector3.one * size.GetRandom();
            ripples.Add(ripple);
            ripple.Setup(this);
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
