using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace TowerDefense
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }    
            else
            {
                Destroy(gameObject);
            }
        }
        void OnDestroy()
        {
            Instance = null;    
        }
        #endregion

        public Transform[] levels = new Transform[1];
        public int score = 0;
        [Header("UI")]
        public Text scoreText;
        
        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
        public void RemoveScore(int scoreToRemove)
        {
            score -= scoreToRemove;
            scoreText.text = "Score: " + score;
        }
        public int GetScore()
        {
            return score;
        }
    }
}