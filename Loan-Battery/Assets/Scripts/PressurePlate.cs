using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
  public GameObject door;
  public SpriteRenderer spriteRenderer;
  public Sprite plateDown;
  public Sprite plateUp;
  private BoxCollider2D plateColl;
  private Rigidbody2D plateRB;

  public AudioSource plateOn;
  public AudioSource plateOff;

  private bool doorOpen;
  private float doorX;
  private float doorY;
    // Start is called before the first frame update
    void Start()
    {
      plateColl = GetComponent<BoxCollider2D>();
      plateRB = GetComponent<Rigidbody2D>();
      doorY = door.transform.position.y;
      doorX = door.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
      if(doorOpen){
        door.transform.position = new Vector2(doorX, doorY + 5f);
      }
    }

    void OnCollisionEnter2D(Collision2D target){
      //touches corpse
      if(target.gameObject.tag == "corpse"){
        door.transform.position = new Vector2(doorX, doorY + 5f);
        spriteRenderer.sprite = plateDown;
        plateOn.Play();
        plateColl.enabled = false;
      }
      if(target.gameObject.tag == "player"){
        doorOpen = true;
        spriteRenderer.sprite = plateDown;
        plateOn.Play();
      }
    }
    //check when collisions stop (for interactions)
    void OnCollisionExit2D(Collision2D target){
      if(target.gameObject.tag == "player"){
        doorOpen = false;
        door.transform.position = new Vector2(doorX, doorY);
        spriteRenderer.sprite = plateUp;
        plateOff.Play();
      }
    }
}
