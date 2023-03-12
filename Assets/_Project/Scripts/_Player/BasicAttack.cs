using System;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttack : MonoBehaviour
{
    Animator anim;
    RaycastHit hit;
    PlayerMovement movement;

    [Header("Basic Attack")]

    public Image pointerImg;
    public float cooldown = 10;
    bool isCooldown = false;
    public KeyCode ability;
    bool CanSkillShot = true;
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    [Header("Ability Input")]
    Vector3 position;
    public Canvas AbilityCanvas;
    public Image skillshot;
    public Transform player;
    void Start()
    {
        pointerImg.fillAmount = 0;
        skillshot.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SkillShotAbility();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);

        transRot.eulerAngles = new Vector3(0, transRot.eulerAngles.y, transRot.eulerAngles.z);

        AbilityCanvas.transform.rotation = Quaternion.Lerp(transRot, AbilityCanvas.transform.rotation, 0f);
    }

    private void SkillShotAbility()
    {
        if(Input.GetKeyDown(ability) && isCooldown == false)
        {
            skillshot.GetComponent<Image>().enabled = false;
        }

        if(skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            Quaternion rotationToLookat = Quaternion.LookRotation(position - transform.position);
            float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookat.eulerAngles.y, ref movement.rotateVelocity, 0);

            transform.eulerAngles = new Vector3(0, rotationY, 0);
        }
    }
}
