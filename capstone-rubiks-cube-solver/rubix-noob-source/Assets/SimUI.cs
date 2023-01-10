using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimUI : MonoBehaviour
{

    public bool isShuffled = false;

    public void ExitSim() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Show() {
        Debug.Log("CLICKED SHOW");
        gameObject.SetActive(true);
    }

    public void Hide() {
        Debug.Log("CLICKED HIDE");
        gameObject.SetActive(false);
    }

    public void ChangeText() {
        if (isShuffled == true) {
            
        }
    }

    public void Toggle() {
        if (gameObject.activeSelf) {
            Hide();
        }
        else {
            Show();
        }
    }
}
