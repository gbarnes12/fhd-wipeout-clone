using UnityEngine;
using System.Collections;

/// <summary>
/// Vehicle controller.
/// </summary>
public class VehicleController : MonoBehaviour 
{
	#region Public Inspector Variables
	public int RotateVelocity = 100;	
	public Transform LeftHand;
	public Transform RightHand;
	public float Speed = 200;
	public float InputMargin;
	public bool RightInArea = false;
	public bool LeftInArea = false;
	
	public bool CarReconfigure = false;
	public bool UseKinect = true;

	public ParticleSystem LeftThruster;
	public ParticleSystem RightThruster;
	#endregion
	
	#region Private Members
	private Transform _cachedTransform;
	private float _dir;
	private float _rotateVelocityMult;
	private int _currentFrame = 0;
	#endregion

	#region Public Members
	public float MoveDirection
	{
		get { return this._dir; }
	}
	#endregion

	#region Unity Methods
	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		if(UseKinect)
			GameObject.FindGameObjectWithTag("Kinect").SetActive(true);
		else
			GameObject.FindGameObjectWithTag("Kinect").SetActive(false);
	}

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
		if(Gameplay.World.WorldSpawnManager.Instance.GameRunning){
			if(UseKinect)
			{
				if(RightInArea && LeftInArea)
				{
					float yDif = LeftHand.position.y - RightHand.position.y;
					if(Mathf.Abs(yDif) > InputMargin) 
					{
						this._dir = ((yDif) > 0.0f) ? -1.0f : 1.0f;
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
			if(!Gameplay.World.WorldSpawnManager.Instance.GameRunning && !CarReconfigure){
				Speed = -500;
				CarReconfigure = true;
			}else{
				Speed = 0;
			}
		}
		
	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate() {
		if(Gameplay.World.WorldSpawnManager.Instance.GameRunning)
		{
			if (Speed < 400) {
				_currentFrame++;
				if (_currentFrame % 24 == 0)
					Speed++;
			}
		}
	}

	#endregion
}