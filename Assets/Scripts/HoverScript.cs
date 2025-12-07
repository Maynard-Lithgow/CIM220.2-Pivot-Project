using UnityEngine;

public class HoverScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit;
    Transform prevHoverObject, nextHoverObject;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit ? raycastHit.collider.transform : null;

        if (nextHoverObject)
        {
            //nextHoverObject.GetComponent<SpriteRenderer>().color = Color.green;
            //Debug.Log("Hovering over " +  nextHoverObject.name);

            if (prevHoverObject && nextHoverObject && prevHoverObject.GetInstanceID() != nextHoverObject.GetInstanceID())
            {
                //prevHoverObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            if (prevHoverObject)
            {
                //prevHoverObject.GetComponent <SpriteRenderer>().color = Color.white;
            }
        }

    }

    
}
