using System;
namespace Mazes
{
	public static class EmptyMazeTask
	{
		private static void MoveRobotNPointToDown(Robot robot, int point)
        {
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Down);
        }
		private static void MoveRobotNPointToRight(Robot robot, int point)
		{
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Right);
		}
		public static void MoveOut(Robot robot, int width, int height)
		{
			MoveRobotNPointToRight(robot, width - 2);
			MoveRobotNPointToDown(robot, height - 2);
		}
	}
}