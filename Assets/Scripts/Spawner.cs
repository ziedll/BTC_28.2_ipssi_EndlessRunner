using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject prefabPiece;
    public GameObject prefabObstacle;

    [Header("Parametres du spawn")]

    public float distanceCreation = 40f;

    public float espacement = 8f;

    public float largeurCouloir = 4f;

    private Transform _joueur;

    private float _prochainZ = 20f;

    private float _ObstacleprochainZ = 40f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //recuperer la reference de l'objet joueur (pour utiliser sa position plus tard)
        _joueur = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //des que le joueur se rapproche de la distance de creation --> on spawn
        if(_joueur.position.z + distanceCreation >= _prochainZ)
        {
            Spawn();

            _prochainZ += espacement;
        }
        if (_joueur.position.z + distanceCreation >= _ObstacleprochainZ)
        {
            SpawnObstacle();

            _ObstacleprochainZ += espacement;
        }
    }

    void Spawn()
    {
        //choisir un x aleatorie dans la limite du couloir 

        float x = Random.Range(-largeurCouloir, largeurCouloir);

        //spawner la piece

        Instantiate(prefabPiece, new Vector3(x, 1.5f, _prochainZ), Quaternion.Euler(90f, 0f, 0f));
    }
    void SpawnObstacle()
    {
        //choisir un x aleatorie dans la limite du couloir 

        float x = Random.Range(-largeurCouloir +1 , largeurCouloir -1);

        //spawner la piece

        Instantiate(prefabObstacle, new Vector3(x, 1f, _ObstacleprochainZ), Quaternion.Euler(0f, 0f, 0f));
    }
}
