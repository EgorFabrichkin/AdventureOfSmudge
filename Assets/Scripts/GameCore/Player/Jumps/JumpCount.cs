using UniRx;

namespace GameCore.Player.Jumps
{
    public class JumpCount
    {
        private readonly IntReactiveProperty maxValue = new(20);
        public IReadOnlyReactiveProperty<int> MaxValue => maxValue;

        public JumpCount(Player player)
        {
            player.jumped.AddListener(()=> maxValue.Value--);
            player.boosted.AddListener(()=> maxValue.Value = 20);
        }
    }
}