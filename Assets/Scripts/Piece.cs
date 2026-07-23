using UnityEngine;

public class Piece : MonoBehaviour
{
    public float vitesseRotation = 150f;
    public AudioClip SonCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, vitesseRotation * Time.deltaTime, 0f, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision avec : " + other.gameObject.name + " |Tag : " + other.tag);
        if (!other.CompareTag("Player"))
        {
            return;
        }
        GameManager.instance.AjouterPoint();

        //jouer du son

        AudioSource.PlayClipAtPoint(SonCoin, transform.position);
        //detruire la piece

        Destroy(gameObject);
    }
}
