﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SRPG_Framework
{
    public class PlayerUnit : Character
    {
        // attributes
        // stats
        private int hitPoints;
        private int attack;
        private int defense;
        private int magic;
        private int resistance;
        private int speed;
        private int movement;
        List<int> collectedStats;

        // growth rates
        private int hitPointsRate;
        private int attackRate;
        private int defenseRate;
        private int magicRate;
        private int resistanceRate;
        private int speedRate;
        private int movementRate;

        // put all the growth rates into a list
        List<int> collectedGrowths;

        // represent player inventory as an array to keep it finite
        Item[] inventory = new Item[5];

        private int level;
        private int currentExperience;
        private int totalExperience;

        // properties
        // constructor
        public PlayerUnit(Texture2D thisSprite, int x, int y, int width, int height, bool isDynamic, string thisName, string thisClass,
                            int hp, int atk, int def, int mag, int res, int spd, int mov,
                            int hpRate, int atkRate, int defRate, int magRate, int resRate, int spdRate, int movRate) : base(thisSprite, x, y, width, height, isDynamic, thisName, thisClass)
        {
            // assign the stats
            hitPoints = hp;
            attack = atk;
            defense = def;
            magic = mag;
            resistance = res;
            speed = spd;
            movement = mov;

            // assign the growth rates
            hitPointsRate = hpRate;
            attackRate = atkRate;
            defenseRate = defRate;
            magicRate = magRate;
            resistanceRate = resRate;
            speedRate = spdRate;
            movementRate = movRate;

            collectedStats = new List<int>() { hitPoints, attack, defense, magic, resistance, speed, movement };
            collectedGrowths = new List<int>() { hitPointsRate, attackRate, defenseRate, magicRate, resistanceRate, speedRate, movementRate};
        }
        
        // methods
        public void LevelUp()
        {
            for (int i = 0; i < collectedStats.Count; i++)
            {
                int levelCheck = GrowthChecker.Next(0, 101);
                if(collectedGrowths[i] < levelCheck)
                {
                    collectedStats[i]++;
                }
            }
        }

        public void GetExperience(int exp)
        {
            currentExperience += exp;
        }

    }
}
