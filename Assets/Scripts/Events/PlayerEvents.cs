public enum PlayerEvent
{
    Knockback = 0, //Single argument required: PairWithKey<string, Vector3, float> (source name, distance, duration)
    HealthChange = 1, //Single argument required: float (amount changed)
    Death = 2, //No arguments required
    EnterStatus = 3 //Single argument: TripleWithKey<System.Type, float, float, float> (state to enter, floats can be filled in with anything)
    //SetAblaze = 3, //Three arguments required: float x3 (duration, ticks, damage per tick)
}