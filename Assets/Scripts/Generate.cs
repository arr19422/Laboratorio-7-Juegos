using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generate : MonoBehaviour
{

    public GameObject spherePrefab;
    private GameObject newSphere;
    public GameObject pauseMenu;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        newSphere = Instantiate(spherePrefab, new Vector3(-7.5f, 2, -7), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            generateShepre();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void generateShepre()
    {
        if (!newSphere)
        {
            newSphere = Instantiate(spherePrefab, new Vector3(-7.5f, 2, -7), Quaternion.identity);
        }

    }

    public void TogglePause()
    {
        if (pauseMenu)
        {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                isPaused = !isPaused;
                Time.timeScale = isPaused ? 0.0f: 1.0f;
        }
    }

    public void ChangeScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

}
