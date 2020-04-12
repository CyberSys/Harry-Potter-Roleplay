using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float currentSpeed;
    public float speed;
    public float runSpeed;
    public float minSlopeAngle = 15f;
    public float maxSlopeAngle = 45f;
    public float slopeRaiser = 8f;
    public float slopeTopDistance = 5f;
    [Range(0, 1)]
    public float movementDrag = 0.7f;
    [Range(1, 2)]
    public float dragStopper = 1f;
    public float jumpForce = 250f;
    [Range(0, 1)]
    public float jumpDrag = 0.3f;

    [Header("Spell Settings")]
    public Transform spellTransform;
    public GameObject spell;
    public GameObject wand;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    [Header("Held Item Settings")]
    public List<GameObject> holdableItems;
    public GameObject currentHandItem;
    public int scrollIndex = 1;

    [Header("Camera Settings")]
    [Range(1, 10)]
    public float sensitivity = 8f;
    [SerializeField]
    private float maxCameraAngle = 50f;
    [SerializeField]
    private float minCameraAngle = -45f;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float interactionDistance = 5f;
    public UIManager uiManager;

    [Header("Player Settings")]
    public float height = 2f;
    public float heightPadding = 0.05f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    [Header("Animation Settings")]
    public Animator wandAnim;

    private bool isGrounded;
    private Rigidbody rb;
    private Vector3 cameraRotation = Vector3.zero;
    private float currentCameraRotationX;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        GameObject currentHandItem = holdableItems[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Getting movement Input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //Getting mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * (sensitivity * 10) * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * (sensitivity * 10) * Time.deltaTime;

        //Checks if Grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Moving player
        Movement(moveX, moveY, mouseX);
        //Rotating camera
        RotateCamera(mouseY);
        //Allows the player to interact with objects
        Interact();
        ChangeHandItem();
    }

    #region functions

    //Checks if a character is on a slope
    bool CheckSlope()
    {
        if(!isGrounded)
        {
            return false;
        }
        RaycastHit hit;
        if(Physics.Raycast(groundCheck.position, Vector3.down, out hit, 0.3f))
        {
            var slopeAngle = Vector3.Angle(hit.normal, transform.up);
            if (slopeAngle > minSlopeAngle && slopeAngle < maxSlopeAngle)
            {
                if (Physics.Raycast(new Vector3 (transform.position.x, transform.position.y - .9f, transform.position.z), transform.forward, slopeTopDistance))
                {
                    return true;
                }
            }
        }

        return false;
    }

    //Player movement
    void Movement(float moveX, float moveY, float mouseX)
    {
        MainFire();
        if (CheckSlope())
        {
            rb.AddForce(transform.up * slopeRaiser);
        }
        //Player can only jump and sprint when grounded
        if (isGrounded)
        {
            Sprint();
            Jump();
        }

        //Takes movement input and turns into directoin vector
        Vector3 movement = new Vector3(moveX, 0, moveY);
        Vector3 direction = movement.normalized;
        if (rb.velocity.magnitude < currentSpeed)
        {
            //Moves player with forces
            rb.AddRelativeForce(direction * currentSpeed * 2);
        }

        //rotating body
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, mouseX, 0)));

        //if not moving
        if (movement.magnitude == 0)
        {
            //stops player
            rb.drag = dragStopper;

        }
        else
        {
            //keeps momentum when in air, some momentum when hitting ground
            if (isGrounded)
            {
                rb.drag = movementDrag;
            }
            else
            {
                rb.drag = jumpDrag;
            }
            
        }
    }

    void RotateCamera(float mouseY)
    {
        //Takes mouse position and puts in vector3 form
        Vector3 cameraRotation = new Vector3(mouseY, 0f, 0f);
        //If there is a camera
        if (cam != null)
        {
            // Set camera rotation and clamp to min/max values
            currentCameraRotationX -= mouseY;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -maxCameraAngle, -minCameraAngle);

            //Rotate camera's transform
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }

    void Sprint()
    {
        if (Input.GetButton("Sprint"))
        {
            //Changes max speed to running speed
            currentSpeed = runSpeed;
        }
        else
        {
            //Resets max speed to walking speed
            currentSpeed = speed;
        }
    }

    void Jump()
    {
        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            //Adds the force for jumping
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void Interact()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionDistance))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.InteractedWith();
                }
            }
        }
    }

    void MainFire()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            //if holding wand
            if (currentHandItem == holdableItems[1])
            {
                if (spell != null)
                {
                    //if its no current spell
                    if (GetComponentInChildren<SpellController>() == null)
                    {
                        wandAnim.SetTrigger("CastSpell");
                        nextFire = Time.time + fireRate;
                        var tempSpell = Instantiate(spell, spellTransform);
                    }
                }
            }
            //if holding nothing (hands)
            else if (currentHandItem == holdableItems[0])
            {

            }
            //if holding potion
            else if (holdableItems.Count >= 2)
            {
                if (currentHandItem == holdableItems[2])
                {

                }
            }
        }
    }

    void ChangeHandItem()
    {
        //Debug.Log(Input.mouseScrollDelta.y);
        //scroll wheel +/- 1 from current held item
        if (Input.mouseScrollDelta.y < 0 && scrollIndex > 0)
        {
            scrollIndex--;
        } else if (Input.mouseScrollDelta.y > 0 && scrollIndex < holdableItems.Count - 1)
        {
            scrollIndex++;
        }

        //assign current held item by scroll index
        currentHandItem = holdableItems[scrollIndex];

        //activate held item and deactivate unheld items
        for (int i = 0; i < holdableItems.Count; i++)
        {
            if(holdableItems[i] != currentHandItem)
            {
                holdableItems[i].SetActive(false);
            } else
            {
                holdableItems[i].SetActive(true);
            }
        }

        //if wand activate hotbar
        if (currentHandItem == holdableItems[1])
        {
            uiManager.hotbar.SetActive(true);
        } else
        {
            uiManager.hotbar.SetActive(false);
        }
    }


    #endregion
}
