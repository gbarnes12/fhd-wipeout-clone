using UnityEngine;
using System.Collections;

public class LaserAddCollider : MonoBehaviour {

	CapsuleCollider caps;

	Vector3 start = new Vector3(-20, 20, 0);
	Vector3 end = new Vector3(20,-20,0);

	// Use this for initialization
	void Start () {
		caps = GetComponent<CapsuleCollider>();

		caps.radius = 0.5f;
		caps.transform.localPosition = start + (end-start) / 2;
		//caps.transform.LookAt(start);
		caps.height = (end - start).magnitude;
		caps.transform.localEulerAngles = new Vector3 (0,0,45);
	}

}
