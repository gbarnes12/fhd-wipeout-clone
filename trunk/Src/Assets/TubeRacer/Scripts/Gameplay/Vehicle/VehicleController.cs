using UnityEngine;
using System.Collections;

/// <summary>
/// Vehicle controller.
/// </summary>
public class VehicleController : MonoBehaviour 
{
	#region Public Inspector Variables
	public float Speed = 400;
	public int RotateVelocity = 100;	
	#endregion

	#region Unity Methods
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		float dir = Input.GetAxis("Horizontal");
		transform.rotation *= Quaternion.Euler (0, 0, dir * RotateVelocity * Time.deltaTime);
	}
	#endregion
}