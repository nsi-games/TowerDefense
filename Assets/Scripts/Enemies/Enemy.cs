using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        public int value = 10;
        public float maxHealth = 100;
        public Transform target;
        public bool isDead = false;
        [Header("UI")]
        public GameObject healthBarPrefab;
        public Vector2 healthBarOffset = new Vector2(0, 25f);

        private NavMeshAgent agent;
        private float health = 100;
        private Slider healthBarSlider;
        
        void OnDestroy()
        {
            // Adds score
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(value);
            }

            if (healthBarSlider != null)
            {
                Destroy(healthBarSlider.gameObject);
            }
        }
        void Start()
        {
            health = maxHealth;
            agent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if(target != null)
            {
                agent.SetDestination(target.position);
            }
            HealthBarVisibility();
            RepositionHealthBar();
            if (isDead)
            {
                Destroy(gameObject);
            }
        }
        
        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            Vector3 position = cam.WorldToScreenPoint(transform.position);
            return position + (Vector3)healthBarOffset;
        }
        void HealthBarVisibility()
        {
            if (health >= maxHealth)
            {
                healthBarSlider.gameObject.SetActive(false);
            }
            else
            {
                healthBarSlider.gameObject.SetActive(true);
            }
            //Camera cam = Camera.main;
            //Vector3 origin = cam.transform.position;
            //Vector3 directon = transform.position - origin;
            //Ray ray = new Ray(origin, directon);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    Enemy e = hit.collider.GetComponent<Enemy>();
            //    if(e != null && e == this)
            //    {
            //        healthBarSlider.gameObject.SetActive(true);
            //    }
            //}
        }
        void RepositionHealthBar()
        {
            if (healthBarSlider != null)
            {
                healthBarSlider.transform.position = GetHealthBarPos();
            }
        }

        public void DealDamage(float damage)
        {
            health -= damage;
            if (healthBarSlider != null)
            {
                healthBarSlider.value = health / maxHealth;
            }
            if (health <= 0)
            {
                isDead = true;
            }
        }
        public void SpawnHealthBar(Transform parent)
        {
            GameObject clone = Instantiate(healthBarPrefab, 
                                           GetHealthBarPos(), 
                                           Quaternion.identity, 
                                           parent);
            clone.SetActive(false);
            healthBarSlider = clone.GetComponent<Slider>();
        }
    }
}