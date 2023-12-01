using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGen : MonoBehaviour
{
    public GameObject[] Unit = new GameObject[7];
    public bool Counting_time = true;
    public float timer = 90f;
    public int num = 5;
    public int MaxRoadNumber = 40;
    public int dis = 200;
    public float Offset_x, Offset_z, Offset_deg, Offset_corner;

    private List<int> Path = new List<int>();
    private List<int> Stack = new List<int>();
    private Queue<GameObject> visited = new Queue<GameObject>();
    private bool left = false, right = false;
    private int now = -1, past = -1;

    float detect()
    {
        GameObject Aim = GameObject.FindGameObjectWithTag("Player");
        float dis_x = Aim.transform.position.x - transform.position.x, dis_z = Aim.transform.position.z - transform.position.z;

        return Mathf.Sqrt(dis_x * dis_x + dis_z * dis_z);
    }

    // Start is called before the first frame update
    void Start()
    {
        now = Random.Range(0, num);
    }

    // Update is called once per frame
    void Update()
    {
        if(Counting_time && timer > 0f){
            timer -= Time.deltaTime;
        }

        if (detect() > dis) return;
        if(timer <= 0) {
            if(visited.Count >= MaxRoadNumber) {
                var front = visited.Dequeue();
                Object.Destroy(front);
            }
            return;
        }
        float deg, dic_x, dic_z;
        float[] offset;

        GameObject item = Instantiate(Unit[now], transform.position, transform.rotation);
        visited.Enqueue(item);
        
        Path.Clear();
        
        bool[] ray = new bool[3] {
            !Physics.Raycast(transform.position, Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.forward.normalized, Mathf.Infinity),
            !Physics.Raycast(transform.position, Quaternion.Euler(0f, transform.eulerAngles.y - 90, 0f) * Vector3.forward.normalized, Mathf.Infinity),
            !Physics.Raycast(transform.position, Quaternion.Euler(0f, transform.eulerAngles.y + 90, 0f) * Vector3.forward.normalized, Mathf.Infinity)
        };

        if (ray[0])
            for (int i = 0; i < num; i++)
                if (now != i) Path.Add(i);
        if (ray[1] && now != num)
            Path.Add(num);
        if (ray[2] && now != num + 1)
            Path.Add(num + 1);

        int next = Random.Range(0, Path.Count);

        if(visited.Count >= MaxRoadNumber) {
            var front = visited.Dequeue();
            Object.Destroy(front);
        }
        
        if (now == num) {
            if (next == num + 1 || next == now) offset = new float[] { -Offset_corner, 0, -Offset_deg };
            else offset = new float[] { -Offset_x, 0, -Offset_deg };
        }
        else if (now == num + 1)  {
            if (next == num || next == now) offset = new float[] { Offset_corner, 0, Offset_deg };
            else offset = new float[] { Offset_x, 0, Offset_deg };
        }
        else                offset = new float[] { 0, Offset_z, 0 };

        deg = transform.eulerAngles.y * Mathf.PI / 180;

        dic_x = Mathf.Cos(deg) * offset[0] + Mathf.Sin(deg) * offset[1];
        dic_z = Mathf.Cos(deg) * offset[1] - Mathf.Sin(deg) * offset[0];

        transform.position += new Vector3(dic_x, 0, dic_z);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + offset[2], 0);

        past = now;
        now = Path[next];

        left = false;
        right = false;
    }
}