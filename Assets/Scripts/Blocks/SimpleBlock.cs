using UnityEngine;


public class SimpleBlock : AbstractBlock
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int amountHealth = 1;
    [SerializeField] private Sprite[] sprites;

    public override void TakeDamage()
    {
        if (amountHealth == 1)
        {
            Death();
        }
        else
        {
            amountHealth--;
            if (sprites[amountHealth-1] != null)
            {
                spriteRenderer.sprite = sprites[amountHealth-1];
            }
        }
    }

   
}
