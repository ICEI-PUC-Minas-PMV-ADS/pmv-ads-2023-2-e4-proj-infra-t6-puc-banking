using PucBookStore.Events;
using PucBookStore.Models;

namespace PucBookStore.ViewModels {
    public class PaymentViewModel {
        public string BasketUsername { get; set; }
        public Basket Basket { get; set; }
        public PaymentInfos PaymentInfos { get; set; }
        public Event Event { get; set; }
    }
}
