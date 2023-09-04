using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private Rigidbody2D Rig;
    private Animator Animation;
    private SpriteRenderer Sprite;

    [SerializeField] private int Life;
    [SerializeField] private int TotalLife;

    [Header("Move")]
    [SerializeField] private float MoveSpd;
    [SerializeField] private float RunSpd;
    [SerializeField] private float JumpSpd;
    [SerializeField] private float RayDistance;
    [SerializeField] private LayerMask LayerGround;
    private bool IsPushing;
    private bool IsMoving;
    private bool isGround;
    private float DirX;

    

    [Header("Respawm")]
    [SerializeField] private Transform RespawnMonster;

    [Header("Audio")]
    [SerializeField] private AudioSource Audio;

    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
        Audio = GetComponent<AudioSource>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Rig = GetComponent<Rigidbody2D>();
        Animation = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }
    //void Start()
    //{
    //    instance = this;
    //    Audio = GetComponent<AudioSource>();
    //    BoxCollider = GetComponent<BoxCollider2D>();
    //    Rig = GetComponent<Rigidbody2D>();
    //    Animation = GetComponent<Animator>();
    //    Sprite = GetComponent<SpriteRenderer>();
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuController.instance.Pause();
        }
        Jump();
        Move();
        Crouch();
        Run();
        Push();

    }
    void Move()
    {
       
        DirX = Input.GetAxisRaw("Horizontal");
        Rig.velocity = new Vector2(DirX * MoveSpd, Rig.velocity.y);


        if (DirX == 0 && !IsPushing)
        {
            Animation.SetInteger("Transition", 0);
            IsMoving = false;
         
        }
        else if (DirX > 0 && !IsPushing)
        {
            Animation.SetInteger("Transition", 1);
            IsMoving = true;
            Sprite.flipX = false;
            
            
        }
        else if (DirX < 0 && !IsPushing)
        {
            Animation.SetInteger("Transition", 1);
            IsMoving = true; 
            Sprite.flipX = true;
           
        }
        
    }

    public void FootSteps()
    {
        Audio.PlayOneShot(Audios.instance.Walk);
    }

    void Run()
    {
        bool RunButton = Input.GetKey(KeyCode.LeftShift);

        if (IsMoving && RunButton)
        {

            MoveSpd = RunSpd;
            Animation.SetInteger("Transition", 2);
            //Debug.Log(MoveSpd);
        }
        else if (IsMoving && !RunButton)
        {
            MoveSpd = 6;
            Animation.SetInteger("Transition", 1);
            //Debug.Log(MoveSpd);
        }
    }

    public void FootStepRun()
    {
        Audio.PlayOneShot(Audios.instance.Run);
    }

    void Jump()
    {
        bool JumpButton = Input.GetKeyDown(KeyCode.Space);

        if (JumpButton && IsGround())
        {
            Audio.PlayOneShot(Audios.instance.Jump);
            Rig.AddForce(Vector2.up * JumpSpd, ForceMode2D.Impulse);
            Animation.SetTrigger("Jump");
            Audio.PlayOneShot(Audios.instance.Jump);
        }
    }

    void Crouch()
    {
        bool CrouchButton = Input.GetKey(KeyCode.LeftControl);

        if (CrouchButton)
        {
            Animation.SetInteger("Transition", 4);
            MoveSpd = 0;
            //Debug.Log("Agachou");
        }
        else
        {
            
            MoveSpd = 6;
        }
    }

    void Push()
    {
        if (IsPushing)
        {
            Animation.SetInteger("Transition", 3);
        }
    }

    public void OnHit(int damage)
    {
        Life--;
        Audio.PlayOneShot(Audios.instance.Hit);

        if (Life <= 0)
        {
            CheckPoint.instance.ReturnCheckPoint();
        }
    }

    public void ResetLife()
    {
        Life = TotalLife;
    }

    public bool IsGround()
    {
        RaycastHit2D ground = Physics2D.BoxCast(BoxCollider.bounds.center, BoxCollider.bounds.size, 0f, Vector2.down,0.1f, LayerGround);

        return ground.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            CheckPoint.instance.ReturnCheckPoint();
        }

        if (collision.gameObject.CompareTag("FinalScene"))
        {
            StartCoroutine(TimeLoadScene());
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzleObj") && IsMoving)
        {
            IsPushing = true;
        }
        else
        {
            IsPushing = false;
        }
    }

    IEnumerator TimeLoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
        StopCoroutine(TimeLoadScene());
    }

   
}
