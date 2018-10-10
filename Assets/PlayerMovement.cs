using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float MaxSpeed = 0.01f;
    [SerializeField]
    float TiltRotation = 10.0f;

    readonly float MaximumDisplacement = 0.9f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float movementDirection = Input.GetAxisRaw("Vertical");
        Vector3 newPosition = transform.position + new Vector3(0, 0,  movementDirection * MaxSpeed);
        newPosition.z = (Mathf.Abs(newPosition.z) > MaximumDisplacement) ? MaximumDisplacement * movementDirection : newPosition.z;

        transform.position = newPosition;
        transform.rotation = Quaternion.AngleAxis(movementDirection * TiltRotation, Vector3.right);
    }
}
