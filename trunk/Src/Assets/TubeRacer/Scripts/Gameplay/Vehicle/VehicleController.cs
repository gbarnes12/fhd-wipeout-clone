﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Vehicle controller.
/// </summary>
public class VehicleController : MonoBehaviour 
{
	#region Public Inspector Variables
	public float Speed = 200;
	public int RotateVelocity = 100;	
	public Transform LeftHand;
	public Transform RightHand;
	public float InputMargin;
	public bool RightInArea = false;
	public bool LeftInArea = false;

	public bool GameRunning = true;
	public bool CarReconfigure = false;
	public bool UseKinect = true;
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
			if(UseKinect)
			{
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
			}else{ //Use keyboard input if no kinect is used, for debugging
				this._dir = Input.GetAxis("Horizontal");
				this._rotateVelocityMult = 1.0f;
			}

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


	private int currentFrame = 0;

	void FixedUpdate() {
		if (Speed < 400) {
			currentFrame++;
			if (currentFrame % 96 == 0) {
				Speed++;
				Debug.Log(Speed);
			}
		}
		
	}

	#endregion
}