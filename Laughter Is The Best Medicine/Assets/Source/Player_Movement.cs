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

    [SerializeField] private AudioSource FootStep;
    [SerializeField] AudioClip FootStep1;
    [SerializeField] AudioClip FootStep2;
    [SerializeField] AudioClip FootStep3;

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
        FootStep.clip = FootStep1;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        WalkSounds(movement);
    }
    void WalkSounds(Vector2 move)
    {
        //FootStep.Play();
        if(!FootStep.isPlaying && move.x != 0 || move.y != 0)
        {
            //FootStep.Play();
            int x = Random.Range(1, 3);
            //AudioSource footstep = GetComponent<AudioSource>();

            if(x == 1)
            {
                FootStep.Play();
                //yield return new WaitForSeconds(FootStep.clip.length);
                FootStep.clip = FootStep1;
                //FootStep.Play();
            }
            else if(x == 2)
            {
                FootStep.Play();
                //yield return new WaitForSeconds(FootStep.clip.length);
                FootStep.clip = FootStep2;
                //FootStep.Play();
            }
            else if( x == 3)
            {
                FootStep.Play();
                //yield return new WaitForSeconds(FootStep.clip.length);
                FootStep.clip = FootStep3;
                //FootStep.Play();
            }
        }
    }
    void FixedUpdate()
    {
        rBody2D.MovePosition(rBody2D.position + movement * speed * Time.deltaTime);
    }
}
