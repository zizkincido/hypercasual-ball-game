using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public Transform Player;
    public Transform path;
    private Transform lastChild;
    private Transform last2Child;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        path = GameObject.FindWithTag("path").transform;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("obstacle"))
        {   
            for (int i = 1; i <= 1; i++)
            {
                lastChild = Player.transform.GetChild(Player.transform.childCount - i);
                Destroy(lastChild.gameObject);
            }   
            Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-0.5f,Player.transform.position.z);
        }
        if(other.CompareTag("obstacle2"))
        {   
            for (int i = 1; i <= 2; i++)
            {
                lastChild = Player.transform.GetChild(Player.transform.childCount - i);
                Destroy(lastChild.gameObject);
            }
            Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-0.65f,Player.transform.position.z);
        }
        if(other.CompareTag("obstacle3"))
        {   
            for (int i = 1; i <= 3; i++)
            {
                lastChild = Player.transform.GetChild(Player.transform.childCount - i);
                Destroy(lastChild.gameObject);
            }
            Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-0.76f,Player.transform.position.z);
        }
        if(other.CompareTag("obstacle4"))
        {   
            for (int i = 1; i <= 4; i++)
            {
                lastChild = Player.transform.GetChild(Player.transform.childCount - i);
                Destroy(lastChild.gameObject);
            }
            Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-0.79f,Player.transform.position.z);
        }
        if(other.CompareTag("obstacle5"))
        {   
            for (int i = 1; i <= 5; i++)
            {
                lastChild = Player.transform.GetChild(Player.transform.childCount - i);
                Destroy(lastChild.gameObject);
            }
            Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-0.81f,Player.transform.position.z);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle"))
        {   
            if(Player.transform.childCount <= 1)
            {
            Player.gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }
        }
        if(other.CompareTag("obstacle2"))
        {   
            if(Player.transform.childCount <= 2)
            {
            Player.gameObject.SetActive(false);
            MenuController.MenuControllerInstance.GameState = false;
            }
        }
        
        
        if(other.CompareTag("point"))
        {
            other.transform.parent = Player;
            lastChild = Player.transform.GetChild(Player.transform.childCount - 1);
            last2Child = Player.transform.GetChild(Player.transform.childCount - 2);
            if(Player.transform.childCount == 2)
            {
            Player.transform.position = new Vector3(Player.transform.position.x,(path.transform.position.y+6.0f)+(Player.transform.childCount*1.0f),Player.transform.position.z);
            last2Child.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-((Player.transform.childCount-1)*1.5f),Player.transform.position.z);
            lastChild.transform.position = new Vector3(Player.transform.position.x,last2Child.transform.position.y-((Player.transform.childCount-1)*1.0f),Player.transform.position.z);
            }
            else 
            {
                Player.transform.position = new Vector3(Player.transform.position.x,(path.transform.position.y+6.0f)+(Player.transform.childCount*1.0f),Player.transform.position.z);
                lastChild.transform.position = new Vector3(Player.transform.position.x,last2Child.transform.position.y-1.0f,Player.transform.position.z);
            }
        }
    }
}
