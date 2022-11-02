using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
  public int levelNum = 0;
    // Update is called once per frame
    void Update()
    {
      Debug.Log(levelNum);
    }

    public void IncreaseLevel(){
      levelNum += 1;
    }

    public void StartTheGame(){
      IncreaseLevel();
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame(){
      if(levelNum >= 3){
        Debug.Log("Game over");
      } else {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNum);
      }
    }
}
