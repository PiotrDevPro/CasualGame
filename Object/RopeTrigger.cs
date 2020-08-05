using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTrigger : MonoBehaviour
{
    public static RopeTrigger manage;
    private GameObject _player;
    public bool RopeIsDetected = false;
    private void Awake()
    {
        manage = this;
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            Main.manage.isMove = false;
            RopeIsDetected = true;
            _player.GetComponentInChildren<Animator>().SetBool("Crouch", true);
            _player.GetComponentInChildren<Animator>().SetTrigger("Slash");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            RopeIsDetected = false;
            _player.GetComponent<Rigidbody>().isKinematic = false;
            Main.manage.isMove = true;
        }
    }

    void MoveUp()
    {
        Vector3 temp = Vector3.up;
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, _player.transform.position + temp, 1.8f * Time.deltaTime);
    }

    private void Update()
    {
        if (RopeIsDetected)
        {
            MoveUp();
            _player.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
