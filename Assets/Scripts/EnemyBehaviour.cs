using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField]
    float MovementSpeed = 0.3f;
    [SerializeField]
    float RotationSpeed = 5f;

    readonly float boundary = -2.2f;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = transform.right * -MovementSpeed;
        GetComponent<Rigidbody>().angularVelocity = transform.up * RotationSpeed;
	}

    // Update is called once per frame
    void Update () {
        if (transform.position.x <= boundary) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            transform.GetComponentInParent<EnemyTrackerAndGameOver>().OnGameOver();
        }
        else
        {
            transform.GetComponentInParent<EnemyTrackerAndGameOver>().DecrementEnemies();
        }
    }
}