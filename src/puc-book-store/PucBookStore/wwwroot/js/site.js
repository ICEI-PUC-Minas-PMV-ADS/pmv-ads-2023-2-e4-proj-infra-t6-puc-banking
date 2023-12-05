var event = localStorage.getItem('event-message');

if (event) {
    const alertMessage = document.getElementById('alert-message');
    const alertMessageText = document.getElementById('alert-message-text');
    alertMessage.style.display = 'block';
    alertMessageText.textContent = event;

    setTimeout(() => {
        const alertMessage = document.getElementById('alert-message');
        alertMessage.style.display = 'none';
        localStorage.removeItem('event-message');
    }, 5000);
}

function addBookOnBasket(bookId, basketUsername) {
    $.ajax({
        type: "POST",
        url: 'basket/addBookOnBasket',
        data: `{"bookId": "${bookId}", "basketUsername": "${basketUsername}"}`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            localStorage.setItem('event-message', 'Item adicionado ao carrinho.');
            location.href = `?basketUsername=${basketUsername}`;
        },
        error: function (error) {

            localStorage.setItem('event-message', error.responseJSON['message']);
            location.reload();
        }
    });
}

function removeBookOnBasket(bookId, basketUsername) {
    $.ajax({
        type: "POST",
        url: 'basket/removeBookOnBasket',
        data: `{"bookId": "${bookId}", "basketUsername": "${basketUsername}"}`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            localStorage.setItem('event-message', 'Item removido do carrinho.');
            location.href = `?basketUsername=${basketUsername}`;
        },
        error: function (error) {

            localStorage.setItem('event-message', error.responseJSON['message']);
            location.reload();
        }
    });
}

function checkout() {

    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const email = document.getElementById('email').value;
    const address = document.getElementById('address').value;
    const state = document.getElementById('state').value;
    const zip = document.getElementById('zip').value;
    const cardName = document.getElementById('cc-name').value;
    const cardNumber = document.getElementById('cc-number').value;
    const cardExpiration = document.getElementById('cc-expiration').value;
    const cardCVV = document.getElementById('cc-cvv').value;
    const saveInfos = document.getElementById('save-info').checked;

    const waitingModal = document.getElementById('waitingPaymentModal');
    waitingModal.style.display = 'flex';

    $.ajax({
        type: "POST",
        url: 'payment/checkout',
        data: `{
            "firstName": "${firstName}",
            "lastName": "${lastName}",
            "email": "${email}",
            "address": "${address}",
            "state": "${state}",
            "zip": "${zip}",
            "cardName": "${cardName}",
            "cardNumber": "${cardNumber}",
            "cardExpiration": "${cardExpiration}",
            "cardCVV": "${cardCVV}",
            "saveInfos": ${saveInfos}
        }`,
        contentType: "application/json; charset=utf-8",
        success: function () {

            console.log('Approved')

            waitingModal.style.display = 'none';
            const paymentApprovedModal = document.getElementById('paymentApprovedModal');
            paymentApprovedModal.style.display = 'flex';
        },
        error: function (error) {

            console.log(error);
            console.log('Reproved')

            waitingModal.style.display = 'none';
            const paymentReprovedModal = document.getElementById('paymentReprovedModal');
            paymentReprovedModal.style.display = 'flex';
        }
    });
}