using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroController : MonoBehaviour
{
    public gameManager _gameManager;
    public Camera _camera;

    public bool battleTime;
    public GameObject heroBattlePos;

    public Slider slider;
    public GameObject battleArena;

    private void Start()
    {
        float fark = Vector3.Distance(transform.position, battleArena.transform.position);

        slider.maxValue = fark;
    }
    private void FixedUpdate()
    {
        if(!battleTime)
        transform.Translate(Vector3.forward*.5f*Time.deltaTime);
    } //düz yürüme

    private void Update()
    {

        

        if (battleTime)
        {
            transform.position = Vector3.Lerp(transform.position, heroBattlePos.transform.position, .025f);

        }
        else
        {
            float fark = Vector3.Distance(transform.position, battleArena.transform.position);
            slider.value = fark;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }
            }
        }

        
    } //sað sol hareketleri

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("add")|| other.CompareTag("multiplication") || other.CompareTag("division") || other.CompareTag("extraction") )
        {
            int number = int.Parse(other.name);
            _gameManager.heroControl(other.tag, number, other.transform);
        }
        else if (other.CompareTag("battleScene"))
        {
            _camera.GetComponent<cameraController>().battleTime = true;
            _gameManager.enemyAttack();
            battleTime=true;
        }
    }
}
