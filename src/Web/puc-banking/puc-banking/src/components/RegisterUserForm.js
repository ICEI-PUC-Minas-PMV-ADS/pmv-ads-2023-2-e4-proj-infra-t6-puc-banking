import React from "react";
import Container from "./Container.js";
import '../styles/RegisterUserForm.css';

export default function RegisterUserForm({ setName, setCpf }) {
    return (
        <Container className='column justify-space-around max-width max-height'>

            <Container className='app-form-control column max-width'>
                <label htmlFor="name">Nome Completo:</label>
                <input type="text" name="name" id="name" placeholder="Digite seu nome" required onChange={(e) => setName(e.target.value)}></input>
            </Container>

            <Container className='app-form-control column max-width'>
                <label htmlFor="cpf">CPF:</label>
                <input type="text" name="cpf" id="cpf" placeholder="Digite seu CPF" required onChange={(e) => setCpf(e.target.value)}></input>
            </Container>

            <Container className='app-form-control column max-width'>
                <label htmlFor="date">Data de Nascimento:</label>
                <input type="date" name="date" id="date" placeholder="Digite sua data de nascimento" required></input>
            </Container>

        </Container>
    );
}
