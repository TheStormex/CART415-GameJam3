using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
  public PlayerMovement player;
  private bool panelInteract = false;
  public int playerCharges;
  private int panelCharges = 3;

    // Start is called before the first frame update
    void Start()
    {
      playerCharges = player.charges;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q") && panelInteract == true){
          if(playerCharges <= 2){
            player.charges += 1;
            panelCharges -= 1;
          } else {
            Debug.Log("Full of charges");
          }
          Debug.Log(player.charges);
          Debug.Log(panelCharges);
        }
        if(Input.GetKeyDown("e") && panelInteract == true){
          if(playerCharges >= 1){
            player.charges -= 1;
            panelCharges += 1;
          } else {
            Debug.Log("Out of charges");
          }
          Debug.Log(player.charges);
          Debug.Log(panelCharges);
        }
    }

    void OnTriggerEnter2D(Collider2D target){
      if(target.gameObject.tag == "player"){
        Debug.Log("contact");
        panelInteract = true;
      }
    }
    //check when collisions stop (for interactions)
    void OnTriggerExit2D(Collider2D target){
      if(target.gameObject.tag == "player"){
        Debug.Log("bye");
        panelInteract = false;
      }
    }
}
