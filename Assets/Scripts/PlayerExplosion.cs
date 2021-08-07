using UnityEngine;

// This is used to create the breaking explosion when player dies
// From this video: https://www.youtube.com/watch?v=s_v9JnTDCCY
public class PlayerExplosion : MonoBehaviour
{
    public string thisSceneName;

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.y < -10.0f)
        {
            // Reload the same level
            Initiate.Fade(thisSceneName, Color.black, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "Obstacle")
        {
            Explode();
            // Reload the same level
            Initiate.Fade(thisSceneName, Color.black, 0.5f);
        }

    }

    public void Explode()
    {
        // This disables the mesh renderer and makes cube invisible
        gameObject.GetComponent<Renderer>().enabled = false;

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void CreatePiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // Set the piece color to the player color
        piece.GetComponent<Renderer>().material.color = new Color(43f/255f, 43f/255f, 43f/255f);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

}