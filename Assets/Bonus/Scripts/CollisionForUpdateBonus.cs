using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForUpdateBonus : MonoBehaviour
{
    private PlayerInputControl _player;
    private int curr_player_type;

    public Mesh upgradeMesh_1;
    public Material upgradeMaterial_1;
    public Mesh upgradeMesh_2;
    public Material upgradeMaterial_2;

    void OnTriggerEnter(Collider other)
    {
//        Debug.Log(" i have detected the collision ");
        // if (other.name.Equals("player"))
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject playerObject =
                GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                _player = playerObject.GetComponent<PlayerInputControl>();
            }

            if (playerObject == null)
            {
                Debug.Log("Cannot find 'player' script");
            }

            Destroy(this.gameObject);

            // change the type of the spaceship of player
            curr_player_type = _player.getPlayer_type();

            if (curr_player_type == 0)
            {
                _player.GetComponent<MeshFilter>().mesh = upgradeMesh_1;
                _player.GetComponent<Renderer>().material = upgradeMaterial_1;
                _player.setPlayer_type(1);
            }

            if (curr_player_type == 1)
            {
                _player.GetComponent<MeshFilter>().mesh = upgradeMesh_2;
                _player.GetComponent<Renderer>().material = upgradeMaterial_2;
                _player.setPlayer_type(2);
            }
        }
    }
}