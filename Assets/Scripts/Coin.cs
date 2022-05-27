using UnityEngine;

public class Coin : Pickup
{
    protected override bool OnCollect(Collider2D other)
    {
        var result = false;
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.IncrementCoins();
            result = true;
        }

        return result;
    }
}