using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour {
    [SerializeField]
    float MissileSpeed = 1.0f;

    readonly float maximumTravel = 2.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.right * MissileSpeed;
    }

    private void OnDestroy()
    {
        // decrease enemycount
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x > maximumTravel) {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
