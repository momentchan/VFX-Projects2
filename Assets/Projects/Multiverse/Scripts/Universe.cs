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
    [SerializeField] private RigBuilder builder;
    [SerializeField] private MultiAimConstraint constraint;

    [SerializeField] private int id;

    private Ｍultiverse multiverse;
    public void Setup(Ｍultiverse multiverse, int id)
    {
        this.multiverse = multiverse;
        this.id = id;
        controller.StartPlayRandomCourtine();

        var objs = constraint.data.sourceObjects;
        objs.Clear();
        objs.Add(new WeightedTransform(Camera.main.transform, 1));
        constraint.data.sourceObjects = objs;
        builder.Build();
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
}
