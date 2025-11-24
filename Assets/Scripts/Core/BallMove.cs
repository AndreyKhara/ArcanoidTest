using UnityEngine;
using Zenject;

public class BallMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioSource audioSource;

    [Inject]
    private GameManager gameManager;

    private void Awake()
    {
        rb.velocity = new Vector2 (Random.Range(3f,10f), Random.Range(3f,10f) );       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lose"))
        {
            gameManager.EndGame(false);
            return;
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            collision.gameObject.GetComponent<IBlock>().TakeDamage();
            audioSource.Play();
        }
    
    }
}
