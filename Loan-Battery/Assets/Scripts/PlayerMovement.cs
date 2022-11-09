using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

  private Rigidbody2D rb;
  private BoxCollider2D coll;
  private BoxCollider2D door;
  private GameObject plate;
  [SerializeField] private LayerMask jumpableGround;

  public SpriteRenderer spriteRenderer;
  public Sprite kbotL;
  public Sprite kbotR;

  public GameObject bodyPrefab;
  public Text chargeTxt;
  private bool interactCorpse = false;
  private bool interactDoor = false;
  private bool interactPlate = false;
  public int charges = 3;
  public int respawns = 3;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //-------- PLAYER CONTROL -----------
      float axisX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(axisX * 7f, rb.velocity.y);
      if(Input.GetButtonDown("Jump") && IsGrounded()){
        rb.velocity = new Vector2(rb.velocity.x, 12f);
        GetComponent<AudioSource>().Play();
      }
      //-------- WALK CHANGE PIC -----------
      if(Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)){
        spriteRenderer.sprite = kbotL;
      } else if(Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)){
        spriteRenderer.sprite = kbotR;
      }
      //-------- CORPSE CONTROL ------------
      //create new Corpse
      if(Input.GetKeyDown("space") && respawns >= 1){
        //finds player position
        float playerX = transform.position.x;
        float playerY = transform.position.y;
        //spawns body prefab in players position
        Instantiate(bodyPrefab, new Vector2(playerX, playerY), Quaternion.identity);
        //tps player to starting position
        transform.position = new Vector2(-17, -8);
        charges = 3;
        respawns -= 1;
      } else if(Input.GetKeyDown("q") && respawns <= 0){
        Debug.Log("no respawns left");
      }
      //-------- DOOR INTERACTION ------------
      //put charge in door to open it
      if(interactDoor == true && Input.GetKeyDown("e") && charges >=1){
        //removes charge and changes door to trigger so player can move through it
        charges -= 1;
        door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 5f);
      }

      //change charge Text
      chargeTxt.text = charges + " Charges";
    }

    private bool IsGrounded(){
      //creates a box slightly below the player to detect if touching ground
      return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //check for any collisions
    void OnCollisionEnter2D(Collision2D target){
      //touches corpse
      switch(target.gameObject.tag){
        case "corpse": interactCorpse = true;
          break;
        case "door": interactDoor = true;
          door = target.gameObject.GetComponent<BoxCollider2D>();
          // string name = target.gameObject.name;
          // split = String.Split("_");
          break;
      }
    }
    //check when collisions stop (for interactions)
    void OnCollisionExit2D(Collision2D target){
      //leaves corpse
      switch(target.gameObject.tag){
        case "corpse": interactCorpse = false;
          break;
        case "door": interactDoor = false;
          break;
      }
    }
}
