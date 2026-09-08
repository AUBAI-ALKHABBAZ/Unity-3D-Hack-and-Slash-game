using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    CharacterStats stats;

    //public Transform Player;
    NavMeshAgent agent;
    Animator anim;
    Animation anim_animation;
    public float attackRaduis = 8;

    bool canAttack = true;
    float attackCooldown = 5f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        // get disttance between player and enemy 
        float distance = Vector3.Distance(transform.position, LevelManager.instance.Player.position);
        if (distance < attackRaduis)
        {
            agent.SetDestination(LevelManager.instance.Player.position);
            if (distance <= agent.stoppingDistance)
            {
                if (canAttack)
                {
                    StartCoroutine(cooldown());
                    // play attack animation 
                    anim.SetTrigger("Attack");
                }
            }
        }
 
        
        
    }
    IEnumerator cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 
            Debug.Log("player contacted");
        //Destroy(gameObject);
        // changeHealth of enemy based on power of player |other.GetComponentInParent<CharacterStats>().power| 
        //becuase collider object is within the player script we can get Component script in this way
        // minus  for decreace 
        stats.ChangeHealth( - other.GetComponentInParent<CharacterStats>().power);
        
        }
    }
    public void DamagePlayer()
    {
        LevelManager.instance.Player.GetComponent<CharacterStats>().ChangeHealth(-stats.power);
        
    }
    
}
