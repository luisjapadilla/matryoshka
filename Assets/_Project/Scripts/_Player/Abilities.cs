using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    [Header("first ability")]
    public Image abilityImage;
    public float cooldown = 5;
    bool isCooldown = false;
    public KeyCode ability;

    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillshot;
    public Transform player;



    void Start()
    {
        abilityImage.fillAmount = 0;

        skillshot.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);
    }

    void Ability1()
    {
        if(Input.GetKey(ability) && isCooldown == false)
        {
            skillshot.GetComponent<Image>().enabled = true;
        }
        if(skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButton(0))
        {
            isCooldown = true;
            abilityImage.fillAmount = 1;
        }
        if (isCooldown)
        {
            abilityImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;
            if(abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
