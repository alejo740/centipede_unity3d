using UnityEngine;
using System.Collections;


//Classes
public class Centipede_body
{
	private Centipede_body prev;	
	private GameObject body;	
	private Centipede_body next;
	public bool cDirH;
	public bool cDirV;
	public float limitL = 0f;
	public float limitR = 145f;
	
	public Centipede_body()
	{
		prev = null;
		body = null;
		next = null;
		cDirH = true;
		cDirV = true;
		
	}
	public Centipede_body(Centipede_body _prev, GameObject _body, Centipede_body _next, bool dH=true, bool dV=true)
	{
		prev = _prev;
		body = _body;
		next = _next;
		cDirH = dH;
		cDirV = dV;
	}
	public Centipede_body Get_prev(){
		return prev;
	}
	public Centipede_body Get_next(){
		return next;
	}
	public GameObject Get_body(){
		return body;
	}
	public void Set_prev(ref Centipede_body a){
		prev = a;
	}
	public void Set_next(ref Centipede_body a){
		next = a;
	}
	public void Set_body(GameObject a){
		body = a;
	}
}

public class Centipede_list : MonoBehaviour
{
	public Centipede_body list;
	public Centipede_body aux;
	public Centipede_body headCentip;
	public GameObject body_c;
	public GameObject head_c;
	
			
	public Centipede_list(ref GameObject _body_c, ref GameObject _head_c)
	{			
		list = null;
		aux = null;
		body_c = _body_c;
		head_c = _head_c;
	}
	
	public void Centipede_init(GameObject dst)
	{
		float dx=30;
		float dy=-196.1f;
		int numNodes = 5;
		aux = null;
		for(int i=0; i<numNodes; i++)
		{
			list = new Centipede_body();
			
			///aux.set_next(ref );
			list.Set_next(ref aux);
			
			GameObject bd;// = new GameObject("centip_"+i);
			if(list.Get_next()==null)
			{
				headCentip = list;
				bd = (GameObject)Instantiate(head_c, new Vector3(dx,0,dy), Quaternion.identity);
				bd.name = "centip_head";
			}else{
				bd = (GameObject)Instantiate(body_c, new Vector3(dx,0,dy), Quaternion.identity);
				list.Get_next().Set_prev(ref list);
				bd.name = "centip_0";
			}
			//bd.name = "centip_"+i;			
			bd.transform.Rotate(0,180,0);
			bd.transform.parent = dst.transform;
			//Debug.Log(bd.transform.localPosition);
			list.Set_body(bd);
			
			
			aux = list;				
			dx -= 5.3f;
		}
		Debug.Log("++++++++++++++++++");
	}
	
	
	
}

public class Centipede:MonoBehaviour{
	
	public bool _changeDir;
	public bool _dirHor;
	public bool _dirVer;
	
	public float speed = 1.0f;
	public float dirX = 0;
	public float dirZ = 0;
	
	// Use this for initialization
	void Start () {
		this._dirHor = true;
		this._dirVer = true;		
		this._changeDir = false;
		//Debug.Log("INITIALIZATION");
	}
	
	// Update is called once per frame
	void Update () {
		CentipMove();		
	}
	
	public void CentipMove()
	{
		speed = Controller.Instance.Speed;
		dirX = 0;
		dirZ = 0;
		
		//centipede_body tmp = headCentip;
		if(_dirHor == true)
		{
			dirX = -speed;
		}else{
			dirX = speed;				
		}
		if(_changeDir == true)
		{
			if(_dirVer == true)
			{
				dirZ = -5.3f;					
			}else{
				dirZ = 5.3f;
			}				
			GameObject obj = this.gameObject;
			obj.transform.localScale = new Vector3(-obj.transform.localScale.x,
				obj.transform.localScale.y,
				obj.transform.localScale.z);
			
		}
		//Debug.Log("AQUIII "+_dirHor);
		
		GameObject cp = this.gameObject;		
		cp.transform.Translate(dirX,0,dirZ);
		if(cp.transform.localPosition.x < 0)
			cp.transform.localPosition = new Vector3(-0.1f,0,cp.transform.localPosition.z);
		
		if(cp.transform.localPosition.x > 145)
			cp.transform.localPosition = new Vector3(145.1f,0,cp.transform.localPosition.z);
		
		_changeDir = false;	
	}
}
