namespace Mazes
{
	public static class SnakeMazeTask
	{
		private static void MoveRobotNPointToRight(Robot robot, int point)
		{
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Right);
		}
		
		private static void MoveRobotNPointToLeft(Robot robot, int point)
		{
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Left);
		}

		private static void MoveRobotNPointToDown(Robot robot, int point)
		{
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Down);
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
            while (!robot.Finished)
            {
				MoveRobotNPointToRight(robot, width - 2);
				MoveRobotNPointToDown(robot, 3);
				MoveRobotNPointToLeft(robot, width - 2);

				if (!robot.Finished)
				{
					MoveRobotNPointToDown(robot, 3);
				}
				else break;
			}
		}
	}
}