using UnityEngine;
using System.Collections;

public class CollisionCentip : MonoBehaviour {
	
	
	private Centipede cObj;
	// Use this for initialization
	void Start () {
		cObj = gameObject.GetComponent<Centipede>();
	}
	
	private void OnCollisionEnter(Collision theCollision)
	{
		//body.mybody.fCollC = true;
		//Debug.Log("COLLISIONNNNNN "+theCollision.gameObject.name);
		if(theCollision.gameObject.name == "Gun")
		{
			Controller.Instance.ups--;			
			Controller.Instance.updateLives(Controller.Instance.ups);
			Controller.Instance.Game_Over();
			return;
		}
		if(theCollision.gameObject.name == "LRight" ||
			theCollision.gameObject.name == "LLeft"	||
			theCollision.gameObject.name == "mushrooms_body(Clone)")
		{
			Debug.Log(theCollision.gameObject.name);
			
			cObj._changeDir = true;
			
			cObj._dirHor = cObj._dirHor == true ? false : true;
			
			return;
		}
		if(theCollision.gameObject.name == "LBottom" ||
			theCollision.gameObject.name == "LTop"	)
		{
			cObj._dirVer = cObj._dirVer == true ? false : true;			
			return;
		}
		
	}		
}
