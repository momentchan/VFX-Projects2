using System.Collections;
using System.Collections.Generic;
using Lasp;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] private float strength = 10f;
    [SerializeField] private float peak;
    [SerializeField] private float rms;
    [SerializeField] private FilterType filter;
    [SerializeField] private float threshold = 0.5f;

    void Update()
    {
        peak = AudioInput.GetPeakLevelNormalized(filter);
        rms = AudioInput.CalculateRMSNormalized(filter);

        if (Input.GetMouseButtonDown(0) || peak > threshold)
            _rigidbody.AddTorque(Random.insideUnitSphere * strength, ForceMode.Impulse);
    }
}
