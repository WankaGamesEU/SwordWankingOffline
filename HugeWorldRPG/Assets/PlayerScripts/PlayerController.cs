    SwordWankingOffline a basic sword fightning game
    Copyright (C) 2014  WankaGamesEU

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.






using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerMovementSpeed = 5.0f;
	public float mouseSens = 5.0f;
	public float rangeUpDown = 70f;
	float verticalRotation = 0;
	public float verticalVelocity = 0;
	public float jumpSpeed = 5f;

	// Use this for initialization
	void Start ()
	{
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

		// CameraRot

			//Horizontal
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSens;
		transform.Rotate(0 , rotLeftRight, 0);

			//Vertical
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens;
		verticalRotation = Mathf.Clamp (verticalRotation, -rangeUpDown, rangeUpDown);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);




		//MoveMentCommands
		float ForwardSpeed = Input.GetAxis ("Vertical") * playerMovementSpeed;
		float SideSpeed = Input.GetAxis ("Horizontal")* playerMovementSpeed;

		Vector3 speed = new Vector3(SideSpeed, verticalVelocity, ForwardSpeed);

		speed = transform.rotation * speed;
	
		CharacterController cc = GetComponent<CharacterController> ();
		cc.Move (speed * Time.deltaTime);


		//Gravity

		verticalVelocity += Physics.gravity.y * Time.deltaTime;





		if (cc.isGrounded)  {

		//Jump
		
		if (Input.GetButton ("Jump")) 	{
			verticalVelocity = jumpSpeed;
			}
		}
	}
}
