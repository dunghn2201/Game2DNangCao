using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public gamemaster gm;
    public static bool pause = false;
    public GameObject pauseUI;
public Player player;
    // Use this for initialization
    void Start()
    {
         gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
               player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;

        }
if(player.ourHealth<=0){
    Debug.Log(player.ourHealth);
      pause =!false;
}
        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void resume()
    {
        pause = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         if (PlayerPrefs.GetInt("highscore") < gm.points)
            PlayerPrefs.SetInt("highscore", gm.points);
    }

    public void quit()
    {
        Application.Quit();
    }
}