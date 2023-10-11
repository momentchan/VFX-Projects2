using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ｍultiverse : MonoBehaviour
{
    [SerializeField] private Universe universe;
    [SerializeField] private Vector3 dimension = Vector3.one;
    [SerializeField] private Vector3 distance = Vector3.one;

    private List<Universe> universes = new List<Universe>();
    public int Count => (int)(dimension.x * dimension.y * dimension.z);

    private void Start()
    {
        for (var i = 0; i < dimension.x; i++)
            for (var j = 0; j < dimension.y; j++)
                for (var k = 0; k < dimension.z; k++)
                {
                    var id = (int)(k + j * dimension.z + i * dimension.x * dimension.y);
                    var u = Instantiate(universe, transform);
                    u.transform.localPosition = Vector3.Scale(new Vector3(i, j, k) - dimension * 0.5f, distance);
                    u.Setup(this, id);
                    universes.Add(u);
                }
    }

    void Update()
    {

    }
}
