using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float range = 15f;

    void Update()
    {
           Vector3  directionToPlayer = (player.transform.position - transform.position).normalized;

           transform.rotation = Quaternion.LookRotation(directionToPlayer);
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, range))
            {
                transform.LookAt(player.transform.position);
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player in range");
                }
            }
        
        Debug.DrawRay(transform.position, directionToPlayer * range, Color.red);
    }
}
