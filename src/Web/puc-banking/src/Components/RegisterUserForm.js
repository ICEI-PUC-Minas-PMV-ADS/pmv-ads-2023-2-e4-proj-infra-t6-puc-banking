import React from "react";
import "../RegisterForm.css";

const RegisterUserForm = () => {
    return (
        <div>
            <div className="form-control">
                <label htmlFor="name">Nome Completo:</label>
                <input type="text" name="name" id="name" placeholder="Digite seu nome" required></input>
            </div>
            <div className="form-control">
                <label htmlFor="Cpf">CPF:</label>
                <input type="text" name="cpf" id="cpf" placeholder="Digite seu CPF" required></input>
            </div>
        </div>
    )
}
export default RegisterUserForm