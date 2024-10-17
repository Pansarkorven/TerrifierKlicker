using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public CookieGameScript gameManager;

   public void SaveGame()
    {
     //   PlayerPrefs.SetFloat("Kills", gameManager.);
      //  PlayerPrefs.SetFloat("PassiveIncome", gameManager.);            
   //     PlayerPrefs.SetInt("UpgradesBought", gameManager.);

        PlayerPrefs.Save(); 
        Debug.Log("Game Saved!");

    }

    public void LoadGame()
    {
      
        {
        //    gameManager.currency = PlayerPrefs.GetFloat("Currency", 0); 
        //    gameManager.passiveIncome = PlayerPrefs.GetFloat("PassiveIncome", 1);
         //   gameManager.upgradesBought = PlayerPrefs.GetInt("UpgradesBought", 0);

            Debug.Log("Game Loaded!");
        }
    }


}

