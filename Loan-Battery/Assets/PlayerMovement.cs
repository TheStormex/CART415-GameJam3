using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  private Rigidbody2D rb;
  public GameObject bodyPrefab;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float axisX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(axisX * 7f, rb.velocity.y);
      //uses unity input manager commands
        if(Input.GetButtonDown("Jump")){
          rb.velocity = new Vector2(rb.velocity.x, 18f);
        }

      if(Input.GetKeyDown("q")){
        float playerX = transform.position.x;
        float playerY = transform.position.y;

        Instantiate(bodyPrefab, new Vector2(playerX, playerY), Quaternion.identity);
        transform.position = new Vector2(-17, -8);
      }
    }
}
