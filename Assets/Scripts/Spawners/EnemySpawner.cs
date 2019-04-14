using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnDelay = 1f;
        public Transform path;
        [Header("UI")]
        public Transform healthBarParent;

        private Transform start, end;
        
        void Start()
        {
            start = path.Find("Start");
            end = path.Find("End");
            StartCoroutine(SpawnEnemy());
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(spawnDelay);

            GameObject clone = Instantiate(prefab, start.position, start.rotation, transform);

            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.target = end;
            enemy.SpawnHealthBar(healthBarParent);

            StartCoroutine(SpawnEnemy());
        }
    }
}