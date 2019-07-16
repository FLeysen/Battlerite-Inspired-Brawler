﻿public enum PlayerEvent
{
    Knockback = 0, //Single argument required: PairWithKey<string, Vector3, float> (source name, distance, duration)
    HealthChange = 1, //Single argument required: float (amount changed)
    Death = 2, //No arguments required
}