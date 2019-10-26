using UnityEngine;
using System.Collections;

public class PlayerInputControl : MonoBehaviour
{
    public int speed = 7;
    public float XBoundary = 10.0f;
    public float ZBoundary = 8.5f;
    public float yPosition = 10.0f;
    public float angle = 5f;

    // Type of shot
    public GameObject projectileTemplate;
    public GameObject basicProjectile; // bolt_type == 0
    public GameObject rocketProjectile; // bolt_type == 1
    public GameObject rayProjectile; // bolt_type == 2
    public GameObject lazerProjectile; // bolt_type == 3
    private bool isLazer = false;
    private GameObject projectile;

    // Position of shot spawn
    public GameObject positionP;
    public GameObject positionLazer;
    public GameObject positionP2_1;
    public GameObject positionP2_2;

    // bonus update
    private int player_type = 0; //机甲类型
    private int bolt_type = 0; // 子弹升级
    public GameObject protecter;

    // controller attributes
    private bool disableSpace = false;
    private GameController _gameController;
    private bool shooting_continue = false;
    private bool ready_shoot = false;
    private int start = 0;

    public GameObject shield;

    private int shieldFlashCount = 0;

    public Renderer renderer;

    // mesh and materials
    // level 1, player_type = 0
    public Mesh level1_ship_mesh;
    public Material level1_ship_material;
    public Material level1_ship_material_flash;

    // level 2, player_type = 1
    public Mesh level2_ship1_mesh;
    public Material level2_ship1_material;
    public Material level2_ship1_material_flash;

    public Mesh level2_ship2_mesh;
    public Material level2_ship2_material;
    public Material level2_ship2_material_flash;

    // level 3, player_type = 2
    public Mesh level3_ship1_mesh;
    public Material level3_ship1_material;
    public Material level3_ship1_material_flash;

    public Mesh level3_ship2_mesh;
    public Material level3_ship2_material;
    public Material level3_ship2_material_flash;

    public Mesh level3_ship3_mesh;
    public Material level3_ship3_material;
    public Material level3_ship3_material_flash;

    void Start()
    {
        SetMeshAndMaterial();

        bolt_type = 0;
        GameObject gameControllerObject =
            GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            _gameController =
                gameControllerObject.GetComponent<GameController>();
        }

        if (_gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        StartCoroutine(Interval());
    }

    private void SetMeshAndMaterial()
    {
        // set Mesh and Materials
        switch (StatusOfGame.shipType)
        {
            case 1:
                gameObject.GetComponent<MeshFilter>().mesh = level1_ship_mesh;
                gameObject.GetComponent<MeshRenderer>().material =
                    level1_ship_material;
                player_type = 0;

                renderer.material = level1_ship_material_flash;
                StartCoroutine(Wait(level1_ship_material));
                break;
            case 2:
                gameObject.GetComponent<MeshFilter>().mesh = level2_ship1_mesh;
                gameObject.GetComponent<MeshRenderer>().material =
                    level2_ship1_material;
                player_type = 1;

                renderer.material = level2_ship1_material_flash;
                StartCoroutine(Wait(level2_ship1_material));
                break;
            case 3:
                gameObject.GetComponent<MeshFilter>().mesh = level2_ship2_mesh;
                gameObject.GetComponent<MeshRenderer>().material =
                    level2_ship2_material;
                player_type = 1;

                renderer.material = level2_ship2_material_flash;
                StartCoroutine(Wait(level2_ship2_material));
                break;
            case 4:
                gameObject.GetComponent<MeshFilter>().mesh = level3_ship1_mesh;
                gameObject.GetComponent<MeshRenderer>().material =
                    level3_ship1_material;
                player_type = 2;

                renderer.material = level3_ship1_material_flash;
                StartCoroutine(Wait(level3_ship1_material));
                break;
            case 5:
                gameObject.GetComponent<MeshFilter>().mesh = level3_ship2_mesh;
                gameObject.GetComponent<MeshRenderer>().material =
                    level3_ship2_material;
                player_type = 2;

                renderer.material = level3_ship2_material_flash;
                StartCoroutine(Wait(level3_ship2_material));
                break;
            case 6:
                gameObject.GetComponent<MeshFilter>().mesh = level3_ship3_mesh;
                gameObject.GetComponent<MeshRenderer>().material =
                    level3_ship3_material;
                player_type = 2;

                renderer.material = level3_ship3_material_flash;
                StartCoroutine(Wait(level3_ship3_material));
                break;
        }
    }


    IEnumerator Wait(Material matDefault)
    {
        yield return new WaitForSecondsRealtime(3);
        renderer.material = matDefault;
    }

    // shooting interval
    IEnumerator Interval()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            ready_shoot = !ready_shoot;

