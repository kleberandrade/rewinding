using UnityEngine;

public class DisableCursor : MonoBehaviour
{
	private void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}