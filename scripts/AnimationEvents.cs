using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public CharacterMovement charMove;
    public void playerAttack()
    {

        Debug.Log("Player Attacked !");
        charMove.DoAttack();

    }
    public void Apply_partical_swort()
    {
        transform.Find("Explosion Slash").GetComponent<ParticleSystem>().Play();
    }
    public void PlayerDamage()
    {
        transform.GetComponentInParent<EnemyController>().DamagePlayer();
    }
}
