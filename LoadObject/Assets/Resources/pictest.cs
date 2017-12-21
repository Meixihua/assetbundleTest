using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class pictest : MonoBehaviour {
	public Image image;
	// Use this for initialization
	void Start () {
		Sprite testSprite = Resources.Load ("testpic1", typeof(Sprite)) as Sprite;
		Debug.Log ("test");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
