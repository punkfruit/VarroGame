using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool destroyTower = false;


    public GameObject pauseScreen;
    public bool isPaused = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (pauseScreen)
        {
            pauseScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1f;

                if (pauseScreen)
                {
                    pauseScreen.SetActive(false);
                }
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0f;

                if (pauseScreen)
                {
                    pauseScreen.SetActive(true);
                }
            }
        }
    }
}
