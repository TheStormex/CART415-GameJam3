using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseControl : MonoBehaviour
{
  private Rigidbody2D rb;
  private bool interactOn = false;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(interactOn == true && Input.GetKeyDown("e")){
        Debug.Log("worked");
      }
    }

    //check for any collisions
    void OnCollisionEnter2D(Collision2D target){
      //when the corpse hits the floor, turn body to Static
      if(target.gameObject.tag == "floor"){
        rb.bodyType = RigidbodyType2D.Static;
      }
    }
}