using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{
	public Transform target;
	void Start(){
		//iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", .4));
		//iTween.MoveBy(gameObject, Vector3(0,0.2,4), 2);
		//iTween.MoveTo(gameObject,Vector3(2,0,0),2);
				
		iTween.MoveTo(gameObject, iTween.Hash("x",2,"time",1,"delay",2,"onupdate","myUpdateFunction","looptype",iTween.LoopType.loop,"easeType",iTween.EaseType.easeInOutQuart));				
		

		//iTween.MoveTo(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
	
	void FixedUpdate(){
		//iTween.MoveUpdate(gameObject, iTween.Hash("x",3,"time",4));
	}
}

