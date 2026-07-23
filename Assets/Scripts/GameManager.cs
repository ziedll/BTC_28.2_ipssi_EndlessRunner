using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //les emplacements des objets texte

    [Header("UI")]

    public TextMeshProUGUI textScore;

    public TextMeshProUGUI textScoreFinal;

    public GameObject panel;

    private bool _gameover = false;

    private int _score = 0;

    //permet d'initialiser la premiere et seule instance du game manager
    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //tester si le jeu est fini +
        if (_gameover && Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            //relancer le temps 
            Time.timeScale = 1f;
            //relancer le jeu

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AjouterPoint()
    {
        _score++;

        textScore.text = "Score :" + _score;


    }

    public void GameOver()
    {
        if (_gameover)
        {
            return;

        }
        _gameover = true;

        Time.timeScale = 0f;

        panel.SetActive(true);

        textScoreFinal.text = "Score Final : " + _score;

    }
}
