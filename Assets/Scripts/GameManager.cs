using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private string sceneToLoad;
    public bool enPausa;
    public GameObject panelPausa;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        PanelPausa();


    }

    public void BotonContinuar()
    {
        Time.timeScale = 1.0f;
        panelPausa.SetActive(false);
    }

    public void BotonSalir()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void PanelPausa()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.Confined;
            if (enPausa == false)
            {
                Time.timeScale = 0f;
                panelPausa.SetActive(true);
                enPausa = true;
            }
            else
            {
                Time.timeScale = 1f;
                panelPausa.SetActive(false);
                enPausa = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    public void BotonStart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void BotonFuera()
    {
        Application.Quit();
    }

    public void BotonInformacion()
    {
        SceneManager.LoadScene("Informacion");
    }

    public void BotonControls()
    {
        SceneManager.LoadScene("CONTROLS");
    }

    public void BotonVolver()
    {
        SceneManager.LoadScene("Inicio");
    }

}