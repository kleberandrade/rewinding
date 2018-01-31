using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ConstantMoveObject : MonoBehaviour 
{
	[SerializeField]
	private float m_Speed = 2.0f;

	[SerializeField]
	private Vector3 m_Direction = Vector3.right;

	private Rigidbody2D m_Rigidbody;

	private void Awake () 
	{
		m_Rigidbody = GetComponent<Rigidbody2D> ();
	}

	private void Update () 
	{
		Vector2 velocity = m_Rigidbody.velocity;
		m_Rigidbody.velocity = m_Direction * m_Speed * Time.deltaTime;	
	}

	[ContextMenu("Right")]
	private void MoveRight()
	{
		m_Direction = Vector3.right;
	}

	[ContextMenu("Left")]
	private void MoveLeft()
	{
		m_Direction = Vector3.left;
	}
}
