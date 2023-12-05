namespace PucBookStore.Events {
    public class BasketItemAddedEvent : Event {
        public BasketItemAddedEvent(Guid BasketItemId) : base("Item adicionado ao carrinho com sucesso.") {
            this.BasketItemId = BasketItemId;
        }

        public Guid BasketItemId { get; }
    }
}
