using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSoldat : MonoBehaviour
{
    #region Variables
    [Header("Competences de l'unite")]

    [Tooltip("Degats inflige")]
    [SerializeField] protected int damage = 4;

    [Tooltip("Points de vie")]
    [SerializeField] protected int life = 100;

    [Tooltip("Cout d'achat")]
    [SerializeField] protected int buyCost = 10;

    [Tooltip("Cout de revente")]
    [SerializeField] protected int sellCost = 5;

    [Tooltip("Cout quand on la tue")]
    [SerializeField] protected int defeatCost = 15;

    [Tooltip("XP quand on la tue")]
    [SerializeField] protected int deafeatXp = 10;

    [Tooltip("L'epoque actuelle de la troupe")]
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
    #endregion


    protected virtual void Start()
    {
        // Calcul du cout de la troupe quand on la tue
        defeatCost = buyCost + (buyCost / 2);

        // Calcul du gain d'Xp de la troupe quand on la tue
        deafeatXp = Random.Range(10 * multEra, 50 * multEra);
    }

}