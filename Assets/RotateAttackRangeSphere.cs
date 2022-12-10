using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RotateAttackRangeSphere : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		transform.Rotate(10 * Time.deltaTime, 0, 15 * Time.deltaTime);
	}
}