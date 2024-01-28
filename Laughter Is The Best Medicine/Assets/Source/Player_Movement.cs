using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Animation variables
    Rigidbody2D rBody2D;
    Animator animator;

    //Movement variables
    public float speed = .5f;
    Vector2 movement;

    //jokeassets
    [SerializeField] private bool hasJoke;
    [SerializeField] private string theJoke;
    [SerializeField] private StandManager.JokeType heldJokeType; //Defaults to DadJoke

    public bool HasJoke
    {
        get { return hasJoke; }
        set { hasJoke = value; }
    }

    public string TheJoke
    {
        get { return theJoke; }
        set {  theJoke = value; }
    }

    public StandManager.JokeType HeldJokeType 
    { 
        get { return heldJokeType; } 
        set { heldJokeType = value; }
    }
    // end jokeassets

    void Start()
    {
        if (GetComponent<Rigidbody2D>())
            rBody2D = GetComponent<Rigidbody2D>();

        if (GetComponent<Animator>())
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rBody2D.MovePosition(rBody2D.position + movement * speed * Time.deltaTime);
    }
}
