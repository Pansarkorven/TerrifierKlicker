using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite skin0;
    public Sprite skin100;
    public Sprite skin500;
    public Sprite skin1000;
    public Image skinImage;

    private int currentSkinLevel = -1;

    void Start()
    {

    }

    
    public void CheckForSkinUnlock(int killsEverGotten)
    {
        
        if (killsEverGotten >= 1000 && currentSkinLevel < 3)
        {
            UnlockSkin(skin1000, 3); 
        }
        else if (killsEverGotten >= 500 && currentSkinLevel < 2)
        {
            UnlockSkin(skin500, 2); 
        }
        else if (killsEverGotten >= 100 && currentSkinLevel < 1)
        {
            UnlockSkin(skin100, 1); 
        }
        else if (killsEverGotten < 100 && currentSkinLevel != 0)
        {
            UnlockSkin(skin0, 0); 
        }
    }

    
    private void UnlockSkin(Sprite skin, int newSkinLevel)
    {
        if (skin != null && skinImage != null)
        {
            skinImage.sprite = skin;
            currentSkinLevel = newSkinLevel; 
            
        }

    }
}
