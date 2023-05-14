using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield  
{
    public static int w = 60;
    public static int h = 32;
    public static Element[,] elements = new Element[w, h];

    public static void uncoverMines()
    {
        GameObject[] tiles;
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject tile in tiles)
        {
            if (tile.GetComponent<Element>().mine) tile.GetComponent<Element>().loadTexture(0);
        }
    }
    //Find out if a mine is at the coordinates
    public static bool mineAt(int x, int y)
    {
        //Coordinates in range? Then check for mine.
        if (x >= 0 && y >= 0 && x < GameObject.FindObjectOfType<TileGenerator>().maxX * 2 && y < GameObject.FindObjectOfType<TileGenerator>().maxY * 2)
        {
            return elements[x, y].GetComponent<Element>().mine;
        }
        return false;
    }

    // Count adjacent mines for an element
    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 2)) ++count; // top
        if (mineAt(x + 2, y + 2)) ++count; // top-right
        if (mineAt(x + 2, y)) ++count; // right
        if (mineAt(x + 2, y - 2)) ++count; // bottom-right
        if (mineAt(x, y - 2)) ++count; // bottom
        if (mineAt(x - 2, y - 2)) ++count; // bottom-left
        if (mineAt(x - 2, y)) ++count; // left
        if (mineAt(x - 2, y + 2)) ++count; // top-left

        return count;
    }


    // Flood Fill empty elements
    public static void FFuncover(int x, int y, bool[,] visited)
    {
        //Debug.Log(x + ", " + y); //show x,y coordinates

        // Coordinates in Range?
        if (x >= 0 && y >= 0 && x < GameObject.FindObjectOfType<TileGenerator>().maxX * 2 && y < GameObject.FindObjectOfType<TileGenerator>().maxY * 2)
        {
            // visited already?
            if (visited[x, y])
                return;
            //uncover element
            elements[x, y].loadTexture(adjacentMines(x, y));

            // close to a mine? then no more work needed here
            if (adjacentMines(x, y) > 0)
                return;

            // set visited flag
            visited[x, y] = true;

            // recursion
            FFuncover(x - 2, y, visited);
            FFuncover(x + 2, y, visited);
            FFuncover(x, y - 2, visited);
            FFuncover(x, y + 2, visited);
        }
    }

    public static bool IsFinished()
    { 
        //all mines
        List<Element> mines = GameObject.FindObjectOfType<GameManager>().startMines;
        //all normal
        List<Element> tiles = GameObject.FindObjectOfType<GameManager>().normalTiles;
        //all uncovered
        List<Element> uncovered = GameObject.FindObjectOfType<GameManager>().uncoveredTiles;

         bool allTilesCovered = true;
            if (uncovered.Count == tiles.Count)
                allTilesCovered = false;

         if (!allTilesCovered)
             return true;
         return false;
    } 
}


    

