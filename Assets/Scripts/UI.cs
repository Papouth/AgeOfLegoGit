using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private GameManager GM;
    private VisualElement root;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();

        root = GetComponent<UIDocument>().rootVisualElement;

        // Buy Menu
        root.Q<Button>("BuySoldier").clicked += () => SoldierMenu();
        root.Q<Button>("BuyTurret").clicked += () => TurretMenu();
        root.Q<Button>("SellTurret").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");
        root.Q<Button>("EmplacementTurret").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");
        root.Q<Button>("NewEra").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");

        // Era Power
        root.Q<Button>("UsePower").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");

        // Soldier Menu
        root.Q<Button>("ClassicSoldier").clicked += () => GM.BuyClassicSoldier();
        root.Q<Button>("DistanceSoldier").clicked += () => GM.BuyDistanceSoldier();
        root.Q<Button>("HeavySoldier").clicked += () => GM.BuyHeavySoldier();
        root.Q<Button>("Backward").clicked += () => Menu();

        // Turret Menu
        root.Q<Button>("TurretSmall").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");
        root.Q<Button>("TurretMedium").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");
        root.Q<Button>("TurretBig").clicked += () => Debug.Log("J'execute ma fonction relié au boutton ! ");
        root.Q<Button>("Backward2").clicked += () => Menu();
    }

    private void SoldierMenu()
    {
        // Action qui se passe lors d'un clic sur le soldat afin d'accéder au menu d'achat des soldats
        root.Q("BuyMenu").style.visibility = Visibility.Hidden;  
        root.Q("TurretMenu").style.visibility = Visibility.Hidden;  
        root.Q("SoldierMenu").style.visibility = Visibility.Visible;  
    }

    private void TurretMenu()
    {
        // Action qui se passe lors d'un clic sur la tourelle afin d'accéder au menu d'achat des tourelles
        root.Q("BuyMenu").style.visibility = Visibility.Hidden;
        root.Q("SoldierMenu").style.visibility = Visibility.Hidden;
        root.Q("TurretMenu").style.visibility = Visibility.Visible;
    }

    private void Menu()
    {
        // Action qui se passe lors d'un clic sur la flèche retour afin d'accéder au menu
        root.Q("BuyMenu").style.visibility = Visibility.Visible;
        root.Q("TurretMenu").style.visibility = Visibility.Hidden;
        root.Q("SoldierMenu").style.visibility = Visibility.Hidden;
    }
}