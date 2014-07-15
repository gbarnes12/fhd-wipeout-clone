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
	public Transform LeftHand;
	public Transform RightHand;
	public float InputMargin;
	public bool RightInArea = false;
	public bool LeftInArea = false;

	public bool GameRunning = true;
	public bool CarReconfigure = false;
	#endregion

	#region Private Members
	private Transform _cachedTransform;
	private float _dir;
	private float _rotateVelocityMult;
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
	void Update () 
	{
		if(GameRunning){
			if(RightInArea && LeftInArea)
			{
				float yDif = LeftHand.position.y - RightHand.position.y;
				if(Mathf.Abs(yDif) > InputMargin) 
				{
					this._dir = ((yDif) > 0.0f) ? 1.0f : -1.0f;
					this._rotateVelocityMult = 1.0f + ((Mathf.Abs(yDif) * 0.1f)) ;
				}else{
					this._dir = 0.0f;
					this._rotateVelocityMult = 0.0f;
				}

			}else
				this._dir = 0.0f;

			this.transform.rotation *= Quaternion.Euler (0, 0, this._dir * this._rotateVelocityMult * RotateVelocity * Time.deltaTime);
		}else{
			if(!GameRunning && !CarReconfigure){
				Speed = -500;
				CarReconfigure = true;
			}else{
				Speed = 0;
			}
		}
	}
	#endregion
}