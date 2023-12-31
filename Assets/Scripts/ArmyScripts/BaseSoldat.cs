using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AIState
{
    Idle,
    Walk,
    Fight,
    LongFight,
    Die
}

public class BaseSoldat : MonoBehaviour
{
    #region Variables
    [Header("Competences de l'unite")]

    [Tooltip("Degats inflige")]
    [SerializeField] protected int damage = 4;

    [Tooltip("Points de vie")]
    [SerializeField] protected int life = 100;

    [Tooltip("Cout d'achat")]
    [SerializeField] public int buyCost = 10;

    [Tooltip("Cout de revente")]
    [SerializeField] protected int sellCost = 5;

    [Tooltip("Or re�u lorsqu'on le tue")]
    [SerializeField] protected int goldOnDie = 15;

    [Tooltip("XP quand on le tue")]
    [SerializeField] protected int deafeatXp = 10;

    [Tooltip("L'epoque actuelle du soldat")]
    [SerializeField] protected int actualEra = 1;

    [Tooltip("Multiplicateur d'XP avec l'epoque")]
    [SerializeField] protected int multEra = 1;

    [Tooltip("Vitesse de deplacement")]
    [SerializeField] protected float speed = 5f;

    [Tooltip("Distance d'engagement")]
    [SerializeField] protected float engageDist = 1f;

    [Tooltip("Temps de formation")]
    [SerializeField] protected float trainingTime = 2f;

    [Tooltip("Apparence selon l'epoque")]
    [SerializeField] protected GameObject[] skins = new GameObject[5];

    protected AIState soldierState;

    private GameManager GM;
    #endregion

    #region Built-in Methods
    protected virtual void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    protected virtual void Start()
    {
        // On defenie l'epoque dans laquelle le soldat se trouve
        multEra = GM.eraMult;

        // Calcul du cout de la troupe quand on la tue
        goldOnDie = buyCost + (buyCost / 2);

        // Calcul du gain d'Xp de la troupe quand on la tue
        deafeatXp = Random.Range(10 * multEra, 50 * multEra);
    }

    protected virtual void Update()
    {
        //ChangeState(soldierState);
    }
    #endregion


    #region Customs Methods
    /// <summary>
    /// Changement d'etat du soldat
    /// </summary>
    /// <param name="state"></param>
    protected virtual void ChangeState(AIState state)
    {
        // Idle
        if (state == AIState.Idle) Debug.Log("Idle State");

        // Walk
        if (state == AIState.Walk) Debug.Log("Walk State");

        // Fight
        if (state == AIState.Fight) Debug.Log("Fight State");

        // Die
        if (state == AIState.Die) DeadSoldier();
    }

    protected virtual void Movement()
    {
       // partie que Romain doit faire 
    }

    /// <summary>
    /// Action lors de la mort du soldat
    /// </summary>
    protected virtual void DeadSoldier()
    {
        // On donne de l'XP au joueur
        GM.playerXP += deafeatXp;

        // On donne de l'or au joueur
        GM.playerGold += goldOnDie;

        // On detruit le soldat
        Destroy(gameObject);
    }

    protected virtual void FightSoldier()
    {

    }
    #endregion
}