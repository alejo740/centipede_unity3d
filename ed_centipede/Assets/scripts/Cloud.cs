using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	
	public Camera cam;
	
	private Vector3 screenPos;
	private bool coll;
	private float incX;
	private float incZ;
	
	// Use this for initialization
	void Start () {
		Debug.Log("CLOUDDD");
	}
	
	void Update () {		
		if(Controller.Instance.Play_Game == true)
		{
			playerController();
			
			shooting();			
		}
	}
	
	private void shooting()
	{
		if(screenPos.x > 0 && screenPos.x <145 && screenPos.z < 0 && screenPos.z > -195)
		{
			//if (Input.GetButtonDown("Fire1"))
			if(Controller.Instance.alreadyShoot == false)
			{
				if (Input.GetMouseButtonDown(0))
				{
					Controller.Instance.audio.clip = Controller.Instance.s1_ray;
					Controller.Instance.audio.Play();					
					Vector3 disPos;
					disPos.x = this.transform.localPosition.x;
					disPos.y = this.transform.localPosition.y;
					disPos.z = this.transform.localPosition.z-2.5f;
					GameObject disparoClone = (GameObject)Instantiate(Controller.Instance.bullet, disPos , Quaternion.identity); 
					disparoClone.transform.Rotate(0,180,0);
					disparoClone.transform.parent = GameObject.Find("Shoots").transform;
					disparoClone.rigidbody.velocity = new Vector3(0,0,-80.0f);
					Controller.Instance.alreadyShoot = true;
				}
			}
		}
	}
	
	private void playerController()
	{
		screenPos = cam.ScreenToWorldPoint( Input.mousePosition );		
		screenPos.y = 0;
		incX = screenPos.x;
		incZ = screenPos.z;
		if(coll == true)
		{
			Vector3 dif;
			dif.x = Mathf.Abs( screenPos.x - this.gameObject.transform.localPosition.x);
			dif.y = 0;
			dif.z = Mathf.Abs( screenPos.z - this.gameObject.transform.localPosition.z);				
			if(screenPos.x > this.gameObject.transform.localPosition.x)
			{
				Debug.Log("X ++++ X");
				if(dif.x >= 5.0f)
				{
					dif.x = 1.0f;//5.0f-(5.0f/dif.x);
					incX = this.gameObject.transform.localPosition.x + dif.x;
				}					
			}
			if(screenPos.x < this.gameObject.transform.localPosition.x)
			{
				Debug.Log("X ---- X");
				if(dif.x >= 5.0f)
				{
					dif.x = 1.0f;//5.0f-(5.0f/dif.x);
					incX = this.gameObject.transform.localPosition.x - dif.x;
				}					
			}
			
			if(screenPos.z < this.gameObject.transform.localPosition.z)
			{
				Debug.Log("Z ---- Z");
				if(dif.z >= 5.0f)
				{
					dif.z = 1.0f;//5.0f-(5.0f/dif.x);
					incZ = this.gameObject.transform.localPosition.z - dif.z;
				}					
			}
			if(screenPos.z > this.gameObject.transform.localPosition.z)
			{
				Debug.Log("Z ++++ Z");
				if(dif.z >= 5.0f)
				{
					dif.z = 1.0f;//5.0f-(5.0f/dif.x);
					incZ = this.gameObject.transform.localPosition.z + dif.z;
				}					
			}				
		}else{
			if(screenPos.z < -40)
			{
				incZ = -40;				
			}
			if(screenPos.z > 0.0f)
			{
				incZ = 0.0f;				
			}
			if(screenPos.x < 0)
			{
				incX = 0.0f;				
			}
			if(screenPos.x > 145.0f)
			{
				incX = 145.0f;				
			}
		}
		//iTween.MoveUpdate(this.gameObject, iTween.Hash("x", incX, "z", incZ, "y", 0, "islocal", true, "time", 1.5f));
		Vector3 np = new Vector3(incX, 0, incZ);		
		this.gameObject.transform.localPosition = Vector3.Lerp(this.gameObject.transform.localPosition, np, 0.2f);
	}
	
	
	
	
	void OnCollisionEnter(Collision theCollision)
	{
		if(theCollision.gameObject.name == "mushrooms_body(Clone)" || theCollision.gameObject.name == "mushrooms_body")
		{
			coll = true;
			return;
		}
	}	
	void OnCollisionStay(Collision theCollision)
	{
		if(theCollision.gameObject.name == "mushrooms_body(Clone)" || theCollision.gameObject.name == "mushrooms_body")
		{
			//coll = true;
			return;
		}
	}
	void OnCollisionExit(Collision theCollision)
	{
		if(theCollision.gameObject.name == "mushrooms_body(Clone)" || theCollision.gameObject.name == "mushrooms_body")
		{
			coll = false;
			return;
		}
	}
}
