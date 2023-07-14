using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public int playerGold;
    public int playerXP;
    public int enemyBaseLife;
    public int playerBaseLife;
    public int actualEra;
    [HideInInspector] public int eraMult;

    [Header("Bases")]
    [SerializeField] private GameObject friendlyBase;
    [SerializeField] private GameObject enemyBase;

    [Header("Soldats Disponible")]
    [SerializeField] private GameObject classicSoldier;
    [SerializeField] private GameObject distanceSoldier;
    [SerializeField] private GameObject heavySoldier;

    private Soldier soldierScript;
    private Distance distanceScript;
    private Heavy heavyScript;
    #endregion

    #region Built-In Methods
    private void Awake()
    {
        // On recupere la vie des deux bases
        playerBaseLife = friendlyBase.GetComponent<FriendlyBase>().friendlyBaseLife;
        enemyBaseLife = enemyBase.GetComponent<EnemyBase>().enemyBaseLife;

        // On recupere les differents scripts des soldats
        soldierScript = classicSoldier.GetComponent<Soldier>();
        distanceScript = distanceSoldier.GetComponent<Distance>();
        heavyScript = heavySoldier.GetComponent<Heavy>();
    }

    private void Start()
    {
        #region Initialisation de la partie
        // On donne 125 gold au start de la partie au joueur
        playerGold = 125;

        // On set la vie des deux bases a 500 HP
        playerBaseLife = 500;
        enemyBaseLife = 500;

        // On met l'XP du joueur a 0 au start
        playerXP = 0;
        #endregion
    }

    private void Update()
    {
        PlayerDeFeat();
        PlayerVictory();

        PlayerInput();
        EraMultiplier();
    }
    #endregion

    #region Customs Methods

    private void PlayerInput()
    {
        #region Spawn Soldats
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerGold >= soldierScript.buyCost)
        {
            // On retire l'or correspondant au recrutement de la troupe
            playerGold -= soldierScript.buyCost;

            // On fait spawn un soldat classique
            Debug.Log("spawn soldat classique");

            Instantiate(classicSoldier, friendlyBase.transform.position, classicSoldier.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && playerGold < soldierScript.buyCost) Debug.Log("Pas assez d'or ! ");



        if (Input.GetKeyDown(KeyCode.Alpha2) && playerGold >= distanceScript.buyCost)
        {
            // On retire l'or correspondant au recrutement de la troupe
            playerGold -= distanceScript.buyCost;

            // On fait spawn un soldat distance
            Debug.Log("spawn soldat distance");

            Instantiate(distanceSoldier, friendlyBase.transform.position, distanceSoldier.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && playerGold < distanceScript.buyCost) Debug.Log("Pas assez d'or ! ");



        if (Input.GetKeyDown(KeyCode.Alpha3) && playerGold >= heavyScript.buyCost)
        {
            // On retire l'or correspondant au recrutement de la troupe
            playerGold -= heavyScript.buyCost;

            // On fait spawn un soldat heavy
            Debug.Log("spawn soldat heavy");

            Instantiate(heavySoldier, friendlyBase.transform.position, heavySoldier.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && playerGold < heavyScript.buyCost) Debug.Log("Pas assez d'or ! ");
        #endregion
    }

    /// <summary>
    /// Sert a augmenter le drop d'or des troupes au fil des epoques
    /// </summary>
    private void EraMultiplier()
    {
        if (actualEra == 1) eraMult = 1;
        else if (actualEra == 2) eraMult = 2;
        else if (actualEra == 3) eraMult = 4;
        else if (actualEra == 4) eraMult = 8;
        else if (actualEra == 5) eraMult = 16;
    }

    #region Conditions Victoire/D�faite
    private void PlayerDeFeat()
    {
        if (playerBaseLife <= 0) Debug.Log("Vous avez perdu !");
    }

    private void PlayerVictory()
    {
        if (enemyBaseLife <= 0) Debug.Log("Vous avez gagn� !");
    }
    #endregion


    #endregion
}