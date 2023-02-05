﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _Angle;
    [SerializeField] float _initialVelocity;
    [SerializeField] LineRenderer _Line;
    [SerializeField] float _Step;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle = _Angle * Mathf.Deg2Rad;
            StopAllCoroutines();
            StartCoroutine(Coroutine_Movement(_initialVelocity, angle));
        }
    }

    private void DrawLine(float v0, float angle, float step)
    {

    }

    IEnumerator Coroutine_Movement(float v0, float angle)
    {
        float t = 0;
        while (t < 100)
        {
            float x = v0 * t * Mathf.Cos(angle);
            float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);
            transform.position = new Vector3(x, y, 0);
            t += Time.deltaTime;

            yield return null;
        }
    }
}
