using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Camera PlayerCamera;
    internal float rotateVelocity;

    private PlayerCombat PlayerCombat;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        PlayerCombat = GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        ClickOnMovement();
    }

    public void ClickOnMovement()
    {

        if(PlayerCombat.target != null)
        {
            if(PlayerCombat.target.GetComponent<PlayerCombat>() != null)
            {
                if (PlayerCombat.target.GetComponent<PlayerCombat>().isAlive)
                {
                    PlayerCombat.target = null;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            Ray myRay = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(myRay, out raycastHit))
            {
                navMeshAgent.SetDestination(raycastHit.point);
                PlayerCombat.target = null;
                navMeshAgent.stoppingDistance = 0;
                //try to work some rotation

                Quaternion rotationToLook = Quaternion.LookRotation(raycastHit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(
                    transform.eulerAngles.y,
                    rotationToLook.eulerAngles.y,
                    ref rotateVelocity,
                    5 * (Time.deltaTime * 5));
            }
        }
    }
}
