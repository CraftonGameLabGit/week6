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
            if (previousFish != fish) // ���� ����Ǿ��� ���� ȿ���� ���
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
