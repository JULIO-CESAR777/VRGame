using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    [SerializeField] private int healthPoints = 100;
    private Animator animator;

    private NavMeshAgent navAgent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        //enemyZombie = GetComponent<CapsuleCollider>();
       
    }

    public void TakeDamage(int DamageAmount)
    {
        healthPoints -= DamageAmount;

        if (healthPoints <= 0)
        {
            Invoke("DestruirEnemy", 4.0f);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //navAgent.enabled = false;
            navAgent.acceleration = 0;

            int randomValue = Random.Range(0, 2);
            if(randomValue==0)
            {
                animator.SetTrigger("DIE1");
                
               
            }
            else
            {
                animator.SetTrigger("DIE2");
                
            }
               

        }
        else
        {
            animator.SetTrigger("DAMAGE");

        }
    }

    private void DestruirEnemy()
    {
        Destroy(gameObject);
      
    }
}




