using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance { get; private set; }

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
    void Start()
    {
        Instance = this;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !DialogDisplay.Instance.IsActive)
        {
            Move();
        }
        if(Input.GetKeyDown(KeyCode.E) && !DialogDisplay.Instance.IsActive)
        {
            DialogDisplay.Instance.dialogue = this.targetDialog;
            DialogDisplay.Instance.Show();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

   

        

        transform.position += rightMovement;
        transform.position += forwardMovement;
    }
}
