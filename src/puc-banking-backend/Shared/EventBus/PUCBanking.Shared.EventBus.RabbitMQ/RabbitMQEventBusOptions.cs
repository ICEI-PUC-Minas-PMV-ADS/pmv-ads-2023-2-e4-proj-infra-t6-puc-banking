namespace PUCBanking.Shared.EventBus.RabbitMQ {
    public class RabbitMQEventBusOptions {
        public string ConnectionString { get; set; }
        public string SubscriptionClientName { get; set; }
        public string BrokenName { get; set; }
        public int RetryCount { get; set; }
    }
}
