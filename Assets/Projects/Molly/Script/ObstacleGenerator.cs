using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Obstacle prefab;
    [SerializeField] private int count = 15;
    
    [SerializeField] private Bounds bounds;
    public readonly int Variations = 12;

    List<Obstacle> obstacles = new List<Obstacle>();

    public Vector2 size = new Vector2(0.5f, 1f);
    public float ObstacleScale = 1;

    [ContextMenu("Generate")]
    void Generate()
    {
        Reset();
        for (var i = 0; i < count; i++)
        {

            var o = Instantiate(prefab, transform);
            o.transform.position = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
                                               Random.Range(bounds.min.y, bounds.max.y),
                                               Random.Range(bounds.min.z, bounds.max.z));
            o.Setup(this);
            obstacles.Add(o);
        }

    }

    private void Reset()
    {
        foreach (var o in obstacles)
            DestroyImmediate(o.gameObject);
        obstacles.Clear();
    }

    void Start()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
