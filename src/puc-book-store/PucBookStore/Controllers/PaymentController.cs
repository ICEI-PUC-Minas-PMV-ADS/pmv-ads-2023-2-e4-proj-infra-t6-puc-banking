using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PucBookStore.Contracts;
using PucBookStore.Data;
using PucBookStore.Data.Repositories;
using PucBookStore.Models;
using PucBookStore.ViewModels;
using System;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace PucBookStore.Controllers {
    public class PaymentController : Controller {

        private readonly ApplicationContext _context;
        private readonly BasketRepository _basketRepository;
        public PaymentController(ApplicationContext context, BasketRepository basketRepository) {
            _context = context;
            _basketRepository = basketRepository;
        }
        public async Task<IActionResult> Index() {

            var viewModel = new PaymentViewModel();

            if (User.Identity.IsAuthenticated) {

                var basket = await _basketRepository.GetBasket(User.Identity.Name);
                var paymentInfo = await _context.PaymentInfos.FirstOrDefaultAsync(x => x.Username == User.Identity.Name);

                viewModel.Basket = basket;
                viewModel.PaymentInfos = paymentInfo ?? PaymentInfos.Empty;

            } else {

                return Redirect("Identity/Account/Login");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody]CheckoutRequest request) {

            var basket = await _basketRepository
                .GetBasket(User.Identity.Name);

            await UpdatePaymentInfo(request);

            string url = "https://localhost:44300/v1/gateway/payments/pay";

            using StringContent data = new(
                System.Text.Json.JsonSerializer.Serialize(new PayRequest {
                    CardCVV = Convert.ToInt32(request.CardCVV),
                    CardExpires = request.CardExpiration,
                    CardHolderName = request.CardName,
                    CardNumber = long.Parse(request.CardNumber),
                    Name = "PucBanking Store",
                    Value = basket.Items.Sum(b => b.Price)
                }), Encoding.UTF8, "application/json");

            try {

                using (HttpClient cliente = new HttpClient()) {
                    cliente.DefaultRequestHeaders.Add("Origin", "*");
                    cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage resposta = await cliente.PostAsync(url, data);

                    if (resposta.IsSuccessStatusCode) {

                        var stringResponse = await resposta.Content.ReadAsStringAsync();
                        var respostaJson = JsonConvert.DeserializeObject<PayResponse>(stringResponse);

                        for (int timer = 0; timer < 3; timer++) {

                            Thread.Sleep(3000);

                            var status = await CheckStatus(respostaJson.Id);

                            if (status is TransactionStatus.Approved) {
                                break;
                            }
                            else
                                if (status is TransactionStatus.Reproved) {
                                return BadRequest();
                            }
                        }
                    }
                    else {
                        return BadRequest();
                    }
                }
            } catch(Exception exc) {
                Console.WriteLine(exc.ToString());
                return BadRequest();
            }

            foreach(var book in basket.Items) {
                _context.UserBooks.Add(new UserBook {
                    Author = book.Author,
                    DownloadUrl = book.DownloadUrl,
                    Description = book.Description,
                    PreviewUrl = book.PreviewUrl,
                    Title = book.Title,
                    Username = User.Identity.Name,
                    Year = book.Year,
                });
            }

            await _context.SaveChangesAsync();

            basket.Items = new List<BasketItem>();

            await _basketRepository.UpdateBasketAsync(basket);

            return Ok();
        }

        private async Task UpdatePaymentInfo(CheckoutRequest request) {

            var paymentInfo = await _context.PaymentInfos
                .FirstOrDefaultAsync(x => x.Username == User.Identity.Name);

            if (request.SaveInfos) {

                if (paymentInfo is null) {
                    paymentInfo = new PaymentInfos {
                        Address = request.Address,
                        CardCVV = request.CardCVV,
                        CardExpiration = request.CardExpiration,
                        CardName = request.CardName,
                        CardNumber = request.CardNumber,
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        State = request.State,
                        Username = User.Identity.Name,
                        ZIP = request.ZIP,
                    };

                    await _context.PaymentInfos.AddAsync(paymentInfo);
                    await _context.SaveChangesAsync();
                } else {
                    paymentInfo.Address = request.Address;
                    paymentInfo.CardCVV = request.CardCVV;
                    paymentInfo.CardExpiration = request.CardExpiration;
                    paymentInfo.CardName = request.CardName;
                    paymentInfo.CardNumber = request.CardNumber;
                    paymentInfo.Email = request.Email;
                    paymentInfo.FirstName = request.FirstName;
                    paymentInfo.LastName = request.LastName;
                    paymentInfo.State = request.State;
                    paymentInfo.ZIP = request.ZIP;

                    _context.PaymentInfos.Update(paymentInfo);
                    await _context.SaveChangesAsync();
                }
            } else {
                if (paymentInfo is not null) {
                    _context.PaymentInfos.Remove(paymentInfo);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task<TransactionStatus> CheckStatus(Guid transactionId) {

            string check = $"https://localhost:44300/v1/gateway/payments/check?transactionId={transactionId}";

            using (HttpClient cliente = new HttpClient()) {
                cliente.DefaultRequestHeaders.Add("Origin", "*");
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resposta = await cliente.GetAsync(check);

                if (resposta.IsSuccessStatusCode) {
                    string respostaString = await resposta.Content.ReadAsStringAsync();
                    var respostaJson = JsonConvert.DeserializeObject<PayResponse>(respostaString);

                    return respostaJson.Status;
                }
                else {
                    throw new Exception();
                }
            }
        }

        public class PayRequest {
            public double Value { get; set; }
            public string Name { get; set; }
            public long CardNumber { get; set; }
            public string CardHolderName { get; set; }
            public int CardCVV { get; set; }
            public string CardExpires { get; set; }
        }

        public class PayResponse {
            public Guid Id { get; set; }
            public TransactionStatus Status { get; set; }
        }

        public class CheckResponse {
            public Guid Id { get; set; }
            public TransactionStatus Status { get; set; }
        }

        public enum TransactionStatus {
            PendingOfConfirmation,
            Approved,
            Reproved,
        }
    }
}
