using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    public static MainCharacterController Instance { get; private set; }
    private SpriteRenderer sprite;
    public Dialogue targetDialog;
    public Dialogue TargetDialog {
        get => targetDialog;
        set
        {
            targetDialog = value;
        }
    }
    [SerializeField] float moveSpeed;
    Vector3 forward, right;
    CapsuleCollider _playerCollider;
    Rigidbody _rbPlayer;
   
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Instance = this;
        switch (GlobalInformations.s_Direction) {
            case EnumDirection.SOUTH:
                transform.position = GameObject.FindGameObjectWithTag("South").transform.position;
                break;
            case EnumDirection.EAST:
                transform.position = GameObject.FindGameObjectWithTag("East").transform.position;
                break;
            case EnumDirection.NORTH:
                transform.position = GameObject.FindGameObjectWithTag("North").transform.position;
                break;

            case EnumDirection.WEST:
                transform.position = GameObject.FindGameObjectWithTag("West").transform.position;
                break;

            default:
                transform.position = GameObject.FindGameObjectWithTag("DefaultSpawn").transform.position;
                break;
        }

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        _playerCollider = GetComponent<CapsuleCollider>();
        _rbPlayer = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("HorizontalKey") != 0 || Input.GetAxis("VerticalKey") != 0)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.E) && !DialogDisplay.Instance.IsActive() && targetDialog != null)
        {
            DialogDisplay.Instance.dialogue = this.targetDialog;
            DialogDisplay.Instance.Show();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            LogManager.Instance.DisplayLog();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelOfSuspicien.Instance.Quit();
        }
    }
    void FixedUpdate()
    {

        if (Input.anyKey && !DialogDisplay.Instance.IsActive())
        {
            Move();
        }
        else
        {
            _rbPlayer.velocity = Vector3.zero;
        }

        
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        sprite.flipX = (Input.GetAxis("HorizontalKey") < 0);
        _rbPlayer.velocity = rightMovement + forwardMovement;
       
            

    }


}
