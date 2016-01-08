using UnityEngine;
using System.Collections;


public class Controller : MonoBehaviour {
	
	public GameObject mushroom;
	public GameObject contMushroom;
	public GameObject contCentips;
	public GameObject centip_body;
	public GameObject centip_head;
	public GameObject bullet;	
	public Centipede_list turtles;
	public AudioClip s1_ray;
	public AudioClip s2_coll;
	public bool alreadyShoot;
	public int ups;
	public GUIText Gui;
	public float Speed;
	public bool Play_Game;
	//public static Controller mybody;
	
	
	public static Controller Instance
	{
		get;
		private set;
	}
	
	void Awake() {
		Debug.Log("WWW: " + Screen.width);
		Debug.Log("HHH: " + Screen.height);
        //mybody = this;		
		if(Instance == null)
		{
			//DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else
		{
			DestroyImmediate(gameObject);
		}
		turtles = new Centipede_list(ref centip_body, ref centip_head);
    }
	
	void Start () {
		Init_Game();
	}
	void Init_Game(){
		Speed = 1.0f;
		Screen.lockCursor = false;
		Screen.showCursor = true;
		ups = 5;
		updateLives(ups);
		alreadyShoot = false;
		Play_Game = false;
		createMushrooms();
		turtles.Centipede_init(contCentips);
	}

	
	
	public void updateLives(int val){
		Gui.guiText.text = "Lives: "+val;
	}
	private void createMushrooms()
	{
		int rows = 5;
		int cols = 9;
		float dx = 0;
		float dy = 0;
		for(int i=0; i<rows; i++)
		{
			for(int j=0; j<cols; j++)
			{
				dx = ((int)(Random.Range(2,26))*5.3f);
				//dx = (j)*5;
				dy = -( (int)(Random.Range(2,36))*5.3f );
				//dy = -(i)*5;
				GameObject tMush = (GameObject)Instantiate(mushroom, new Vector3(dx,0,dy), Quaternion.identity);
				tMush.transform.Rotate(0,180,0);
				tMush.transform.parent = contMushroom.transform;				
			}
		}
	}
		
	
	
	public void Game_Over()
	{
		Debug.Log("GAMEOVER");
		Play_Game = false;
		Centipede_body tmp = turtles.headCentip;
		while(tmp != null)
		{
			Destroy(tmp.Get_body());
			tmp = tmp.Get_prev();
		}
	}
	
	
	int anchoBoton = 320;
	int altoBoton = 80;
	void OnGUI() {	
		
		if(Play_Game == false)
		{
			if (GUI.Button(new Rect((Screen.width-anchoBoton)/2,((Screen.height -altoBoton)/2 - altoBoton *2),anchoBoton,altoBoton), "GAME")){						
				
				Destroy(GameObject.Find("Mushrooms"));
				contMushroom = new GameObject("Mushrooms");
				
				Destroy(GameObject.Find("centipede"));
				contCentips = new GameObject("centipede");
				Init_Game();
				Play_Game = true;
				Debug.Log("CLICKKKK" + Controller.Instance.Play_Game);
				//Application.LoadLevel("Centipede2");
			}			
		}
			
	}
	

}
