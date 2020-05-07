using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour {
    public void selectScene () {
        switch (this.gameObject.name) {
            case "Playbtn":
                SceneManager.LoadScene ("Level1");
                break;
            default:
                SceneManager.LoadScene ("Level1");
                break;
        }
    }
}