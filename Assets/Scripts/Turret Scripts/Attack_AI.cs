using UnityEngine;
using System.Collections;

public class Attack_AI : MonoBehaviour {
    public GameObject Projectile;
    public GameObject Firing_Point;
    public float Projectile_Velocity = 10000;
    public Vector3 Projectile_Launch_Position;
    public float fireRate = 1.0f;
    private float lastShot = 0.0f;

    public int CloseRangeValue = 10;
    public int MediumRangeValue = 20;
    public int LongRangeValue = 30;

    public GameObject[] Enemies;
    public ArrayList CloseRangeEnemies = new ArrayList();
    public ArrayList MediumRangeEnemies = new ArrayList();
    public ArrayList LongRangeEnemies = new ArrayList();

    public int ShortRangeEnemiesCount;
    public int MediumRangeEnemiesCount;
    public int LongRangeEnemiesCount;

    public GameObject TargetObject;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        EstablishTarget();

    }

    ArrayList FindEnemies()
    {
        CloseRangeEnemies.Clear(); MediumRangeEnemies.Clear(); LongRangeEnemies.Clear();


        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject GO in Enemies)
        {
            float Target_Range = Vector3.Distance(transform.position, GO.transform.position);

            if (Target_Range < CloseRangeValue) { CloseRangeEnemies.Add(GO); Debug.Log(Target_Range); }
            else if (Target_Range < MediumRangeValue) { MediumRangeEnemies.Add(GO); Debug.Log(Target_Range); }
            else if (Target_Range < LongRangeValue) { LongRangeEnemies.Add(GO); Debug.Log(Target_Range); }
        }

        // UPDATES COUNTS OF ENEMIES AT RANGES
        ShortRangeEnemiesCount = CloseRangeEnemies.Count;
        MediumRangeEnemiesCount = MediumRangeEnemies.Count;
        LongRangeEnemiesCount = LongRangeEnemies.Count;

        ArrayList PrioritizedEnemies = new ArrayList();
        PrioritizedEnemies.AddRange(CloseRangeEnemies);
        PrioritizedEnemies.AddRange(MediumRangeEnemies);
        PrioritizedEnemies.AddRange(LongRangeEnemies);

        return PrioritizedEnemies;
    }

    void EstablishTarget()
    {
        FireWeapons(FindEnemies());   
    }
    
    // WORKING ON THE FIRING AND CYCLING THROUGH ENEMIES
    void FireWeapons(ArrayList TargetList)
    {
        foreach (GameObject GO in TargetList)
        {
            if (GO != null)
            {
                Vector3 TargetVector = GO.transform.position - transform.position;
                float Target_Range = Vector3.Distance(transform.position, GO.transform.position);

                if (Time.time > fireRate + lastShot)
                {
                    Projectile_Launch_Position = Firing_Point.transform.position;
                    //Projectile_Launch_Position = new Vector3(Projectile_Launch_Position.x, Projectile_Launch_Position.y + (Random.Range(-5f,5f)), Projectile_Launch_Position.z);
                    GameObject bPrefab = Instantiate(Projectile, Projectile_Launch_Position, Quaternion.identity) as GameObject;
                    bPrefab.GetComponent<Rigidbody>().AddForce(TargetVector * (10 * Target_Range));

                    lastShot = Time.time;
                }
            }
        }

    }
}
