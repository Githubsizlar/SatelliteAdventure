using System.Threading;
using System.Threading.Tasks;

namespace State
{
    public class PlacingHomeDraft: GameState
    {
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}