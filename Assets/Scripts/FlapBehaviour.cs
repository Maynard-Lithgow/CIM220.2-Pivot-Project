using UnityEngine;
using UnityEngine.InputSystem;

public class FlapBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 2.3f;
    public float speed;

    private Rigidbody2D _rb;
    public GameObject flapperStartingPoint;
    public MiniGamer miniGamer;
    public Transform myTransform;
    public Vector3 myVector3;


    private void Start()
    {
        myVector3 = myTransform.position;
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        myVector3 = myTransform.position;
        if (myVector3.x <= -3.6f)
        {
            Debug.Log("IT SHOULD BE HAPPENING");
            miniGamer.GameOver();
        }
        else if (myVector3.y >= -0.6f)
        {
            Debug.Log("IT SHOULD BE HAPPENING");
            miniGamer.GameOver();
        }
        else if(myVector3.x <= -4.08f)
        {
            Debug.Log("IT SHOULD BE HAPPENING");
            miniGamer.GameOver();
        }
    }
    public void Flap()
    {
        _rb.linearVelocity = Vector2.up * _velocity;

    }
    public void Restart()
    {

    }

}
