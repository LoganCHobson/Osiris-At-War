using UnityEngine;

public class GeneralShipController : BaseShipController
{
    public ShipStatsSO shipStats;

    public bool isSelected = false;

    
    protected override void Update()
    {
        if (isSelected)
        {
            base.Update();
        }
    }
}
