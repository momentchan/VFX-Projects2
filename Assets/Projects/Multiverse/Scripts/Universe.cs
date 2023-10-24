using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mj.gist;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Universe : MonoBehaviour
{
    [SerializeField] AnimationController controller;
    [SerializeField] private Transform head;
    [SerializeField] private RigBuilder builder;
    [SerializeField] private int id;

    private List<MultiAimConstraint> constraints;
    private Ｍultiverse multiverse;
    public void Setup(Ｍultiverse multiverse, int id)
    {
        this.multiverse = multiverse;
        this.id = id;
        controller.StartPlayRandomCourtine();

        constraints = GetComponentsInChildren<MultiAimConstraint>().ToList();
        foreach (var constraint in constraints)
        {
            var objs = constraint.data.sourceObjects;
            objs.Clear();
            var weight = constraint.name.Contains("Head") ? 1 : 0.3f;
            objs.Add(new WeightedTransform(Camera.main.transform, weight));
            constraint.data.sourceObjects = objs;
            builder.Build();
        }
    }

    public void StartInteraction()
    {
        controller.StartInteraction();
    }


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            StartInteraction();
    }

    private void OnDrawGizmos()
    {
        if(constraints != null)
        {
            Gizmos.DrawLine(head.position, Camera.main.transform.position);
        }
    }
}
