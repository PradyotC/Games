using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementSinusoidal_level1_mushtaq : MonoBehaviour
{

	[SerializeField]
	float moveSpeed = 4f;

	[SerializeField]
	float frequency = 3f;

	[SerializeField]
	float magnitude = 2f;

	float offset = 1f;

	bool facingRight = false;

	float patrolDistance = 4f;

	Vector3 pos, localScale;

	// Use this for initialization
	void Start()
	{

		pos = transform.position;

		localScale = transform.localScale;

	}

	// Update is called once per frame
	void Update()
	{

		CheckWhereToFace(transform.position.x);

		if (facingRight)
			MoveRight();
		else
			MoveLeft();
	}

	void CheckWhereToFace(float currPos)
	{
		if (pos.x > currPos + 5)
			facingRight = true;

		else if (pos.x + 5 < currPos)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	void MoveRight()
	{
		pos += transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
	}

}