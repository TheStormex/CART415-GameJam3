using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
  public PlayerMovement player;
  public SpriteRenderer spriteRenderer;
  public Sprite panel1;
  public Sprite panel2;
  public Sprite panel3;
  private bool panelInteract = false;
  public int playerCharges;
  private int panelCharges = 1;

    // Start is called before the first frame update
    void Start()
    {
      playerCharges = player.charges;
    }

    // Update is called once per frame
    void Update()
    {
      //take a charge from the panel
      if(Input.GetKeyDown("q") && panelInteract == true){
        if(player.charges <= 2 && panelCharges >= 1){
          player.charges += 1;
          panelCharges -= 1;
        } else if(panelCharges <= 0) {
          Debug.Log("No Charges left");
        } else if(player.charges >= 3){
          Debug.Log("Full of charges");
        }
      }
      //give the panel a charge
      if(Input.GetKeyDown("e") && panelInteract == true){
        if(player.charges >= 1 && panelCharges <= 2){
          player.charges -= 1;
          panelCharges += 1;
        } else if(panelCharges >= 3) {
          Debug.Log("Panel full");
        } else if(player.charges <= 0){
          Debug.Log("No charges left");
        }
      }

      switch(panelCharges){
        case 1: spriteRenderer.sprite = panel1;
        break;
        case 2: spriteRenderer.sprite = panel2;
        break;
        case 3: spriteRenderer.sprite = panel3;
        break;
      }
    }

    void OnTriggerEnter2D(Collider2D target){
      if(target.gameObject.tag == "player"){
        panelInteract = true;
      }
    }
    //check when collisions stop (for interactions)
    void OnTriggerExit2D(Collider2D target){
      if(target.gameObject.tag == "player"){
        panelInteract = false;
      }
    }
}
