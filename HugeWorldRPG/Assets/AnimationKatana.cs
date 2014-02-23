using UnityEngine;
using System.Collections;

public class AnimationKatana : MonoBehaviour {

	Animator anim;
	
	
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	
	void Update ()
	{
		float move = Input.GetAxis ("Vertical");
		anim.SetFloat("Move", move);
		

	}
}
