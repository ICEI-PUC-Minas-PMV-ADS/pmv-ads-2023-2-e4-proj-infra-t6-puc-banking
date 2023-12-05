namespace PucBookStore.Events {
    public class Event {
        public Event(string message) {
            this.Message = message;
        }
        public string Message { get; } 
    }
}
