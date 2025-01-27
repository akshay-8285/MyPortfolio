using System;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 5;
    [SerializeField] private float cellSize = 1f;
    [SerializeField] private int level;

    [Header("Sprite Settings")]
    public GameObject spritePrefab;
    public float gapProbability = 0.2f; // Chance of a gap in each cell (0 to 1)

    public static Action<int, Action> OnStartGeneratingGrid;

    private void OnEnable()
    {
        OnStartGeneratingGrid += GenerateGrid;
    }
    
    private void OnDisable()
    {
        OnStartGeneratingGrid -= GenerateGrid;
    }

    private void Start()
    {
        GenerateGrid(level, null);
    }

    private void GenerateGrid(int level, Action action)
    {
        // Clear the existing grid
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Set a seed based on the level
        UnityEngine.Random.InitState(level);

        if (spritePrefab == null)
        {
            Debug.LogError("Sprite Prefab is not assigned!");
            return;
        }

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                // Determine if this cell should have a gap
                if (UnityEngine.Random.value < gapProbability)
                {
                    continue; // Skip this cell, leaving a gap
                }

                // Calculate the position for this cell
                Vector3 position = new Vector3(column * cellSize, row * cellSize, 0);

                // Instantiate the sprite at the calculated position
                Instantiate(spritePrefab, position, Quaternion.identity, transform);
            }
        }
    }


}
