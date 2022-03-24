using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    public Image petSprite;

    public void OnUpgradeClick()
    {
        GameManager.instance.TryUpgradePet();
    }




}
