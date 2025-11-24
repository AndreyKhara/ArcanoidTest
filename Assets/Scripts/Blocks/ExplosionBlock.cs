using UnityEngine;

public class ExplosionBlock : AbstractBlock
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float explosionRadius = 1.5f;
    [SerializeField] private LayerMask blockLayer; 

    public override void TakeDamage()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, blockLayer);

        foreach (var col in hits)
        {
            if (col.CompareTag("Block"))
            {
                IBlock block = col.GetComponent<IBlock>();
                block.Death();
            }
        }
        //Death();
    }
}
