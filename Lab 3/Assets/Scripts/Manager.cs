using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject playerPrefab;
    private GameObject playerObject;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);

        if (playerPrefab)
            playerObject = Instantiate<GameObject>(playerPrefab, new Vector3(-9.28f, 1.39f, -10.63f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !playerObject)
            playerObject = Instantiate<GameObject>(playerPrefab, new Vector3(-9.28f, 1.39f, -10.63f), Quaternion.identity);

        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();

    }

    public void TogglePause() 
    {
        if (pauseMenu)
        {

            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0.0f : 1.0f;

        }
            
    }

    public void ExitScene() 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void RestartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
