using UnityEngine;
using System.Collections;

public class TransformFollower : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offsetPosition;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
        transform.RotateAround(player.transform.position, Vector3.up, horizontalInput * speed * Time.deltaTime);


	[SerializeField]
	private Space offsetPositionSpace = Space.Self;

	[SerializeField]
	private bool lookAt = true;

	private void Update()
	{
		Refresh();
	}

	public void Refresh()
	{
		if(target == null)
		{
			Debug.LogWarning("Missing target ref !", this);

			return;
		}

		// compute position
		if(offsetPositionSpace == Space.Self)
		{
			transform.position = target.TransformPoint(offsetPosition);
		}
		else
		{
			transform.position = target.position + offsetPosition;
		}

		// compute rotation
		if(lookAt)
		{
			transform.LookAt(target);
		}
		else
		{
			transform.rotation = target.rotation;
		}
	}
}