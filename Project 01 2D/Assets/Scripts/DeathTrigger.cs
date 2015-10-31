using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		text_tap = GameObject.Find ("FailText").GetComponent<TextMesh> ();

        //text_tap.gameObject.SetActive(false);
    }
    public TextMesh text_tap;

    void Awake()
	{

		
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
            text_tap.gameObject.SetActive(true);
        }
    }
}
