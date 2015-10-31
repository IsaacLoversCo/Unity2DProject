using UnityEngine;
using System.Collections;

public class PlateformBehaviourScript : MonoBehaviour
{

    public Rigidbody2D Body;
    public bool CanFall;
    float GroundRadius = 0.2f;
    bool Touch;
    public LayerMask WhereIsPlayer;
    public Transform topofplateforme;

    public TextMesh text_tap;
    // Use this for initialization
    void Start()
    {
        text_tap = GameObject.Find("FailText").GetComponent<TextMesh>();

    }

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();

        // RemoveConstaints();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Vector2 A = new Vector2(topofplateforme.position.x - topofplateforme.localScale.x, topofplateforme.position.y + topofplateforme.localScale.y);
        Vector2 B = new Vector2(topofplateforme.position.x + topofplateforme.localScale.x, topofplateforme.position.y - topofplateforme.localScale.y);
        Touch = Physics2D.OverlapArea(A, B, WhereIsPlayer);
        if (Touch && CanFall)
            RemoveConstaints();
    }

    void RemoveConstaints()
    {
        Body.constraints = RigidbodyConstraints2D.None;
    }
}
