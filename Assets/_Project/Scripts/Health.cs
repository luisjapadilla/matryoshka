using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider PlayerSlider3D;
    Slider playerSlider2D;

    Stats statsScript;
    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        playerSlider2D = GetComponent<Slider>();

        PlayerSlider3D.maxValue = statsScript.maxHealth;
        playerSlider2D.maxValue = statsScript.maxHealth;

        statsScript.health = statsScript.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerSlider2D.value = statsScript.health;
        PlayerSlider3D.value = playerSlider2D.value;
    }
}
