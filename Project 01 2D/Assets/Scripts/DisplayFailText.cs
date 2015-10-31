using UnityEngine;
using System.Collections;

public class DisplayFailText : MonoBehaviour {


    public Rigidbody2D Body;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {

        Body = GetComponent<Rigidbody2D>();
        RemoveConstaints();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RemoveConstaints()
    {
        Body.constraints = RigidbodyConstraints2D.None;
    }
}
