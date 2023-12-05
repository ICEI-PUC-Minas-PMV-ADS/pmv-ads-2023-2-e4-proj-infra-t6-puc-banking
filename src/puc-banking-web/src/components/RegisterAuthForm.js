import React, { useState } from "react";
import Container from "./Container";
import { useValidation } from "../hooks/useValidation";
import '../styles/RegisterAuthForm.css';

function validatePassword(password) {

    const regexMin =  /[a-z]/;
    const regexMai = /[A-Z]/;
    const regexNum = /\d/;

    var message = undefined;

    if (!message && password.length < 8) {
        message = 'A senha precisa ter no mínimo 8 caracteres.'
    }

    if (!message && !regexMin.test(password)) {
        message = 'A senha precisa ter no mínimo uma letra minuscula.'
    }

    if (!message && !regexMai.test(password)) {
        message = 'A senha precisa ter no mínimo uma letra maiuscula.'
    }

    if (!message && !regexNum.test(password)) {
        message = 'A senha precisa ter no mínimo um número.'
    }

    return {
        isValid: message === undefined ? true : false,
        message: message
    }
}

function validateEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!regex.test(email)) {
        return {
            isValid: false,
            message: 'O texto inserido não é um endereço de email válido.'
        }
    }

    return {
        isValid: true
    }
}

export default function RegisterAuthForm({ setEmail, setPassword }) {

    const [password, setLocalPassword] = useState(undefined);

    function validateRePassword(repass) {
        if (repass !== password) {
            return {
                isValid: false,
                message: 'As senhas não coincidem.'
            }
        }

        return {
            isValid: true
        }
    }

    const emailValidation = useValidation(validateEmail);
    const passValidation = useValidation(validatePassword);
    const repassValidation = useValidation(validateRePassword);

    return(
        <Container className="column justify-space-around max-width max-height">
            <Container className='app-form-control column max-width'>
                <label htmlFor="email">E-mail:</label>
                <input type="email" name="email" id="email" placeholder="Digite seu email" required onChange={(e) => setEmail(e.target.value)} onBlur={(e) => emailValidation.validate(e.target.value)}></input>
                <p className='alert-input'>{emailValidation.message}</p>
            </Container>

            <Container className='app-form-control column max-width'>
                <label htmlFor="password">Senha:</label>
                <input type="password" name="password" id="name" placeholder="Digite sua senha" required onChange={(e) => { setPassword(e.target.value); setLocalPassword(e.target.value) }} onBlur={(e) => passValidation.validate(e.target.value)}></input>
                <p className='alert-input'>{passValidation.message}</p>
            </Container>

            <Container className='app-form-control column max-width'>
                <label htmlFor="re-password">Confirmação de senha:</label>
                <input type="password" name="re-password" id="re-password" placeholder="Confirme sua senha" required onBlur={(e) => repassValidation.validate(e.target.value)}></input>
                <p className='alert-input'>{repassValidation.message}</p>
            </Container>
        </Container>
    );
}
