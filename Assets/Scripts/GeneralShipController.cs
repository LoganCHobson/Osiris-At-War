using UnityEngine;

public class GeneralShipController : BaseShipController
{
    public ShipStatsSO shipStats;

    public bool isSelected = false;

    public string opposingTeam;

    public float range;
    
   
    protected override void Update()
    {
        if (isSelected)
        {
            base.Update();
        }
    }
}
