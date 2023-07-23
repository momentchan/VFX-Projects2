using System.Collections;
using System.Collections.Generic;
using mj.gist;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Transform sphere;

    private ObstacleGenerator generator;
    private Block block;
    
    public void Setup(ObstacleGenerator generator)
    {
        this.generator = generator;

        block = new Block(GetComponent<Renderer>());
        id = Random.Range(0, generator.Variations);

        transform.localScale = Vector3.one * generator.size.Lerp(Random.value);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
        sphere.localScale = Vector3.one * generator.ObstacleScale;
        
        block.SetFloat("_TexIndex", id);
        block.Apply();
    }
}
