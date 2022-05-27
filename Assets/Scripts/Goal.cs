using System.Linq;
using UnityEngine;

public class Goal : MonoBehaviour
{
    int target=-1;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    
    SpriteRenderer spriteRenderer;
    Wallet playerWallet;

    bool isUnlocked;

    private void Start()
    {
        if (target == -1)
        {
            target = FindObjectsOfType<Coin>().Count(pickup => pickup.enabled);
        }
    }

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        playerWallet = FindObjectOfType<Wallet>();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        if(playerWallet.GetCoins() >= target)
        {
            isUnlocked = true;
            spriteRenderer.color = unlockColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Complete the level if the player has enough coins
        if (other.GetComponent<Wallet>() == playerWallet)
        {
            if(isUnlocked) {
                LevelManager.Instance.NextLevel();
            }
        }
    }
}
