using Moq.Language.Flow;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Moq.Tests
{
	public class Training
	{
		[Fact]
		public void Walk()
		{
			//setup - data
			var order = new Robot();
			var mock = new Mock<IRobot>();

			//setup - expectations
			//mock.Setup(x => {
			//	x.Walk(Direction.Foward, 100);
			//	});
			mock.Setup(x => x.Rotate(90));

			mock.Setup(x => x.IsWalking);
		
			//verify state
			Assert.True(mock.Object.IsWalking);


			//verify interaction
			mock.VerifyAll();
		}

		[Flags]
		public enum Direction : byte
		{
			None = 0,
			Left = 1,
			Right = 2,
			Foward = 4,
			Backward = 8,
		}
		
		public interface IRobot
		{
			bool IsWalking { get; }
			public Direction Direction { get; }
			void Walk(Direction direction, int speed);
			void Rotate(float degree);
		}

		public class Robot : IRobot
		{
			public Direction Direction { get; private set; } = Direction.None;
			public bool IsWalking { get; private set; }

			public void Rotate(float degree)
			{
				throw new NotImplementedException();
			}

			public void Walk(Direction direction, int speed)
			{
				this.Direction = direction;
				this.IsWalking = direction != Direction.None;
			}
		}
	}
}
