using UnityEngine;
using System.Collections;

public class VehicleController : MonoBehaviour {

	public int rotateVelocity = 100;	

	
	void Update () {
		float dir = Input.GetAxis("Horizontal")*-1;
		transform.rotation *= Quaternion.Euler (0, 0, dir*rotateVelocity*Time.deltaTime);
	}
}