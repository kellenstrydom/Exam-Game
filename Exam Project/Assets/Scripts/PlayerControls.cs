 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    public enum ActionState
    {
        idle,
        moving,
        dashing,
        attacking
    }
    
    private float HorizontalInput;
    private float VerticalInput;

    public ActionState currentState;
    public Animation _PAnimation;
        
    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeed;
    
    [Header("Dashing")]
    public float dashForce;
    public float dashDuration;
    public float dashCooldown;
    public int dashAmount;
    [SerializeField]
    private int dashCount;
    [SerializeField] 
    private TrailRenderer tr;

    [Header("Attacking")] 
    public Weapon weapon;

    [Header("Input Keys")] 
    public KeyCode sprintKey;
    public KeyCode dashKey;
    public KeyCode lightAttackKey;
    public KeyCode heavyAttackKey;
    
    [Header("Character Object")]
    public Transform playerObj;
    public float objectRotSpeed;
    
    [Header("Object Components")]
    public Transform orientation;

    public CapsuleCollider objColider;
    
    [Header("Camera")]
    public Camera camera;
    public Vector3 camOffset;
    public Vector3 camAngleDeg;
    public bool useSceneCamPos;

    // flags
    private bool isSprinting;
    
    private Vector3 inputDir;
    private Rigidbody rb;
    private PlayerUI _playerUI;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        camera = Camera.main;
        // get cam offset
        if (useSceneCamPos)
        {
            camOffset = camera.transform.position - transform.position;
            camAngleDeg = camera.transform.rotation.eulerAngles;
        }
        
        SetInputKeys();

        _playerUI = GameObject.FindWithTag("UI").GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerUI.isPaused) return;
        transform.GetChild(0).localPosition = Vector3.zero;
        if (currentState == ActionState.moving || currentState == ActionState.idle)
        {
            GetInput();
            Move();
        }
        
        //OrientateTowardsCamera();
        MoveCam();
    }

    void GetInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(HorizontalInput, 0, VerticalInput);
        if (inputDir == Vector3.zero)
            currentState = ActionState.idle;
        else
        {
            currentState = ActionState.moving;
        }
        if (inputDir.magnitude > 1) inputDir = inputDir.normalized;

        if (inputDir != Vector3.zero)
             orientation.forward = new Vector3(HorizontalInput, 0, VerticalInput).normalized;

        isSprinting = Input.GetKey(sprintKey);

        if (Input.GetKeyDown(dashKey) && (dashCount < dashAmount))
        {
            Dash();
            return;
        }
        
        if (Input.GetKeyDown(lightAttackKey))
        {
            LightAttack();
            return;
        }
        
        if (Input.GetKeyDown(heavyAttackKey))
        {
            HeavyAttack();
            return;
        }
        
        
    }

    void OrientateTowardsMouse()
    {
        Vector2 screenMousePos = Input.mousePosition;

        Vector3 mouseDir = new Vector3(screenMousePos.x - camera.pixelWidth * 0.5f,0,screenMousePos.y - camera.pixelHeight * 0.5f);
        

        orientation.forward = mouseDir.normalized;
        // rotate object;
        //if (currentState != ActionState.moving && currentState != ActionState.dashing) 
            playerObj.forward = orientation.forward;
        // playerObj.forward = Vector3.Slerp(playerObj.forward, orientation.forward, Time.deltaTime * objectRotSpeed);


    }
    

    void Move()
    {
        // move in dir of input
        if (!isSprinting)
        {
            rb.AddForce(inputDir * (moveSpeed * 15),ForceMode.Force);
            if (rb.velocity.magnitude > moveSpeed) rb.velocity = rb.velocity.normalized * moveSpeed;
        }        
        else
        {
            rb.AddForce(inputDir * (sprintSpeed * 15),ForceMode.Force);
            if (rb.velocity.magnitude > sprintSpeed) rb.velocity = rb.velocity.normalized * sprintSpeed;
        }   
        //Debug.Log(rb.velocity.magnitude);
        

        // rotate object;
        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * objectRotSpeed);
        }
    }

    void MoveCam()
    {
        // camera offset
        camera.transform.position = transform.position + camOffset;
        camera.transform.rotation = Quaternion.Euler(camAngleDeg);

    }

    void Dash()
    {
        currentState = ActionState.dashing;
        OrientateTowardsMouse();
        rb.velocity = Vector3.zero;
        rb.AddForce(orientation.forward * (dashForce),ForceMode.Impulse);
        dashCount++;
        tr.emitting = true;
        // objColider.enabled = false;
        Invoke("ResetMovementState", dashDuration);
        Invoke("DashRecharge",dashCooldown);
    }

    void DashRecharge()
    {
        dashCount--;
    }

    void LightAttack()
    {
        OrientateTowardsMouse();
        weapon.LightAttack();
    }
    
    void HeavyAttack()
    {
        OrientateTowardsMouse();
        weapon.HeavyAttack();
    }
    
    void ResetMovementState()
    {
        tr.emitting = false;
        // objColider.enabled = true;
        currentState = ActionState.moving;
    }

    void SetInputKeys()
    {
        sprintKey = KeyCode.LeftShift;
        dashKey = KeyCode.Space;
        lightAttackKey = KeyCode.Mouse0;
        heavyAttackKey = KeyCode.Mouse1;
    }

    void DoAnimations()
    {
        
        _PAnimation.Run(currentState == ActionState.moving);
        _PAnimation.Dashing(currentState == ActionState.dashing);
        _PAnimation.Attacking(currentState == ActionState.attacking);
    }
}
