import React from "react";
import Container from './Container';
import '../styles/RegisterThanksForm.css';

export default function RegisterThanksForm() {
    return (
        <Container className='max-width'>
            <Container className="thanks-container">
                <h2>Falta Pouco...</h2>
                <p>
                    Sua conta está em processo de análise e logo estará aberta, você receberá
                    em seu email a confirmação de que sua conta já está ativa.
                </p>
                <p>
                    Para concluir sua abertura de conta clique no botão abaixo. Muito obrigado por escolher o PUC-bank
                </p>

            </Container>
        </Container>
    );
}
