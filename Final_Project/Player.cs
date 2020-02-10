using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour, IPunObservable
{
    private Vector3 _WantedPosition;
    private Quaternion _WantedRotation;

    public float health = 1.0f;
    public bool engine;

    public GameObject[] engineEffects;


    public void SetEffects(bool active)
    {
        foreach (GameObject effect in engineEffects)
        {
            effect.SetActive(active);
        } 
    }

    [PunRPC]
    public void TakeDamage( float dmg, PhotonPlayer player )
    {
        if (health <= 0f)
            return;

        health -= dmg;

        if (health <= 0f)
        {
            player.AddScore(1);

            Destroy(gameObject, 1f);

            FindObjectOfType<GameManager>().Respawn();
        }
    }

    private void OnDestroy()
    {
        if (photonView.isMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(engine);
            stream.SendNext(health);
        }
        else
        {
            _WantedPosition = (Vector3)stream.ReceiveNext();
            _WantedRotation = (Quaternion)stream.ReceiveNext();
            engine = (bool)stream.ReceiveNext();
            health = (float)stream.ReceiveNext();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.isMine)
        {
            gameObject.layer = LayerMask.NameToLayer("localplayer");

            Destroy(GetComponent<BoxCollider>());
        }
        else
        {
            Destroy(GetComponent<CharacterController>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine)
        {
            float speed = 3f;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            CharacterController characterController = GetComponent<CharacterController>();

            Vector3 forward = new Vector3(horizontal, 0, vertical);

            characterController.SimpleMove(forward * speed);

            if (forward.magnitude > Mathf.Epsilon)
            {
                engine = true;

                _WantedRotation = Quaternion.LookRotation(forward);
            }
            else
            {
                engine = false;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _WantedRotation, Time.deltaTime * 2f);


            Vector3 cameraPos = Camera.main.transform.position;

            cameraPos.x = transform.position.x;

            Camera.main.transform.position = cameraPos;

            Camera.main.transform.LookAt(transform);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _WantedPosition, Time.deltaTime * 2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, _WantedRotation, Time.deltaTime * 2f);
        }



        SetEffects(engine);
    }
}
