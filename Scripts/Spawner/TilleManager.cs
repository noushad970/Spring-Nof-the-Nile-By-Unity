using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilleManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            if(i == 0) 
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    
    void Update()
    {
        if(playerTransform.position.z - 60 > zSpawn-(numberOfTiles * tileLength)) 
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    //public void SpawnTile(int tileIndex)
    //{
    //    GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
    //    activeTiles.Add(go);    
    //    zSpawn += tileLength;
    //}
    public void SpawnTile(int tileIndex)
    {
        // Calculate the offset for spawning the tile to the left
        float xOffset = -3f; // Adjust the offset value as needed

        // Instantiate the tile with the offset
        GameObject go = Instantiate(tilePrefabs[tileIndex], new Vector3(xOffset, 0, zSpawn), Quaternion.identity);

        // Add the instantiated tile to the activeTiles list
        activeTiles.Add(go);

        // Update the zSpawn position for the next tile
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
