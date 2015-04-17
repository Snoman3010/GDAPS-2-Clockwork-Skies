using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace ClockworkSkies
{
    public enum victoryConditions { Elimination, Survival, Escort, EnemyEscort, DestroyBase, DefendBase, DoubleEscort, DoubleBase };
    public enum gameState { Playing, Won, Lost};

    public class Level
    {
        //attributes
        public Player p1;
        private Enemy targetEnemy;
        private Ally targetAlly;
        private Base enemyBase;
        private Base allyBase;
        public List<NPC> npcs;
        private int timer;
        private victoryConditions victory;
        public gameState currentState;
        private string levelName;

        //constructor
        public Level(int time, int win, Vector3 playerData, Vector3 allyTarget, Vector3 enemyTarget, Vector2 allyBaseData, Vector2 enemyBaseData, List<Vector4> NPCList, string name)
        {
            levelName = name;
            //create player
            p1 = new Player(GameVariables.PlayerImage, new Vector2(playerData.X, playerData.Y), (float)(Math.PI * 2 * playerData.Z / 8));
            //set time limit
            timer = time * 60;
            //set vicrory condition
            victory = (victoryConditions)win;
            //set target ally if present
            if ((victory == victoryConditions.Escort) || (victory == victoryConditions.DoubleEscort))
            {
                targetAlly = new Ally(GameVariables.PlayerImage, new Vector2(allyTarget.X, allyTarget.Y), (float)(Math.PI * 2 * allyTarget.Z / 8));
            }
            //set target enemy if present
            if ((victory == victoryConditions.EnemyEscort)||(victory == victoryConditions.DoubleEscort))
            {
                targetEnemy = new Enemy(GameVariables.PlayerImage, new Vector2(enemyTarget.X, enemyTarget.Y), (float)(Math.PI * 2 * enemyTarget.Z / 8), p1);
            }
            //set allied base if present
            if ((victory == victoryConditions.DefendBase)||(victory == victoryConditions.DoubleBase))
            {
                allyBase = new Base(allyBaseData, true);
            }
            //set enemy base if present
            if ((victory == victoryConditions.DestroyBase)||(victory == victoryConditions.DoubleBase))
            {
                enemyBase = new Base(enemyBaseData, false);
            }
            //create NPC list
            npcs = new List<NPC>();
            //create NPCs and add to list
            int allyCount = 0;
            foreach (Vector4 data in NPCList)
            {
                NPC newNPC = null;
                if (data.W == 0)
                {
                    newNPC = new Enemy(GameVariables.PlayerImage, new Vector2(data.X, data.Y), (float)(Math.PI * 2 * data.Z / 8), p1);
                }
                else
                {
                    newNPC = new Ally(GameVariables.PlayerImage, new Vector2(data.X, data.Y), (float)(Math.PI * 2 * data.Z / 8));
                    allyCount++;
                }
                npcs.Add(newNPC);
            }
            //set NPC targets
            bool specialAllyTargeted = false;
            bool specialEnemyTargeted = false;
            for (int i = 0; i < npcs.Count; i++)
            {
                int specialProb = 0;
                if (npcs[i].Friendly)
                {
                    if (enemyBase != null)
                    {
                        if (!specialEnemyTargeted)
                        {
                            npcs[i].Target = enemyBase;
                            specialEnemyTargeted = true;
                        }
                        else
                        {
                            specialProb = 3;
                        }
                    }
                    else if (targetEnemy != null)
                    {
                        if (!specialEnemyTargeted)
                        {
                            npcs[i].Target = targetEnemy.Plane;
                            specialEnemyTargeted = true;
                        }
                        else
                        {
                            specialProb = 3;
                        }
                    }
                    if (npcs[i].Target == null)
                    {
                        if (GameVariables.GetRandom(0, 10) < specialProb)
                        {
                            if (enemyBase != null)
                            {
                                npcs[i].Target = enemyBase;
                            }
                            else if (targetEnemy != null)
                            {
                                npcs[i].Target = targetEnemy.Plane;
                            }
                        }
                        else
                        {
                            Plane targetMe = null;
                            while (targetMe == null)
                            {
                                int random = GameVariables.GetRandom(0, npcs.Count);
                                if (npcs[random].Friendly != npcs[i].Friendly)
                                {
                                    targetMe = npcs[random].Plane;
                                }
                            }
                            npcs[i].Target = targetMe;
                        }
                    }
                }
                else
                {
                    if (allyBase != null)
                    {
                        if (!specialAllyTargeted)
                        {
                            npcs[i].Target = allyBase;
                            specialAllyTargeted = true;
                        }
                        else
                        {
                            specialProb = 3;
                        }
                    }
                    else if (targetAlly != null)
                    {
                        if (!specialAllyTargeted)
                        {
                            npcs[i].Target = targetAlly.Plane;
                            specialAllyTargeted = true;
                        }
                        else
                        {
                            specialProb = 3;
                        }
                    }
                    if (npcs[i].Target == null)
                    {
                        if (GameVariables.GetRandom(0, 10) < specialProb)
                        {
                            if (allyBase != null)
                            {
                                npcs[i].Target = allyBase;
                            }
                            else if (targetAlly != null)
                            {
                                npcs[i].Target = targetAlly.Plane;
                            }
                        }
                        else
                        {
                            if (GameVariables.GetRandom(0, 6) > 2 || allyCount == 0)
                            {
                                npcs[i].Target = p1.Plane;
                            }
                            else
                            {
                                Plane targetMe = null;
                                while (targetMe == null)
                                {
                                    int random = GameVariables.GetRandom(0, npcs.Count);
                                    if (npcs[random].Friendly != npcs[i].Friendly)
                                    {
                                        targetMe = npcs[random].Plane;
                                    }
                                }
                                npcs[i].Target = targetMe;
                            }
                        }
                    }
                }
                npcs[i].hunting = true;
            }
            currentState = gameState.Playing;
        }

        public void Update()
        {
            GameVariables.MainGame.Window.Title = levelName + ", Remaining Time: " + (timer / 60);
            //run update methods for Player, NPCS and bases
            p1.Update();
            if (targetAlly != null)
            {
                targetAlly.Update();
            }
            if (targetEnemy != null)
            {
                targetEnemy.Update();
            }
            if (allyBase != null)
            {
                allyBase.Update();
            }
            if (enemyBase != null)
            {
                enemyBase.Update();
            }
            for (int i = 0; i < npcs.Count; i++ )
            {
                npcs[i].Update();
                if (npcs[i].IsDead())
                {
                    npcs.RemoveAt(i);
                }
                else if (npcs[i].Target is Plane)
                {
                    Plane target = (Plane)npcs[i].Target;
                    if (target.dead)
                    {
                        if (npcs[i].Friendly)
                        {
                            if (targetEnemy != null)
                            {
                                npcs[i].Target = targetEnemy.Plane;
                            }
                            else
                            {
                                npcs[i].Target = null;
                            }
                        }
                        else
                        {
                            if (targetAlly != null)
                            {
                                npcs[i].Target = targetAlly.Plane;
                            }
                            else
                            {
                                npcs[i].Target = p1.Plane;
                            }
                        }
                    }
                }
            }
            //victory test code
            if (p1.IsDead())
            {
                currentState = gameState.Lost;
                return;
            }
            bool enemysLeft = false;
            switch (victory)
            {
                case victoryConditions.Elimination:
                    for (int i = 0; i < npcs.Count; i++)
                    {
                        if (npcs[i] is Enemy)
                        {
                            enemysLeft = true;
                        }
                    }
                    if (!enemysLeft)
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.Survival:
                    for (int i = 0; i < npcs.Count; i++)
                    {
                        if (npcs[i] is Enemy)
                        {
                            enemysLeft = true;
                        }
                    }
                    if (!enemysLeft)
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.Escort:
                    if (targetAlly.IsDead())
                    {
                        currentState = gameState.Lost;
                        return;
                    }
                    for (int i = 0; i < npcs.Count; i++)
                    {
                        if (npcs[i] is Enemy)
                        {
                            enemysLeft = true;
                        }
                    }
                    if (!enemysLeft)
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.EnemyEscort:
                    if (targetEnemy.IsDead())
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.DoubleEscort:
                    if (targetAlly.IsDead())
                    {
                        currentState = gameState.Lost;
                        return;
                    }
                    if (targetEnemy.IsDead())
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.DefendBase:
                    if (allyBase.IsDead())
                    {
                        currentState = gameState.Lost;
                        return;
                    }
                    for (int i = 0; i < npcs.Count; i++)
                    {
                        if (npcs[i] is Enemy)
                        {
                            enemysLeft = true;
                        }
                    }
                    if (!enemysLeft)
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.DestroyBase:
                    if (enemyBase.IsDead())
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
                case victoryConditions.DoubleBase:
                    if (allyBase.IsDead())
                    {
                        currentState = gameState.Lost;
                        return;
                    }
                    if (enemyBase.IsDead())
                    {
                        currentState = gameState.Won;
                        return;
                    }
                    break;
            }
            //timer code
            timer--;
            if (timer <= 0)
            {
                switch (victory)
                {
                    case victoryConditions.Elimination:
                        currentState = gameState.Lost;
                        return;
                    case victoryConditions.Survival:
                        currentState = gameState.Won;
                        return;
                    case victoryConditions.Escort:
                        currentState = gameState.Won;
                        return;
                    case victoryConditions.EnemyEscort:
                        currentState = gameState.Lost;
                        return;
                    case victoryConditions.DoubleEscort:
                        currentState = gameState.Lost;
                        return;
                    case victoryConditions.DefendBase:
                        currentState = gameState.Won;
                        return;
                    case victoryConditions.DestroyBase:
                        currentState = gameState.Lost;
                        return;
                    case victoryConditions.DoubleBase:
                        currentState = gameState.Lost;
                        return;
                }
            }
        }

        public void Clear()
        {
            GameVariables.pieces.Clear();
            GameVariables.smokeList.Clear();
            GameVariables.MainGame.Window.Title = "Clockwork Skies";
        }
    }
}
