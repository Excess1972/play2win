using UnityEngine;

public class CamController : MonoBehaviour
{
	private Camera  _cam;
	private float   _speed = 20;
	private Vector3 touchStart;

	private void Awake()
	{
		_cam = Camera.main;
		// _cam.fieldOfView = 40;
	}

	void Update()
	{
		// float wheelVal = -Input.GetAxis("Mouse ScrollWheel");
		// if (wheelVal != 0f)
		// {
		// 	float fov = Mathf.MoveTowards(
		// 		_cam.fieldOfView,
		// 		60,
		// 		wheelVal * 2000 * Time.deltaTime
		// 	);
		// 	_cam.fieldOfView = Mathf.Clamp(fov, 20, 40);
		// 	return;
		// }

		if (Input.GetMouseButtonDown(0))
		{
			touchStart = GetWorldPosition(0);
		}

		if (Input.GetMouseButton(0))
		{
			Vector3 direction = touchStart - GetWorldPosition(0);
			_cam.transform.position += direction;
		}


		// ich lass das mal drinne ... 
		// brauchen wir evtl. doch noch, wenn es auf mehreren platformen laufen soll und man auf dem pc dann den luxus haben soll das auch über tastatur zu steuern ...
		// var pos = transform.position;
		//
		// // up
		// if (Input.GetKey("w"))
		// {
		// 	pos.z += _speed * Time.deltaTime;
		// }
		//
		// // down
		// if (Input.GetKey("s"))
		// 	pos.z -= _speed * Time.deltaTime;
		//
		// // left
		// if (Input.GetKey("a"))
		// 	pos.x -= _speed * Time.deltaTime;
		//
		// // right
		// if (Input.GetKey("d"))
		// 	pos.x += _speed * Time.deltaTime;
		//
		// pos.x = Mathf.Clamp(pos.x, -40, 40);
		// pos.z = Mathf.Clamp(pos.z, -60, 10);
		//
		// transform.position = pos;
	}

	private Vector3 GetWorldPosition(float z)
	{
		Ray   mousePos = _cam.ScreenPointToRay(Input.mousePosition);
		Plane ground   = new Plane(Vector3.down, new Vector3(0, 0, z));
		float distance;
		ground.Raycast(mousePos, out distance);
		return mousePos.GetPoint(distance);
	}
}