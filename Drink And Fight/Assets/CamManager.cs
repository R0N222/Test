using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{

	[SerializeField] private List<Transform> targets;

	[SerializeField] private Vector3 offset;
	[SerializeField] private float smoothTime = 0.5f;

	private Vector3 velocity;

	[SerializeField] private float minZoom = 40f, maxZoom = 10f, zoomLimiter = 50f;


	[SerializeField] public Camera cam;

	public static CamManager instance;
	public void Start()
	{
		instance = this;
	}

	public void Add(Transform target)
	{
		if(!targets.Contains(target)) targets.Add(target);
	}

	public void Remove(Transform target)
	{
		targets.Remove(target);
	}

	public void LateUpdate()
	{
		if(targets.Count > 0)
		{
			Zoom();
			Move();

		}

	}

	private void Zoom()
	{
		float newZ = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
		cam.orthographicSize = newZ;
	}

	private void Move()
	{
		Vector3 centerPoint = GetCenterPoint();
		Vector3 newPos = centerPoint + offset;
		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
	}

	float GetGreatestDistance()
	{
		var bounds = new Bounds(targets[0].position, Vector3.zero);

		for (int i = 0; i < targets.Count; i++)
		{
			bounds.Encapsulate(targets[i].position);
		}
		return bounds.size.x;
	}

	private Vector2 GetCenterPoint()
	{
		if (targets.Count == 1) return targets[0].position;


		var bounds = new Bounds(targets[0].position, Vector3.zero);
		foreach (var item in targets)
		{
			bounds.Encapsulate(item.position);
		}
		return bounds.center;
	}
}
