namespace PucBookStore.Events {
    public class BasketItemNotFoundEvent : Event {
        public BasketItemNotFoundEvent() : base("O Item não foi encontrado no carrinho.") {
        }
    }
}
