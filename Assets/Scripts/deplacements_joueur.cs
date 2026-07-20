using UnityEngine;

using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Deplacement : MonoBehaviour

{

    public float vitesseAvance = 10f;
    public float vitesseLaterale = 8f;

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
        var kb = Keyboard.current;

        if(kb != null)
        {
            //_inputX = (kb.dKey.isPressed || kb.rightArrowKey.isPressed ? 1f : 0f)
                {
                input_X = 1f;
            }
        else
            {
                _inputX = 0f;
            }
        if (kb.qKey.isPressed || kb.leftArrowKey.isPressed)
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
        float deplX = _inputX * vitesseLaterale * Time.deltaTime;

        float futureX = transform.position.x + deplX;

        float calpmedX = Mathf.Clamp(futureX, -limiteX, limiteX);
    }

}

