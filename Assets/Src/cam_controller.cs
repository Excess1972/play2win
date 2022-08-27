using UnityEngine;

public class cam_controller : MonoBehaviour
{
	private Camera _cam;
	private float  _speed = 20;

	private void Awake()
	{
		_cam = Camera.main;
		_cam.fieldOfView = 40;
	}

	void Update()
	{
		float wheelVal = -Input.GetAxis("Mouse ScrollWheel");
		if (wheelVal != 0f)
		{
			float fov = Mathf.MoveTowards(
				_cam.fieldOfView,
				60,
				wheelVal * 2000 * Time.deltaTime
			);
 			_cam.fieldOfView = Mathf.Clamp(fov, 20, 40);
			return;
		}

		var pos = transform.position;

		// up
		if (Input.GetKey("w"))
		{
			pos.z += _speed * Time.deltaTime;
		}

		// down
		if (Input.GetKey("s"))
			pos.z -= _speed * Time.deltaTime;

		// left
		if (Input.GetKey("a"))
			pos.x -= _speed * Time.deltaTime;

		// right
		if (Input.GetKey("d"))
			pos.x += _speed * Time.deltaTime;
		
		pos.x = Mathf.Clamp(pos.x, -40, 40);
		pos.z = Mathf.Clamp(pos.z, -60, 10);

		transform.position = pos;
	}
}