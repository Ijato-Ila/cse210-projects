/* 
 * Exceeding Requirements Report:
 * 
 * To enhance the core requirements and add creativity to the assignment, the following feature has been added:
 * 
 * 1. **Leveling System**: 
 *    - Introduced a leveling system to increase user engagement. The user now earns "experience points" (XP) from goals. 
 *    - As the user completes goals and achieves specific milestones, they can level up. 
 *    - Each level requires an increasing amount of XP, and the player can see their level and total XP on the main menu.
 * 
 
 * This feature aims to make the game more dynamic and fun, providing a deeper sense of accomplishment or consequence.
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
