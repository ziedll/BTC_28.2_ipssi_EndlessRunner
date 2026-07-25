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

    public TextMeshProUGUI textMeilleurScore;

    public TextMeshProUGUI textMultiplicateur;

    public GameObject panel;

    public GameObject startPanel;


    private bool _gameover = false;

    private int _score = 0;

    private int _multiplicateur = 1;

    //permet d'initialiser la premiere et seule instance du game manager
    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }

        AffichageMultiplicateurMAJ();

        Time.timeScale = 0f;
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
        _score += (1*_multiplicateur);

        _multiplicateur++;

        textScore.text = "Score :" + _score;
        AffichageMultiplicateurMAJ();
    }
    public void ResetMultiplicateur()
    {
        _multiplicateur = 1;
        AffichageMultiplicateurMAJ();
    }
    private void AffichageMultiplicateurMAJ()
    {
        if (textMultiplicateur != null)
        {
            if(_multiplicateur > 1)
            {
                textMultiplicateur.gameObject.SetActive(true);
                textMultiplicateur.text = "Combo x" + _multiplicateur + "!";
            }
            else
            {
                textMultiplicateur.gameObject.SetActive(false);
            }
        }
    }
    //menu de démarrage
    public void GameStart()
    {
        if(startPanel != null)
        {
            startPanel.SetActive(false);
        }

        Time.timeScale = 1f;
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

        //ajout meilleur score
        int meilleurScoreSauvegarde = PlayerPrefs.GetInt("MeilleurScore", 0);

        if(_score> meilleurScoreSauvegarde)
        {
            meilleurScoreSauvegarde = _score;
            PlayerPrefs.SetInt("MeilleurScore", meilleurScoreSauvegarde);
            PlayerPrefs.Save();
        }

        textScoreFinal.text = "Score Final : " + _score;
        if (textMeilleurScore != null)
        {
            textMeilleurScore.text = "Meilleur Score : " + meilleurScoreSauvegarde;
        }
    }
}
