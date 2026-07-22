using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Deplacement : MonoBehaviour
{
    [Header("Vitesse")]
    public float vitesseAvance = 10f;
    public float vitesseLaterale = 8f;

    private float _velocityY = 0f;

    [Header("Couloir")]

    public float limiteX = 5f;

    private float _inputX = 0f;

    private CharacterController _cc;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // nous donne les touche clavier touché a l'instant t
        var kb = Keyboard.current;

        if (kb != null)
        {
            //_inputX = (kb.dKey.isPressed || kb.rightArrowKey.isPressed ? 1f : 0f)
            //- (kb.qKey.isPressed || kb.leftArrowKey.isPressed ? 1f : 0f);

            // equivalent a 

            // si deplacement droite
            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed)
            {
                _inputX = 1f;
            }
            // si deplacement gauche
            else if (kb.qKey.isPressed || kb.leftArrowKey.isPressed)
            {
                _inputX = -1f;
            }
            else
            {
                _inputX = 0f;
            }

            Deplacer();


        }

    }

    void Deplacer()
    {
        // calcule le deplacment a faire
        float deplX = _inputX * vitesseLaterale * Time.deltaTime;

        // calcule le nouveau x
        float futureX = transform.position.x + deplX;

        // bloquer le joueur 

        float clapmedX = Mathf.Clamp(futureX, -limiteX, limiteX);

        float deltaX = clapmedX - transform.position.x;

        if (_cc.isGrounded) {
            _velocityY = -2f;
        }
        else
        {
            _velocityY -= 20 * Time.deltaTime;
        }
        _cc.Move(new Vector3(deltaX, 0f, vitesseAvance * Time.deltaTime));


    }
}
