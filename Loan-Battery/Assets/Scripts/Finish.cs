using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  public StartGame increaseLvl;
  private int lvlNum;

  public AudioSource victory;
  public AudioSource spawn;
    // Start is called before the first frame update
    void Start()
    {
      //lvlNum = increaseLvl.levelNum;
    }

    private void OnTriggerEnter2D(Collider2D collision){
      if(collision.gameObject.tag == "player"){
        victory.Play();
        //increaseLvl.IncreaseLevel();
        Invoke("CompleteLevel", 2f);
      }
    }

    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        spawn.Play();
    }
}
