import React, { useEffect } from "react";
import PaymentIcon from '@mui/icons-material/Payment';
import PaymentsIcon from '@mui/icons-material/Payments';
import ViewListIcon from '@mui/icons-material/ViewList';
import '../styles/HomePage.css';
import PucLogo from '../assets/puc-logo-light.png';
import { useAuth } from '../hooks/useAuth';
import { useUser } from '../hooks/useUser';
import { splitCardNumber, getDatetime } from '../utils/StringUtils';

export default function HomePage() {

    const { userData, cardData, transactions } = useUser();

    return (
        <div className="container-fluid min-vh-100">
            <div className="container pt-5" style={{ height: '100vh', display: 'grid', gridTemplateRows: 'min-content auto' }}>
                <h2 className="welcome-message">{`Olá, ${userData.firstName} ${userData.lastName}`}</h2>
                <div className="d-flex flex-column justify-content-center">
                    <div className="d-flex flex-row flex-wrap justify-content-between align-items-end">
                        <div className="credit-card">
                            <img className="credit-card-logo" src={PucLogo} />
                            <div className="d-flex flex-row justify-content-between flex-wrap">
                                <div className="d-flex flex-column">
                                    <span className="credit-card-number">{splitCardNumber(`${cardData.number}`)}</span>
                                    <span className="credit-card-name">{userData.firstName + " " + userData.lastName}</span>
                                </div>
                                <div className="d-flex justify-content-end">
                                    <div className="d-flex flex-column">
                                        <span className="credit-card-label">CVV</span>
                                        <span className="credit-card-value">{cardData.cvv}</span>
                                    </div>
                                    <div className="d-flex flex-column mx-2">
                                        <span className="credit-card-label">Validate</span>
                                        <span className="credit-card-value">{getDatetime(cardData.expiresOn)}</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="d-flex flex-row flex-wrap justify-content-start" style={{ marginTop: '24px', marginRight: '20px' }}>
                                <div className="card bg-light">
                                <div className="card-body">
                                    <h2 className="card-title">Fatura</h2>
                                    <p className="card-text text-center">R${cardData.creditLimit - cardData.availableCreditLimit}</p>
                                    <a className="card-button btn" role="button">Pagar</a>
                                </div>
                            </div>

                            <div className="card bg-light">
                                <div className="card-body">
                                    <h2 className="card-title">Limite disponível</h2>
                                    <p className="card-text text-center">{`R$ ${cardData.availableCreditLimit}`}</p>
                                </div>
                            </div>

                            <div className="card bg-light">
                                <div className="card-body">
                                    <h2 className="card-title">Limite usado</h2>
                                    <p className="card-text text-center">R${cardData.creditLimit - cardData.availableCreditLimit}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h3 className="transactions-label  mt-4">Histórico de utilização</h3>
                    <div className="container-fluid bg-light rounded-3 pb-4 overflow-auto" style={{ minHeight: '200px' }}>
                        <div className="container p-2 w-100 h-100">

                            {
                                transactions.length === 0 ? (
                                    <div className="w-100 h-100 d-flex justify-content-center align-items-center">
                                        <spa className='text-black fs-5'>Você ainda não usou o seu cartão!</spa>
                                    </div>
                                ) : (
                                    transactions.map((transaction) => {
                                        return (
                                        <>
                                        <div className="row py-2">
                                            <div className="col-auto d-flex align-items-center">
                                                <div className="transaction-icon-wrapper">
                                                    <PaymentsIcon className="transaction-icon"></PaymentsIcon>
                                                </div>
                                            </div>
                                            <div className="col d-flex align-items-center">
                                                <div className="d-flex flex-column justify-content-around">
                                                    <p className="transaction-name">{transaction.name}</p>
                                                    <p className="transaction-time">{formatData(transaction.createdOn)}</p>
                                                </div>
                                            </div>
                                            <div className="col-auto d-flex align-items-center">
                                                <span className="transaction-value">R${transaction.value}</span>
                                            </div>
                                        </div>
                                        </>
                                        )
                                    })
                                )
                            }
                        </div>
                    </div>
                    <div className="d-flex flex-row my-3">
                        <a href="https://localhost:44375" className="bg-light control-btn">
                            <PaymentIcon></PaymentIcon>
                            <span>Comprar</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    );
}


function formatData(date) {
    var d = new Date(date);

    return `${d.getDay()}/${d.getMonth()}/${d.getFullYear()} ${d.getHours()}:${d.getMinutes()}`;
}
