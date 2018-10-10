using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float MaxSpeed = 0.01f;
    [SerializeField]
    float TiltRotation = 10.0f;
    [SerializeField]
    float FireDelay = 0.4f;

    float fireNext = 0.0f;

    [SerializeField]
    GameObject MissilePrefab;
    [SerializeField]
    Transform MissileSpawnTransform;

    readonly float MaximumDisplacement = 0.9f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
        if (Input.GetKey(KeyCode.Space)) {
            if (fireNext >= FireDelay) {
                fireNext = 0;
                Instantiate(MissilePrefab, MissileSpawnTransform.position, MissileSpawnTransform.rotation);
            }
            else
            {
                fireNext += Time.deltaTime;
            }
        }
    }

    private void UpdateMovement() {
        float movementDirection = Input.GetAxisRaw("Vertical");

        Vector3 newPosition = transform.position + new Vector3(0, 0, movementDirection * MaxSpeed);
        newPosition.z = (Mathf.Abs(newPosition.z) > MaximumDisplacement) ? MaximumDisplacement * movementDirection : newPosition.z; // Clamp the displacement of the ship.

        transform.position = newPosition;
        transform.rotation = Quaternion.AngleAxis(movementDirection * TiltRotation, Vector3.right);
    }
}
