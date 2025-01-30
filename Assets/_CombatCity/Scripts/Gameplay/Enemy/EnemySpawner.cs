using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform player;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    
    void Update()
    {
        
        
    }
    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(20f);
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position + randomPosition, Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.player = player.gameObject;

        }
        
    }
}
