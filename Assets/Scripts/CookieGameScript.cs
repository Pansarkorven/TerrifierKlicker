using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CookieGameScript : MonoBehaviour
{
    [SerializeField] int KillCount = 0;
    [SerializeField] int MoreKillsPerKlick = 1;
    [SerializeField] int KillsAddCost = 1;

    public bool EscOpen = false;

    public TMP_Text ShopKillsCost;
    public TMP_Text KillsText;
    public TMP_Text KillsPerClick;


    [SerializeField] GameObject NoKills;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject ShopButton;
    [SerializeField] GameObject EscMenu;
    void Start()
    {
        KillsText.text = "Kills:" + KillCount;
        EscOpen = false;
    }

    public void OnKillsClick()
    {

        if (MoreKillsPerKlick > 1)
        {
            KillCount += MoreKillsPerKlick;
        }
        else
        {
            KillCount++;
        }
        KillsText.text = "Kills:" + KillCount;
    }
    public void Update()
    {
        KillsText.text = "Kills:" + KillCount;
        ShopKillsCost.text = KillsAddCost + "Kills";
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
        if(KillCount >= KillsAddCost)
        {
          
            KillCount -= KillsAddCost;
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
