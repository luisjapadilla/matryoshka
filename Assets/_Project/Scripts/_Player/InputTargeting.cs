﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit hit;
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(hit.collider.GetComponent<Targetable>() != null)
                {
                    if(hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.minion)
                    {
                        selectedHero.GetComponent<PlayerCombat>().TargetedEnemy = hit.collider.gameObject;
                    }
                }

                else if (hit.collider.gameObject.GetComponent<Targetable>() == null)
                {
                    selectedHero.GetComponent<PlayerCombat>().TargetedEnemy = null;
                }
            }
        }
    }
}
