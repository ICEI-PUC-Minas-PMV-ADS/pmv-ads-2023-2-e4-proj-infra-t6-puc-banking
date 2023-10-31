import React from "react";

const RegisterCardForm = () => {
    return (
        <div>
            <div>
            <div className="form-control">
                <label htmlFor="senha">Senha do Cartão:</label>
                <input type="text" name="name" id="name" placeholder="Digite a senha do cartão" required></input>
            </div>
            <div className="form-control">
                <label htmlFor="Confirm-Senha">Confirme a senha do Cartão:</label>
                <input type="text" name="cpf" id="cpf" placeholder="Digite a senha do cartão" required></input>
            </div>
        </div>
        </div>
    )
}
export default RegisterCardForm