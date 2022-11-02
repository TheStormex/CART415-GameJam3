using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  public StartGame increaseLvl;
    // Start is called before the first frame update
    void Start()
    {
      increaseLvl = FindObjectOfType<StartGame>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
      if(collision.gameObject.tag == "player"){
        //increaseLvl.IncreaseLevel();
        Invoke("CompleteLevel", 1f);
      }
    }

    private void CompleteLevel(){
      if(increaseLvl.levelNum >= 3){
        Debug.Log("Game over");
      } else {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    }
}
