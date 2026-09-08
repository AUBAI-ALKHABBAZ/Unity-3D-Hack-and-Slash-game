using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public class CharacterMovement : MonoBehaviour
{
    CharacterStats stats;

    private const bool V = true;

    // Start is called before the first frame update
    Animator anim;
    // define public var call speed 
    public float speed = 5;
    public bool ColliderEnable = true;
    // define public var call Controller
    CharacterController Controller;
    // define var for camera 
    Transform cam;
    // define value for jump 
    float gravity = 10;
    float verticalVelocity = 0;
    public float jumpValue = 8;
    void Start()

    {
        // use func (GetComponent<>()) on the Component (CharacterController) and return result to  public var (Controller) 

        Controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        // use GetComponentInChildren to get the Animator component from player object  (player=>GFX(Anim))
        anim = GetComponentInChildren<Animator>();

        stats = GetComponent<CharacterStats>();

    }

    // Update is called once per frame
    void Update()
    {
        // Controller.Move is a func from class Controller (input (Vector3  {x,y,z} * some of delay between frames)
        // .Move is a func to move the charachter or the object for example  =>> Vector3(1, 0, 0) =>> move it on x Coordinate
        //Controller.Move(new Vector3(1, 0, 0) * Time.deltaTime); 


        // use API public static float GetAxis(string axisName); to use keyboard for movement
        // get global Coordinate Axis
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        // check if the player press Left Shift key to run 
        bool isSprint = Input.GetKey(KeyCode.LeftShift);
        // condation to set value of speed 
        float sprint = isSprint ? 2.5f : 1;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Attack_2");
        }

        // vector 3    (x,y,z)
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        // Speed paramter in Animaton for speed =0 or 0.5 or 1 
        anim.SetFloat("Speed", Mathf.Clamp(moveDirection.magnitude, 0, 0.5f) + (isSprint ? 0.5f : 0));
        // Controller.isGrounded check if the player on the ground or not
        // this will allow player to jump once 
        if (Controller.isGrounded)
        {
            // jump is space key on the keyboard
            // if the player press space key
            if (Input.GetAxis("Jump") > 0)
                // apply this var on y axis 
                verticalVelocity = jumpValue;

        }
        else
            // -=  for minimize value depends on time of frame 
            verticalVelocity -= gravity * Time.deltaTime;

        // get length of the vector
        if (moveDirection.magnitude > 0.1f) {
            // get move dependes on raduis of camera
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //Debug.Log(angle);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        // transformdirection to global cor
        moveDirection = cam.TransformDirection(moveDirection);
        // apply gravite on y axis by negative value for y gravity =-10
        //moveDirection = new Vector3(moveDirection.x, gravity,moveDirection.z);

        // apply gravite when player jump 
        moveDirection = new Vector3(moveDirection.x * speed * sprint, verticalVelocity, moveDirection.z * speed * sprint);
        /* Description :
        Returns the value of the virtual axis identified by axisName
            The value will be in the range -1...1 for keyboard and joystick input devices.
        */

        //Controller.Move(new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed);
        Controller.Move(moveDirection * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            //Debug.Log("Health Increased !");
            GetComponent<CharacterStats>().ChangeHealth(20);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Item"))
        {
            LevelManager.instance.LevelItems++;
            Debug.Log("LevelItems Increased  = "+ LevelManager.instance.LevelItems);
            LevelManager.instance.MainCanvas.Find("PanelStats").Find("TxtItem").GetComponent<TextMeshProUGUI>().text = string.Format("Item : {0:0.##}", LevelManager.instance.LevelItems);
            Destroy(other.gameObject);
        }
    }
    public void DoAttack()
    { 
        transform.Find("Collider").GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(HideCollider());
    }
    IEnumerator HideCollider()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("Collider").GetComponent<BoxCollider>().enabled = false;
    }
}
