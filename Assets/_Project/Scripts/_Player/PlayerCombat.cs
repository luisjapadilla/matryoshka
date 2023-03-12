using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject TargetedEnemy;
    // Start is called before the first frame update
    public enum HeroAttackType { Melee, Ranged};
    public HeroAttackType PlayerAttackType;

    public GameObject target;
    public float attackRanged;
    public float rotatespeed;

    private PlayerMovement movement;
    private Stats statsScript;

    public bool basicIdle = false;
    public bool isAlive;
    public bool performMeleeAttack = true;
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        statsScript = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) > attackRanged)
            {
                movement.navMeshAgent.SetDestination(target.transform.position);
                movement.navMeshAgent.stoppingDistance = attackRanged;
            }
            else
            {
                if(PlayerAttackType == HeroAttackType.Melee)
                {
                    if (performMeleeAttack)
                    {
                        Debug.Log("attack the enemy");
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }
        }
    }
    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;

        yield return new WaitForSeconds(statsScript.attackTime / ((100 + statsScript.attackTime) * 0.01f));

        if(target == null)
        {
            performMeleeAttack = true;
        }
    }

    public void MeleeAttack()
    {
        if(target != null)
        {
            if(target.GetComponent<Targetable>().enemyType == Targetable.EnemyType.minion)
            {
                target.GetComponent<Stats>().health -= statsScript.AttackDmg;
            }
        }
        performMeleeAttack = true;
    }
}
