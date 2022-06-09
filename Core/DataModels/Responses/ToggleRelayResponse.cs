using Newtonsoft.Json;

namespace Core.DataModels.Responses
{
    public class ToggleRelayResponse
    {
        /// <summary>
        /// Whether the channel is turned ON or OFF
        /// </summary>
        [JsonProperty("ison")]       
        public bool IsOn { get; set; }

        /// <summary>
        /// Whether a timer is currently armed for this channel
        /// </summary>
        [JsonProperty("has_timer")]
        public bool HasTimer { get; set; }

        /// <summary>
        /// Unix timestamp of timer start; 0 if timer inactive or time not synced.
        /// </summary>
        [JsonProperty("timer_started")]
        public int TimerStarted { get; set; }

        /// <summary>
        /// Timer duration, s
        /// </summary>
        [JsonProperty("timer_duration")]
        public int TimerDuration { get; set; }

        /// <summary>
        /// experimental If there is an active timer, shows seconds until timer elapses; 0 otherwise
        /// </summary>
        [JsonProperty("timer_remaining")]
        public int TimerRemaining { get; set; }

        /// <summary>
        /// Source of the last relay command
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

    }
}
