using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject gameOverMenu;

    private void OnEnable()
    {
        GameManager.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerDeath -= EnableGameOverMenu;
    }
   public void EnableGameOverMenu()
   {
    gameOverMenu.SetActive(true);
   }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
