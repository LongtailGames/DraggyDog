using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        LevelManager.Instance.ReloadLevel();    
    }
}
