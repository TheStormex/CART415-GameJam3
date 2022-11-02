using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  private Rigidbody2D rb;
  private BoxCollider2D coll;
  private BoxCollider2D door;
  [SerializeField] private LayerMask jumpableGround;

  public GameObject bodyPrefab;
  private bool interactCorpse = false;
  private bool interactDoor = false;
  private int charges = 3;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float axisX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(axisX * 7f, rb.velocity.y);
      //player jumps
        if(Input.GetButtonDown("Jump") && IsGrounded()){
          rb.velocity = new Vector2(rb.velocity.x, 12f);
        }
      //create new Corpse
      if(Input.GetKeyDown("q") && charges >= 1){
        //finds player position
        float playerX = transform.position.x;
        float playerY = transform.position.y;
        //spawns body prefab in players position
        Instantiate(bodyPrefab, new Vector2(playerX, playerY), Quaternion.identity);
        //tps player to starting position
        transform.position = new Vector2(-17, -8);
        charges -= 1;
      } else if(Input.GetKeyDown("q") && charges <= 0){
        Debug.Log("no charges left");
      }
      //put charge in door to open it
      if(interactDoor == true && Input.GetKeyDown("e") && charges >=1){
        //removes charge and changes door to trigger so player can move through it
        charges -= 1;
        door.isTrigger = true;
      }
    }

    private bool IsGrounded(){
      //creates a box slightly below the player to detect if touching ground
      return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //check for any collisions
    void OnCollisionEnter2D(Collision2D target){
      //touches corpse
      if(target.gameObject.tag == "corpse"){
        interactCorpse = true;
      }
      //touches a door
      if(target.gameObject.tag == "door"){
        interactDoor = true;
        door = target.gameObject.GetComponent<BoxCollider2D>();
      }
    }
    //check when collisions stop (for interactions)
    void OnCollisionExit2D(Collision2D target){
      //leaves corpse
      if(target.gameObject.tag == "corpse"){
        interactCorpse = false;
      }
      //leaves a door
      if(target.gameObject.tag == "door"){
        interactDoor = false;
      }
    }
}
