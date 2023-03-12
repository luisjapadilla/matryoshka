using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider EnemySlider3D;

    Stats statsScript;
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Stats>();

        EnemySlider3D.maxValue = statsScript.maxHealth;

        statsScript.health = statsScript.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySlider3D.value = statsScript.health;
    }
}
