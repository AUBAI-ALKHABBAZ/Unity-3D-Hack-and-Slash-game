using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;
    public float power = 10;
    int killScore = 200;
    
    public float currentHealth { get; private set; }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void ChangeHealth(float value)
    {



        //currentHealth += value;
        // use clamp method to check if the health doesn't increace above 100% 
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        Debug.Log("currnet Health" + currentHealth + "/" + maxHealth);
        if (currentHealth <= 0)
        {
            Die();
            
        }
        if (transform.CompareTag("Enemy"))
        {
            transform.Find("GFX").GetComponent<Animator>().SetTrigger("Hit");
            transform.Find("Canvas").GetChild(2).GetComponent<Text>().text = power.ToString();
            transform.Find("Canvas").GetChild(2).GetComponent<Text>().enabled = true;
            transform.Find("Canvas").GetChild(1).GetComponent<Image>().fillAmount = currentHealth / maxHealth;
            transform.Find("Explosion_3_Skull_Red").GetComponent<ParticleSystem>().Play();
            StartCoroutine(HideTextHit());
           

        }
        else if (transform.CompareTag("Player"))
        {
            LevelManager.instance.MainCanvas.Find("PanelStats").Find("ImageHealthBar").GetComponent<Image>().fillAmount = currentHealth / maxHealth;
            LevelManager.instance.MainCanvas.Find("PanelStats").Find("TxtHealth").GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.##}%", (currentHealth / maxHealth) * 100);
            
        }
        IEnumerator HideTextHit()
        {
            yield return new WaitForSeconds(0.5f);
            transform.Find("Canvas").GetChild(2).GetComponent<Text>().enabled = false;
        }
        IEnumerator GolbalDelayNow()
        {
            yield return new WaitForSecondsRealtime(500);
            

        }
        void Die()
        {
            if (transform.CompareTag("Player"))
            {
                // gameover 
                LevelManager.instance.MainCanvas.Find("PanelStats").Find("TxtGameOver").GetComponent<TextMeshProUGUI>().enabled = true;
                Debug.Log("gameOver !");
                transform.Find("GFX").GetComponent<Animator>().SetTrigger("Die");
                
                LevelManager.instance.Player.GetComponent<CharacterMovement>().enabled = false;
                LevelManager.instance.Player.GetComponent<CharacterStats>().enabled = false;
                
                //LevelManager.instance.Enemy.GetComponent<EnemyController>().enabled = false;
                //LevelManager.instance.Enemy.GetComponent<CharacterStats>().enabled = false;
                //LevelManager.instance.Player.GetComponent<Animator>().SetBool("Death",true) ;
                //Debug.Log(transform.Find("GFX").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

            }
            else if (transform.CompareTag("Enemy"))
            {
                LevelManager.instance.Score += killScore;
                LevelManager.instance.MainCanvas.Find("PanelStats").Find("TxtScore").GetComponent<TextMeshProUGUI>().text = string.Format("Score : {0:0.##}", LevelManager.instance.Score);

                transform.Find("GFX").GetComponent<Animator>().SetTrigger("Dead");
                Debug.Log( transform.Find("GFX").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                Destroy(gameObject,1);
                //Destroy Enemy
            }
        }
    }
}
