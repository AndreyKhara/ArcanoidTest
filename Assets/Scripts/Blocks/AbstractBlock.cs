using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class AbstractBlock : MonoBehaviour, IBlock
{
    [SerializeField] private int AddScoreAmount = 1;

    [Inject]
    private GameManager gameManager;

    protected void Awake()
    {
        gameManager.AddBlock();
        Debug.Log("AddBlock");
    }
    public virtual void TakeDamage()
    {
       
    }

    public virtual void Death(){
        gameManager.AddScore(AddScoreAmount);
        Destroy(gameObject);
    }   
}
