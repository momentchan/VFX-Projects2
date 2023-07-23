using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravitationalNBodySimulation {
    public class CameraMotion : MonoBehaviour {

        [SerializeField] protected Transform target;
        [SerializeField] protected float radius = 40f;
        [SerializeField] protected float speed = 1f;

        void Update() {

            transform.position = new Vector3(radius * Mathf.Cos(Time.time * speed),
                                             radius * Mathf.Sin(Time.time * speed * 0.5f), 
                                             radius * Mathf.Sin(Time.time * speed));

            if(target != null)
                transform.LookAt(target);
        }
    }
}