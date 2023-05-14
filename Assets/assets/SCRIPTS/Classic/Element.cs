using UnityEngine;
using UnityEngine.SceneManagement;


public class Element : MonoBehaviour
{
    [Header("CURRENT STATE")]
    public bool mine;
    public bool isFlaged;
    public bool covered = true;

    GameManager gameManager;
    Sound sound;
 
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sound = GetComponent<Sound>();  
        // Randomly decide if it's a mine or not
        if (transform.position == FindObjectOfType<TileGenerator>().startPosition) 
        {
            mine = false;
        }
        else
            mine = Random.value < 0.15;
        if (mine)
            gameManager.startMines.Add(GetComponent<Element>());
        else if (covered)
            gameManager.normalTiles.Add(GetComponent<Element>());

        //Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x, y] = this;
    }

    private void OnMouseOver() // MOUSE HOVER
    {
        if (FindObjectOfType<PlayfieldManager>().classic == true)
        {
            //here mouse hover sound?
            if (Input.GetMouseButtonDown(1) && !gameManager.gameFinished) // RIGHTCLICK (set/remove FLAG)
            {
                if (!isFlaged && covered)
                {
                    isFlaged = true;
                    loadTexture(0);
                    //sound PlaceFlag
                    sound.PlaySound(gameManager.flagSound);

                }
                else if (isFlaged)
                {
                    isFlaged = false;
                    GetComponent<SpriteRenderer>().sprite = gameManager.coveredTexture;
                    //sound RemoveFlag
                }
                if (Playfield.IsFinished())
                    gameManager.WinMenu(true);
            }

            if (Input.GetMouseButtonDown(0) && !gameManager.gameFinished) // LEFTCLICK (uncover TILE)
            {
                //Its a mine
                if (mine && !isFlaged)
                {
                    sound.PlaySound(gameManager.explosionSound);

                    //Uncover all mines
                    Playfield.uncoverMines();
                    //game over
                    gameManager.WinMenu(false);
                }

                else if (!mine && !isFlaged && covered) // UNCOVER TILE
                {
                    //sound uncover
                    sound.PlaySound(gameManager.uncoverSound);
                    //Debug.Log("LEFTCLICK");

                    if (!gameManager.gameStarted)
                        gameManager.gameStarted = true;
                    covered = false;

                    // show adjacent mine number
                    int x = (int)transform.position.x;
                    int y = (int)transform.position.y;
                    loadTexture(Playfield.adjacentMines(x, y));

                    // uncover area without mines
                    Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);

                    // add each uncovered tile to List
                    gameManager.uncoveredTiles.Clear();
                    GameObject[] tiles;
                    tiles = GameObject.FindGameObjectsWithTag("Tile");
                    foreach (GameObject tile in tiles)
                        if (!tile.GetComponent<Element>().covered) FindObjectOfType<GameManager>().uncoveredTiles.Add(GetComponent<Element>());

                    // find out if the game was won now
                    if (Playfield.IsFinished() && FindObjectOfType<PlayfieldManager>().classic == true)
                        gameManager.WinMenu(true);
                }
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (mine && GameObject.Find("Bar").transform.localScale.x > 0)
        {
            sound.PlaySound(gameManager.explosionSound);
            if (GameObject.Find("Bar").transform.localScale.x > 0)
            {
                //decrease Healthbar
                GameObject.Find("Bar").transform.localScale -= new Vector3(0.25f, 0, 0);
                loadTexture(0);
            }
            if (GameObject.Find("Bar").transform.localScale.x == 0)
            {
                gameManager.WinMenu(false);
                Playfield.uncoverMines();
            }
        }

        else if (!mine && covered) // UNCOVER TILE
        {
            //sound uncover
            sound.PlaySound(gameManager.uncoverSound);
            //Debug.Log("LEFTCLICK");

            if (!gameManager.gameStarted)
                gameManager.gameStarted = true;
            covered = false;

            // show adjacent mine number
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Playfield.adjacentMines(x, y));

            // uncover area without mines
            Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);

            // add each uncovered tile to List
            gameManager.uncoveredTiles.Clear();
            GameObject[] tiles;
            tiles = GameObject.FindGameObjectsWithTag("Tile");
            foreach (GameObject tile in tiles)
                if (!tile.GetComponent<Element>().covered) FindObjectOfType<GameManager>().uncoveredTiles.Add(GetComponent<Element>());

            // find out if the game was won now
            if (Playfield.IsFinished() && FindObjectOfType<PlayfieldManager>().story == true)
                SceneManager.LoadScene(3);                
        }
    }

    /*public void OnMouseUpAsButton() // LEFTCLICK (uncover TILE)
    {
        if (!gameManager.gameFinished)
        {
            //Its a mine
            if (mine && !isFlaged)
            {
                //Uncover all mines
                Playfield.uncoverMines();
                //game over
                gameManager.WinMenu(false);
            }

            else if (!mine && !isFlaged) // UNCOVER TILE
            {
                //sound uncover
                //Debug.Log("LEFTCLICK");

                if (!gameManager.gameStarted)
                    gameManager.gameStarted = true;
                covered = false;

                // show adjacent mine number
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                loadTexture(Playfield.adjacentMines(x, y));

                // uncover area without mines
                Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);
                 
                // add each uncovered tile to List
                gameManager.uncoveredTiles.Clear();           
                GameObject[] tiles;
                tiles = GameObject.FindGameObjectsWithTag("Tile");     
                foreach (GameObject tile in tiles)               
                    if (!tile.GetComponent<Element>().covered) FindObjectOfType<GameManager>().uncoveredTiles.Add(GetComponent<Element>());
               
                // find out if the game was won now
                if (Playfield.IsFinished())
                    gameManager.WinMenu(true);
            }
        }
    }*/

    // LOAD TEXTURE
    public void loadTexture(int adjacentCount) {
        // Load flag Texture
        if (isFlaged)       
            GetComponent<SpriteRenderer>().sprite = gameManager.flagTexture;
        // load mine Texture
        else if (mine) {    
            GetComponent<SpriteRenderer>().sprite = gameManager.mineTexture;
            Destroy(GetComponent<BoxCollider2D>());
            // Load empty Texture
        }
        else {                  
            GetComponent<SpriteRenderer>().sprite = gameManager.emptyTextures[adjacentCount]; covered = false;
        }
    }
    
    // STILL COVERED? 
    public bool isCovered()
    {
        Debug.Log("isCovered");
        return GetComponent<SpriteRenderer>().sprite == gameManager.coveredTexture;  
    }
}
