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

    public float espacementObstacleMin = 5f;
    public float espacementObstacleMax = 10f;
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
            float espacementAleatoire = Random.Range(espacementObstacleMin, espacementObstacleMax);
            _ObstacleprochainZ += espacementAleatoire;
        }
    }

    void Spawn()
    {
        float tiers = largeurCouloir / 3f;
        //choisir un x aleatorie dans la limite du couloir 

        //spawner la piece aléatoirement
        float xGauche = Random.Range(-largeurCouloir, -tiers);
        Instantiate(prefabPiece, new Vector3(xGauche, 1.5f, _prochainZ), Quaternion.Euler(90f, 0f, 0f));
        float xDroite = Random.Range(tiers, largeurCouloir);
        Instantiate(prefabPiece, new Vector3(xDroite, 1.5f, _prochainZ), Quaternion.Euler(90f, 0f, 0f));
        float xCentre = Random.Range(-tiers, tiers);
        Instantiate(prefabPiece, new Vector3(xCentre, 1.5f, _prochainZ), Quaternion.Euler(90f, 0f, 0f));

    }
    void SpawnObstacle()
    {
        //choisir un x aleatorie dans la limite du couloir 

        float x = Random.Range(-largeurCouloir +1 , largeurCouloir -1);

        //spawner la piece

        Instantiate(prefabObstacle, new Vector3(x, 1f, _ObstacleprochainZ), Quaternion.Euler(0f, 0f, 0f));
    }
}
