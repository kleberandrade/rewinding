using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
	[SerializeField]
	private float m_ViewZone = 10;

	[SerializeField]
	private float m_Speed;

	[SerializeField]
	private float m_SpriteSize;

	[SerializeField]
	private bool m_Parallax = true;

	[SerializeField]
	private bool m_Scrolling = true;

	private Transform m_Camera;

	private float m_LastCameraX;

	private Transform[] m_Layers;

	private int m_LeftIndex;

	private int m_RightIndex;

	private Transform m_Transform;

	private void Awake()
	{
		m_Transform = GetComponent<Transform> ();
	}

	private void Start()
	{
		m_Camera = Camera.main.transform;
		m_LastCameraX = m_Camera.position.x;

		m_Layers = new Transform[m_Transform.childCount];
		for (int i = 0; i < m_Transform.childCount; i++)
			m_Layers[i] = m_Transform.GetChild (i);
		
		m_LeftIndex = 0;
		m_RightIndex = m_Layers.Length - 1;
	}

	private void Update()
	{
		if (m_Parallax) 
		{
			float deltaX = m_Camera.position.x - m_LastCameraX;
			m_Transform.position += Vector3.right * (deltaX * m_Speed * Time.deltaTime);
		}

		m_LastCameraX = m_Camera.position.x;

		if (m_Scrolling) 
		{
			if (m_Camera.transform.position.x < (m_Layers [m_LeftIndex].transform.position.x + m_ViewZone))
				ScrollLeft ();

			if (m_Camera.transform.position.x > (m_Layers [m_RightIndex].transform.position.x - m_ViewZone))
				ScrollRight ();
		}
	}
		
	private void ScrollLeft()
	{
		m_Layers[m_RightIndex].position = new Vector3(
			m_Layers[m_LeftIndex].position.x - m_SpriteSize,
			m_Layers[m_RightIndex].position.y,
			m_Layers[m_RightIndex].position.z);
		
		m_LeftIndex = m_RightIndex;
		m_RightIndex--;
		if (m_RightIndex < 0)
			m_RightIndex = m_Layers.Length - 1;
	}
		
	private void ScrollRight()
	{
		m_Layers [m_LeftIndex].position = new Vector3 (
			m_Layers [m_RightIndex].position.x + m_SpriteSize,
			m_Layers [m_RightIndex].position.y,
			m_Layers [m_RightIndex].position.z);
		
		m_RightIndex = m_LeftIndex;
		m_LeftIndex++;
		if (m_LeftIndex == m_Layers.Length)
			m_LeftIndex = 0;
	}
}