using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;



public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject menuGameOver;

    private PlayerController playerControl;


    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        playerControl.MuerteJugador += ActivarMenu;

        menuGameOver.SetActive(false);

    }


    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BotonStart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void BotonInicio()
    {
        SceneManager.LoadScene("inicio");
    }


}
