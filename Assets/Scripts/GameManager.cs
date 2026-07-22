using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //les emplacements des objets texte

    [Header("UI")]

    public TextMeshProUGUI textScore;


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

    }
    public void AjouterPoint()
    {
        _score++;

        textScore.text = "Score :" + _score;


    }
}
