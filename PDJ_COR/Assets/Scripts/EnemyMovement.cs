using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;

    private float attackCooldown = 2f, attackTimer;
    public Animator anim;

    public CapsuleCollider capsuleCollider;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
    }

    void Update(){
        attackTimer = attackTimer + 1f * Time.deltaTime;
        attackTimer = Mathf.Clamp(attackTimer, 0f, attackCooldown);

        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= agent.stoppingDistance){
            anim.SetTrigger("idle");
        }else{
            anim.SetTrigger("walk");
        }

        if(distance <= agent.stoppingDistance && attackTimer >= attackCooldown){
            attackTimer = 0f;
            anim.SetTrigger("attack");
            agent.SetDestination(transform.position);
        }else{
            agent.SetDestination(player.position);
        }
        
    }

    public void DisableCollider(){
        capsuleCollider.enabled = false;
    }

    public void EnableCollider(){
        capsuleCollider.enabled = true;
    }
}
