using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {

    public GameObject ExplosionParticles;
    public Color FruitColor;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BOARD"))
        {
            var collisionPos = collision.contacts[0].point;

            //Spawn some particles
            var explosionParticles = Instantiate(ExplosionParticles);
            var explosionScript = explosionParticles.GetComponent<ExplosionParticles>();
            explosionScript.SetColor(FruitColor);
            explosionParticles.transform.position = collisionPos;

            //Leave a Splatter
            SplatterSystem.Instance.LeaveSplatter(collisionPos, FruitColor);

            SoundManager.Instance.PlaySquishSound();

            Destroy(gameObject);
        }
    }
}
