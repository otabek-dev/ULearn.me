namespace Mazes
{
	public static class DiagonalMazeTask
	{
		private static void MoveRobotNPointToRight(Robot robot, int point)
		{
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Right);
		}

		private static void MoveRobotNPointToDown(Robot robot, int point)
		{
			for (int i = 1; i < point; i++)
				robot.MoveTo(Direction.Down);
		}

		private static void MoveOutDiagonalMazeToRight(Robot robot, int point)
		{
			while (!robot.Finished)
			{
				MoveRobotNPointToRight(robot, point);
				if (!robot.Finished)
					MoveRobotNPointToDown(robot, 2);
			}
		}

		private static void MoveOutDiagonalMazeToDown(Robot robot, int point)
		{
			while (!robot.Finished)
			{
				MoveRobotNPointToDown(robot, point);
				if (!robot.Finished)
					MoveRobotNPointToRight(robot, 2);
			}
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
            if (width > height)
            {
				MoveOutDiagonalMazeToRight(robot, (width - 2) / (height - 2) + 1);
			}
			else
            {
				MoveOutDiagonalMazeToDown(robot, (height - 2) / (width - 2) + 1);
			}
		}
	}
}