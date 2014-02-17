using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public int bulletDmg = 25;

	// Update is called once per frame
	void update () {
	
		Debug.DrawRay (transform.position, Vector3.forward);
		RaycastHit hit;
		Ray bullet = new Ray(transform.position, Vector3.forward);
		if (Input.GetMouseButtonDown (0))
		{

			if(Physics.Raycast(bullet, out hit, 100))
			{
				{
					hit.transform.SendMessage ("Damage", bulletDmg, SendMessageOptions.DontRequireReceiver);
				}
		}
	}
}
}