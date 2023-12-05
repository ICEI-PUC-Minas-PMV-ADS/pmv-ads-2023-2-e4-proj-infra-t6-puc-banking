namespace PucBookStore.Events {
    public class BasketItemAlreadyAddedEvent : Event {
        public BasketItemAlreadyAddedEvent(Guid BasketItemId) : base("O Item já está no carrinho.") {
            this.BasketItemId = BasketItemId;
        }

        public Guid BasketItemId { get; }
    }
}
