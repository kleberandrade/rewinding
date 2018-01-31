using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField] Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
