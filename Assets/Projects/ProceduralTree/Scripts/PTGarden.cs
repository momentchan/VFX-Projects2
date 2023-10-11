using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProceduralModeling
{
    public class PTGarden : MonoBehaviour
    {
        [SerializeField] private ProceduralTree tree;
        TreeGrowing grow;
        private void Start()
        {
             grow = tree.GetComponent<TreeGrowing>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                tree.Data.randomSeed = Random.Range(0, 300);
                grow.Grow();
                tree.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            }
        }
    }
}

