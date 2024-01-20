namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class MatchmakeService
    {
        private static int _matchmakeState = 0;

        public static int GetMatchmakeState()
        {
            return _matchmakeState;
        }

        public static void SetMatchmakeState(int newState)
        {
            _matchmakeState = newState;
        }

        public static void UpdateMatchmakeState(int newState)
        {
            _matchmakeState = newState;
        }
    }
}
