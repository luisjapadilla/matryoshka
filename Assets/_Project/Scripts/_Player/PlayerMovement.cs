using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickOnMovement();
    }

    public void ClickOnMovement()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(myRay, out raycastHit))
            {
                navMeshAgent.SetDestination(raycastHit.point);
            }
        }
    }
}
