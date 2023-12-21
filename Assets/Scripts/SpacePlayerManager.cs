using UnityEngine;

public class SpacePlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            if(hit.collider.CompareTag("FriendlyPlanet"))
            {
                hit.collider.gameObject.GetComponent<PlanetManager>().planetInfoUI.SetActive(true);
                hit.collider.gameObject.GetComponent<PlanetManager>().UpdatePlanetInfo();
            }
        }

    }
}
