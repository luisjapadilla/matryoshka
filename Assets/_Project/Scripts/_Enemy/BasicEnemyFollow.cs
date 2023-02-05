using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemyMvm;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyMvm.SetDestination(Player.position);
    }
}
