using UnityEngine;
using System.Collections;

public class VehicleExplosion : MonoBehaviour {

	#region Public Inspector Members
	public float ExplosionForce;
	public float ExplosionRadius;
	public float UpwardsModifier;
	#endregion

	#region Private Members
	private Rigidbody[] _fragments;
	#endregion

	#region Unity Methods
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Awake () 
	{
		_fragments = this.transform.GetComponentsInChildren<Rigidbody>();
	}
	#endregion

	#region Public Methods
	/// <summary>
	/// Explode the specified direction.
	/// </summary>
	/// <param name="direction">Direction.</param>
	public void Explode(float direction)
	{
		float xDirection = direction;
		int[] xDirections = {-5, 5};
		//explode fragments
		if(direction == 0)
		{
			int rand = Random.Range(0, 2);
			xDirection = xDirections[rand];
		}else
			xDirection = (direction < 0) ? xDirections[0] : xDirections[1];


		foreach(Rigidbody fragment in _fragments)
		{
			fragment.AddExplosionForce(this.ExplosionForce, new Vector3(this.transform.position.x + xDirection, 
			                                                            this.transform.position.y - 5, 
			                                                            this.transform.position.z - 5),
			                           this.ExplosionRadius, this.UpwardsModifier, ForceMode.Impulse);
			fragment.AddForce(new Vector3(xDirection, -1, -1), ForceMode.Impulse);
		}
	}
	#endregion

}
