using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Player;
    private Vector3 startMousePos, startPlayerPos;
    private bool moveThePlayer,gameState;
    private float velocity;
    [Range(0f,1f)]public float maxSpeed;
    private float camVelocity_x,camVelocity_y;
    [Range(0f,1f)]public float camSpeed;
    private Camera mainCam;
    public Transform path;
    [Range(0f,50f)]public float pathSpeed;
    private Rigidbody rb;
    public PointController PointControllerInstance;
    public Transform lastChild;
    
    void Start()
    {
        Player = transform;
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        
    
    }


    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetMouseButtonDown(0) && MenuController.MenuControllerInstance.GameState)
        {
            moveThePlayer = true;

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(newPlan.Raycast(ray,out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startPlayerPos = Player.position;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveThePlayer = false;
        }

        if(moveThePlayer)
        {

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(newPlan.Raycast(ray,out var distance))
                {
                    Vector3 mouseNewPos=ray.GetPoint(distance);
                    Vector3 MouseNewPos = mouseNewPos - startPlayerPos;
                    Vector3 DesirePlayerPos = MouseNewPos + startPlayerPos;
                    DesirePlayerPos.x = Mathf.Clamp(DesirePlayerPos.x,-4f,4f);
                    Player.position = new Vector3(Mathf.SmoothDamp(Player.position.x,DesirePlayerPos.x,ref velocity,maxSpeed),Player.position.y,Player.position.z);

                }
        }
        if (MenuController.MenuControllerInstance.GameState)
        {
            var pathNewPos = path.position;
            path.position = new Vector3(pathNewPos.x, pathNewPos.y, Mathf.MoveTowards(pathNewPos.z,-1000f,pathSpeed*Time.deltaTime));
        }   
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle"))
        {   
            if(Player.transform.childCount <= 1)
            {
            gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }
        }
        if(other.CompareTag("obstacle2"))
        {   
            if(Player.transform.childCount <= 2)
            {
            gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }         
        }
        if(other.CompareTag("obstacle3"))
        {   
            if(Player.transform.childCount <= 3)
            {
            gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }
        }
        if(other.CompareTag("obstacle4"))
        {   
            if(Player.transform.childCount <= 4)
            {
            gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }         
        }
        if(other.CompareTag("obstacle5"))
        {   
            if(Player.transform.childCount <= 5)
            {
            gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }         
        }
        if(other.CompareTag("point"))
        {
          other.transform.parent = Player;
          lastChild = Player.transform.GetChild(Player.transform.childCount - 1);
          if(Player.transform.childCount <= 1 )
            {
                Player.transform.position = new Vector3(Player.transform.position.x,(path.transform.position.y+6.0f)+(Player.transform.childCount*1.0f),Player.transform.position.z);
                lastChild.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y - 1.5f,Player.transform.position.z);
            }
        }
        
        
    }
   
        
        
    

    private void LateUpdate()
    {
        var CameraNewPos = mainCam.transform.position;
        if(rb.isKinematic)
        {
        mainCam.transform.position = new Vector3(Mathf.SmoothDamp(CameraNewPos.x,Player.transform.position.x+3.05f,ref camVelocity_x,camSpeed),CameraNewPos.y,CameraNewPos.z);
        }
    }
    
    
}
