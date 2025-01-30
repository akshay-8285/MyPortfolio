using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float chaseDistance = 5f;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float rayDistance = 15f;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private Transform gunBarrel;
    private bool isShooting;
    private NavMeshAgent enemyAgent;
    private Animator enemyAnimator;
    void Start()
    {
        muzzleFlash.SetActive(false);
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        bool isPlayerInFront = CheckPlayerInFront();
        transform.LookAt(player.transform.position);
        if(distanceToPlayer <= attackDistance && isPlayerInFront && !isShooting)
        {
                
            enemyAgent.isStopped = true;
            enemyAgent.SetDestination(transform.position);
            enemyAnimator.SetBool("IsRunning", false);
            enemyAnimator.SetBool("IsAttacking", true);
            StartCoroutine(Shoot());
            Debug.Log("attack");
        }
        else if(distanceToPlayer <= chaseDistance && isPlayerInFront)
        {
            
                enemyAgent.isStopped = false;
                enemyAgent.SetDestination(player.transform.position);
                enemyAnimator.SetBool("IsRunning", enemyAgent.velocity.magnitude > 0.1f);
                enemyAnimator.SetBool("IsAttacking", false);
                Debug.Log("chase");
            
            
            
        }
        else
            {
                enemyAgent.isStopped = true;
                enemyAgent.SetDestination(transform.position);
                enemyAnimator.SetBool("IsRunning", false);
                enemyAnimator.SetBool("IsAttacking", false);
                Debug.Log("idle");
            }
        
    }
    public bool CheckPlayerInFront()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
            if(hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
        }
        return false;
    }
    private IEnumerator Shoot()
    {
        if(isShooting)
        yield break;
        while(true)
        {
            yield return new WaitForSeconds(2f);
            muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            muzzleFlash.SetActive(false);

        }
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
