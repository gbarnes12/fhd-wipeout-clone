using UnityEngine;
using System.Collections;

public class KinectColliderInput : MonoBehaviour {

	#region Public Inspector Members
	public VehicleController VehicleController; 
	public Transform Hand;
	#endregion

	#region Private Members
	private Transform _cachedTransform;
	#endregion

	#region Unity Methods
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		this._cachedTransform = this.transform;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		this._cachedTransform.position = new Vector3(this._cachedTransform.position.x, this._cachedTransform.position.y, Hand.position.z);
	}

	/// <summary>
	/// Raises the trigger stay event.
	/// </summary>
	void OnTriggerStay(Collider other)
	{
		if(other.name.Equals("left_hand"))
			VehicleController.LeftInArea = true;

		if(other.name.Equals("right_hand"))
			VehicleController.RightInArea = true;
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit(Collider other)
	{
		if(other.name.Equals("left_hand"))
			VehicleController.LeftInArea = false;
		
		if(other.name.Equals("right_hand"))
			VehicleController.RightInArea = false;
	}
	#endregion
	                
}
