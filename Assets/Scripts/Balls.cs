using UnityEngine;
using System.Collections;

public class Balls : MonoBehaviour {

    public Material[] ballMaterials;
    private int[] coloredBallCounts = new int[] {0, 0, 0, 0}; // Spawned ball counts relative to ballMaterials array
    public GameObject ballPlane;
    public float spawnAreaWidth;
    public float spawnAreaHeight;
    public int ballCount = 10;
    public string correctColor;

    void Start() {
        spawnBallsInTheArea();
        outputColorCounts();
    }

    void zeroBallCounts() {
        for (int i = 0; i < coloredBallCounts.Length; i++)
        {
            coloredBallCounts[i] = 0;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    void spawnBallsInTheArea() {
        zeroBallCounts();
        for (int i = 0; i < ballCount; i++) {
            GameObject newBall = (GameObject)Instantiate(ballPlane, getRandomPositionInTheSpawnArea(), new Quaternion(0, 0, 0, 0));
            newBall.GetComponent<Renderer>().material = getRandomBallMaterial();
            newBall.transform.Rotate(Vector3.right, 90);
            newBall.transform.Rotate(Vector3.forward, 180);
        }
        setCorrectColorString();
    }

    void setCorrectColorString() {
        int max = coloredBallCounts[0];
        int maxId = 0;
        for (int i = 0; i < coloredBallCounts.Length; i++)
        {
            if (coloredBallCounts[i] > max) {
                max = coloredBallCounts[i];
                maxId = i;
            }
        }
        correctColor = returnCorrectColorString(ballMaterials[maxId]);
    }

    string returnCorrectColorString(Material material) {
        if (material.name.Equals("BlueBallRaw"))
        {
            return "blue";
        }
        else if (material.name.Equals("RedBallRaw"))
        {
            return "red";
        }
        else if (material.name.Equals("YellowBallRaw"))
        {
            return "yellow";
        }
        else if (material.name.Equals("GreenBallRaw"))
        {
            return "green";
        }
        return "something wrong";
    }

    Material getRandomBallMaterial() {
        int randomIndex = Random.Range(0, ballMaterials.Length);
        coloredBallCounts[randomIndex] += 1;
        return ballMaterials[randomIndex];
    }

    Vector3 getRandomPositionInTheSpawnArea() {
        return new Vector3(Random.Range(-spawnAreaWidth/2, spawnAreaWidth/2),
                            Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2), 0);
    }

    void outputColorCounts() {
        for (int i = 0; i < ballMaterials.Length; i++)
        {
            Debug.Log(ballMaterials[i].name + " " + coloredBallCounts[i] + " pcs");
        }
    }
}
