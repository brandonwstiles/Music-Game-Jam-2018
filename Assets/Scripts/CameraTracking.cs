using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

    public Vector3 cameraOffset;
    public Transform player;
    public float zOffset = -1;

	void Start ()
    {
        cameraOffset.x = player.transform.position.x;
        cameraOffset.z = zOffset;
        this.transform.position = cameraOffset;
	}
	
	void LateUpdate ()
    {
        cameraOffset.x = player.transform.position.x;
        cameraOffset.z = zOffset;
        this.transform.position = cameraOffset;
    }
}
