using UnityEngine;

public class OceanInfomation
{
    


    public int Fish
    {

        get 
        { 
            return fish; 
        }
        set
        {
            int previousFish = fish;
            fish = value;
            OceanManager.Instance.RenewFishScore();
            if (fish >= fishMax)
            {
                OceanManager.Instance.GameClear();
            }
            if (previousFish != fish) // 값이 변경되었을 때만 효과음 재생
            {
                OceanManager.Instance.PlayFishScoreSound(fish > previousFish);
            }
        }
    }//{ get { return fish; } set { fish = value; OceanManager.Instance.RenewFishScore(); } }
    private int fish;
    public int FishMax => fishMax;
    private int fishMax;

    public OceanInfomation()
    {
        fish = 0;
        fishMax = 300;
    }
}
