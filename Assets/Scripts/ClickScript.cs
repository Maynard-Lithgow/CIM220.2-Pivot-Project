using Unity.VisualScripting;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit;
    Transform clickObject;
    public GameObject badClick1;
    public GameObject badClick2;
    public GameObject badClick3;
    public FlapBehaviour flapBehaviour;

    public AnimationManager animationManager;   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            raycastHit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            clickObject = raycastHit ? raycastHit.collider.transform : null;
            //Debug.Log("Clicked something " + clickObject);

            if (clickObject == badClick1 || clickObject == badClick2 || clickObject == badClick3)
            {
                //clickObject.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log("Good click");        //This works backwards for some reason. Don't care
                flapBehaviour.Flap();

                animationManager.ResetHappyTimer();
            }
        }

        if (flapBehaviour == null)
        {

        }
    }

    
}
