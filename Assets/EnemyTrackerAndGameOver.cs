using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrackerAndGameOver : MonoBehaviour {
    [SerializeField]
    Text EnemiesRemaining;
    [SerializeField]
    int numEnemies = 27;
    [SerializeField]
    Text GameOverText;
    [SerializeField]
    Image GameOverImg;

    // Use this for initialization
    void Start () {
        GameOverImg.gameObject.SetActive(false);
	}

    void Update() {
        EnemiesRemaining.text = "Enemies Remaining: " + numEnemies;
        if (numEnemies <= 0) {
            OnGameOver();
        }
    }

    public void DecrementEnemies() {
        --numEnemies;
    }

    public void OnGameOver() {
        GameOverImg.gameObject.SetActive(true);
        GameOverText.text = "Game Over\nEnemies left: " + numEnemies;
        Destroy(gameObject);
    }
}