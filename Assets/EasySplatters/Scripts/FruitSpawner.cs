using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public static FruitSpawner Instance;

    public Sprite[] FruitSprites;
    public Color[] FruitColors;
    public GameObject FruitPrefab;


    void Awake()
    {
        Instance = this;
    }

    public GameObject SpawnFruit()
    {
        var newFruit = Instantiate(FruitPrefab);

        var index = Random.Range(0, FruitSprites.Length);
        newFruit.GetComponent<SpriteRenderer>().sprite = FruitSprites[index];
        newFruit.GetComponent<Fruit>().FruitColor = FruitColors[index];

        return newFruit;
    }
}