            // automatically shoot
            if (shooting_continue && bolt_type != 3 && ready_shoot)
            {
                start = 0;

                GetProjectile();
                // 如果1个发射口
                if (this.player_type == 0)
                {
                    projectile = Instantiate(projectileTemplate,
                        positionP.transform.position,
                        positionP.transform.localRotation);
                    projectile.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                }
                else if (this.player_type == 1) // 两个发射口
                {
                    var projectile1 = Instantiate(projectileTemplate,
                        positionP2_1.transform.position,
                        positionP.transform.localRotation);
                    var projectile2 = Instantiate(projectileTemplate,
                        positionP2_2.transform.position,
                        positionP.transform.localRotation);
                    projectile1.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                    projectile2.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                }
                else // 三个发射口
                {
                    projectile = Instantiate(projectileTemplate,
                        positionP.transform.position,
                        positionP.transform.localRotation);
                    projectile.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                    var projectile1 = Instantiate(projectileTemplate,
                        positionP2_1.transform.position,
                        positionP.transform.localRotation);
                    var projectile2 = Instantiate(projectileTemplate,
                        positionP2_2.transform.position,
                        positionP.transform.localRotation);
                    projectile1.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                    projectile2.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                }

                isLazer = false;
            }
        }
    }

    void Update()
    {
        // press Space to shoot
        if (Input.GetKeyDown(KeyCode.Space) && disableSpace == false &&
            !shooting_continue)
        {
            GetProjectile();

            // projectile.transform.position = this.transform.position;
            // 如果是lazer，则没有移动，刚体无速度
            if (bolt_type != 3)
            {
                // 如果1个发射口
                if (this.player_type == 0)
                {
                    projectile = Instantiate(projectileTemplate,
                        positionP.transform.position,
                        positionP.transform.localRotation);
                    projectile.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                }
                else if (this.player_type == 1) // 两个发射口
                {
                    var projectile1 = Instantiate(projectileTemplate,
                        positionP2_1.transform.position,
                        positionP.transform.localRotation);
                    var projectile2 = Instantiate(projectileTemplate,
                        positionP2_2.transform.position,
                        positionP.transform.localRotation);
                    projectile1.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                    projectile2.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                }
                else // 三个发射口
                {
                    projectile = Instantiate(projectileTemplate,
                        positionP.transform.position,
                        positionP.transform.localRotation);
                    projectile.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                    var projectile1 = Instantiate(projectileTemplate,
                        positionP2_1.transform.position,
                        positionP.transform.localRotation);
                    var projectile2 = Instantiate(projectileTemplate,
                        positionP2_2.transform.position,
                        positionP.transform.localRotation);
                    projectile1.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                    projectile2.GetComponent<Rigidbody>().velocity =
                        Vector3.forward * speed;
                }

                isLazer = false;
            }
            else
            {
                Debug.Log("the value of start: " + start);
                if (start != 0)
                {
                    projectile.SetActive(true);
                }
                else
                {
                    start = 2;
                    projectile = Instantiate(projectileTemplate,
                        positionLazer.transform.position,
                        projectileTemplate.transform.localRotation);
                    projectile.SetActive(true);

                    isLazer = true;
                }
            }
        }

        if (shield.activeSelf && shieldFlashCount == 1)
        {
            StartCoroutine(shieldWait());
        }

        // power mode
        if (_gameController.getPowerMode())
        {
            if (!this.protecter.activeSelf
            ) // power mode -> check the protector first
            {
                this.protecter.SetActive(true);
            }
        }
        else if (this.protecter.activeSelf
        ) // run after getting the power(chaoren) bonus
        {
            _gameController.lock_HP();
            StartCoroutine(wait());
        }

        // shooting continuously
        if (Input.GetKey(KeyCode.Space))
        {
            if (bolt_type != 3)
            {
                shooting_continue = true;
            }
        }

        // stop shooting continuously
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (bolt_type == 3)
            {
                if (start != 2) shooting_continue = false;
                else projectile.SetActive(false);
            }
            else
            {
                shooting_continue = false;
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, -XBoundary,
                XBoundary),
            yPosition,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, -ZBoundary,
                ZBoundary)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f,
            GetComponent<Rigidbody>().velocity.x * -angle);
    }

    public int getPlayer_type()
    {
        return player_type;
    }

    public int getBolt_type()
    {
        return bolt_type;
    }

    public void setPlayer_type(int player_type)
    {
        this.player_type = player_type;
    }

    public void setBolt_type(int bolt_type)
    {
        this.bolt_type = bolt_type;
    }

    public void GetProjectile()
    {
        if (bolt_type == 0)
        {
            this.projectileTemplate = basicProjectile;
        }
        else if (bolt_type == 1)
        {
            this.projectileTemplate = rocketProjectile;
        }
        else if (bolt_type == 2)
        {
            this.projectileTemplate = rayProjectile;
        }
        else
        {
            this.projectileTemplate = lazerProjectile;
        }
    }

    public void enalbeSpace()
    {
        this.disableSpace = false;
    }

    public void destroyLazer()
    {
        this.isLazer = false;
        enalbeSpace();
        Destroy(this.projectile);
    }

    // locking health point for how long after getting the power bonus
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(10);
        _gameController.unLock_HP();
        this.protecter.SetActive(false);
    }

    IEnumerator shieldWait()
    {
        shieldFlashCount = 0;
        yield return new WaitForSecondsRealtime(0.2f);
        this.shield.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        this.shield.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        this.shield.SetActive(false);
    }

    public void setShieldCount()
    {
        shieldFlashCount = 1;
    }
}