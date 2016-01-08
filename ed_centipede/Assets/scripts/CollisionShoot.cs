using UnityEngine;
using System.Collections;

public class CollisionShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision theCollision)
	{
		//LBottom
		//Debug.Log(theCollision.gameObject.name);
		if(theCollision.gameObject.name == "ray(Clone)")
		{
			Controller.Instance.alreadyShoot = false;
			Destroy(theCollision.gameObject);
			return;
		}
		if(theCollision.gameObject.name != "Gun")
		{
			Controller.Instance.alreadyShoot = false;
			Destroy(this.gameObject);
			///Debug.Log(theCollision.gameObject.name);
		}
		if(theCollision.gameObject.name == "centip_head")
		{
			Destroy(theCollision.gameObject);
			Controller.Instance.Game_Over();
			return;
		}
		if(theCollision.gameObject.name == "centip_0")
		{
			Controller.Instance.ups--;
			Controller.Instance.Speed += 0.15f;
			Controller.Instance.updateLives(Controller.Instance.ups);
			Destroy(theCollision.gameObject);
			if(Controller.Instance.ups == 0)
			{
				Controller.Instance.Game_Over();
			}
			
			return;
		}
		if(theCollision.gameObject.name == "mushrooms_body(Clone)" || theCollision.gameObject.name == "mushrooms_body")
		{
			Controller.Instance.alreadyShoot = false;
			Destroy(theCollision.gameObject);			
		}
		if(theCollision.gameObject.name != "LBottom")
		{
			Controller.Instance.alreadyShoot = false;
			Controller.Instance.audio.clip = Controller.Instance.s2_coll;
			Controller.Instance.audio.Play();
		}
		
		//action on centip
		
		
	}	
	void OnCollisionStay(Collision theCollision)
	{
		if(theCollision.gameObject.name == "mushrooms_body(Clone)" || theCollision.gameObject.name == "mushrooms_body")
		{
			
			return;
		}
	}
	void OnCollisionExit(Collision theCollision)
	{
		if(theCollision.gameObject.name == "mushrooms_body(Clone)" || theCollision.gameObject.name == "mushrooms_body")
		{
			
			return;
		}
	}
}
