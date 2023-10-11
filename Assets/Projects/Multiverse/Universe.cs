using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mj.gist;
using UnityEditor;
using UnityEngine;

public class Universe : MonoBehaviour
{
    [SerializeField] AnimationController controller;
    [SerializeField] private int id;

    private Ｍultiverse multiverse;
    public void Setup(Ｍultiverse multiverse, int id)
    {
        this.multiverse = multiverse;
        this.id = id;
        controller.StartPlayRandomCourtine();
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
