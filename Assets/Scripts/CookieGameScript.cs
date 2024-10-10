using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CookieGameScript : MonoBehaviour
{
    [SerializeField] int KillCount = 0;
    [SerializeField] int MoreKillsPerKlick = 1;
    [SerializeField] int KillsAddCost = 2;
    [SerializeField] int KillsEverGotten = 0;
    [SerializeField] int SoulCount = 0;
    [SerializeField] public int ClicksPerSoulCount = 10;
    [SerializeField] int Clicks = 0;
    [SerializeField] int MaxAmountOfSouls = 100;

    //[SerializeField] SkinManager skinManager;

    public bool EscOpen = false;

    public TMP_Text ShopKillsCost;
    public TMP_Text SoulText;
    public TMP_Text KillsPerClick;
    public TMP_Text killsEverGotten;


    [SerializeField] GameObject NoKills;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject ShopButton;
    [SerializeField] GameObject EscMenu;
    void Start()
    {
        SoulText.text = "Souls:" + SoulCount+ "/"+ MaxAmountOfSouls;
        EscOpen = false;
        killsEverGotten.text = "All Kills:" + KillsEverGotten;
    }

    public void OnKillsClick()
    {
        if (MoreKillsPerKlick > 1)
        {
            KillCount += MoreKillsPerKlick;
            KillsEverGotten += MoreKillsPerKlick;
            Clicks++;
        }
        else
        {
            KillCount++;
            KillsEverGotten++;
            Clicks++;
        }
        SoulText.text = "Souls:" + SoulCount + "/" + MaxAmountOfSouls;
        killsEverGotten.text = "All Kills:" + KillsEverGotten;

        if (SoulCount < MaxAmountOfSouls)
        {
            if (KillCount > ClicksPerSoulCount)
            {
                SoulCount++;
                KillCount = 0;
            }
        }
        //if (skinManager != null)
        //{
        //    skinManager.CheckForSkinUnlock(KillCount);
        //}
    }
    public void Update()
    {
        SoulText.text = "Souls:" + SoulCount + "/" + MaxAmountOfSouls;
        ShopKillsCost.text = KillsAddCost + "Souls";
        KillsPerClick.text = MoreKillsPerKlick + "Kills";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("EscPressed");
            if (EscOpen == false)
            {
                EscMenu.SetActive(true);
                EscOpen = true;
                Debug.Log("no");
            }
        }
    }
    public void OnShopClick()
    {
        Shop.SetActive(true);
        ShopButton.SetActive(false);
    }
    public void ShopButtonClose()
    {
        ShopButton.SetActive(true);
        Shop.SetActive(false);
    }
    public IEnumerator BuyButton()
    {
        if(SoulCount >= KillsAddCost)
        {
            SoulCount -= KillsAddCost;
            KillsAddCost++;
            MoreKillsPerKlick++;
        }
    else
        {
            NoKills.SetActive(true);
            yield return new WaitForSeconds(1);
            NoKills.SetActive(false);
        }
    }


    public void BuyButton1()
    {
        StartCoroutine(BuyButton());
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }
}
