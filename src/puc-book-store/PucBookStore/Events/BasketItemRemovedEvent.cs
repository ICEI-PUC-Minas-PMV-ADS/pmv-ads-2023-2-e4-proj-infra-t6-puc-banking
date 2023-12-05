namespace PucBookStore.Events {
    public class BasketItemRemovedEvent : Event {
        public BasketItemRemovedEvent() : base("O Item foi removido do seu carrinho.") {
        }
    }
}
